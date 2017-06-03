using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventsRegistryTest
	{
		#region " Test Classes "

		protected class TargetEntityClass 
		{
			public string Name { get; set; }
		}

		
		protected class TestEventSubscriptionAttribute : EventSubscriptionAttribute
		{
			public override string Name 
			{ 
				get { return "Test"; } 
			}

			public override Type SourceType
			{
				get { return typeof(TestEventSubscriptionAttribute); }
			}
		}

		protected class TestEventSubscription2Attribute : EventSubscriptionAttribute
		{
			public override string Name
			{
				get { return "Test2"; }
			}

			public override Type SourceType
			{
				get { return typeof(TestEventSubscription2Attribute); }
			}
		}

		[TestEventSubscription]
		[TestEventSubscription2]
		protected class TestAttributedSubscription
		{

		}

		protected class TestSubscription
		{
			public static readonly EventSubscription Changed = new EventSubscription(typeof(TestSubscription), "Changed");
			public static readonly EventSubscription Clicked = new EventSubscription(typeof(TestSubscription), "Clicked");
		}

		protected class TestReceiver : IEventReceiver
		{
			public int EventCount { get; set; }
			public object Source { get; set; }
			public IEventSubscription Subscription { get; set; }


			#region " Methods "

			public void ReceiveEventNotification(IEventSubscription subscription, object source)
			{
				this.EventCount++;
				this.Source = source;
				this.Subscription = subscription;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingOptionsReturnsNotNullObject()
		{
			var registry = Isolate.Fake.Instance<EventsRegistry>(Members.CallOriginal, ConstructorWillBe.Ignored);

			var options = registry.Options;

			Assert.IsNotNull(options);
			Assert.AreEqual(false, options.QueuePublishedNotifications);
		}

		[TestMethod]
		public void QueuingMultipleNotificationsPushMessagesOnSubscription()
		{
			//Arrange
			var subscribeCriteria = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => subscribeCriteria.EntityType).WillReturn(typeof(TargetEntityClass));
			var publishCriteria1 = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => publishCriteria1.EntityType).WillReturn(typeof(TargetEntityClass));
			var publishCriteria2 = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => publishCriteria2.EntityType).WillReturn(typeof(TargetEntityClass));

			var registry = Isolate.Fake.Instance<EventsRegistry>(Members.CallOriginal, ConstructorWillBe.Ignored);
			registry.Options.QueuePublishedNotifications = true;
			int success = 0;
			registry.Publish(new PublishedEventDetails[] { new PublishedEventDetails(registry, publishCriteria1), new PublishedEventDetails(registry, publishCriteria2) });

			//Act
			registry.Subscribe(subscribeCriteria, (l) => { success++; });

			//Assert
			Assert.AreEqual(2, success);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuedNotificationsPushMessageOnSubscription()
		{
			//Arrange
			var subscribeCriteria = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => subscribeCriteria.EntityType).WillReturn(typeof(TargetEntityClass));
			var publishCriteria = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => publishCriteria.EntityType).WillReturn(typeof(TargetEntityClass));

			var registry = Isolate.Fake.Instance<EventsRegistry>(Members.CallOriginal, ConstructorWillBe.Ignored);
			registry.Options.QueuePublishedNotifications = true;
			bool success = false;
			registry.Publish(new PublishedEventDetails(registry, publishCriteria));

			//Act
			registry.Subscribe(subscribeCriteria, (l) => { success = true; });

			//Assert
			Assert.AreEqual(true, success);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PublishingEntityPushesEntityInstance()
		{
			//Arrange
			var subscribeCriteria = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => subscribeCriteria.EntityType).WillReturn(typeof(TargetEntityClass));
			var publishCriteria = Isolate.Fake.Instance<EntityTypeListenerCriteria>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => publishCriteria.EntityType).WillReturn(typeof(TargetEntityClass));

			var registry = Isolate.Fake.Instance<EventsRegistry>(Members.CallOriginal, ConstructorWillBe.Ignored);
			bool success = false;
			registry.Subscribe(subscribeCriteria, (l) => { success = true; });

			//Act
			registry.Publish(new PublishedEventDetails(registry, publishCriteria));

			//Assert
			Assert.AreEqual(true, success);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PublishingWithNullCriteriaThrowsException()
		{
			//Arrange
			var registry = new EventsRegistry();

			//Act
			

			//Assert
			ExceptionTester.CheckException(true, (s) => { registry.Publish(default(PublishedEventDetails)); });
		}

		[TestMethod]
		public void PublishingWithNullCriterionThrowsException()
		{
			//Arrange
			var registry = new EventsRegistry();

			//Act


			//Assert
			ExceptionTester.CheckException(true, (s) => { registry.Publish(default(IEnumerable<PublishedEventDetails>)); });
		}

		[TestMethod]
		public void SubscribingToListenerAdds()
		{
			//Arrange
			var registry = new EventsRegistry();
			var subscriber = Isolate.Fake.Instance<IEventSubscriber>();

			//Act
			registry.Subscribe(ListenerCriterion.EntityType<TargetEntityClass>(), subscriber);
			registry.Subscribe(ListenerCriterion.EntityType<TargetEntityClass>(), (l) => { });
			
			//Assert
			Assert.AreEqual(2, registry.SubscriptionCount);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SubscribingToMultipleListenerAdds()
		{
			//Arrange
			var registry = new EventsRegistry();
			var subscriber = Isolate.Fake.Instance<IEventSubscriber>();

			//Act
			registry.Subscribe(new SubscriptionEventDetails[]
			{
				new SubscriptionEventDetails(ListenerCriterion.EntityType<TargetEntityClass>(), subscriber),
				new SubscriptionEventDetails(ListenerCriterion.EntityType<TargetEntityClass>(), (l) => { })
			});

			//Assert
			Assert.AreEqual(2, registry.SubscriptionCount);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SubscribingWithNullActionThrowsException()
		{
			//Arrange
			var registry = new EventsRegistry();
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (s) => { registry.Subscribe(criteria, default(Action<PublishedEventDetails>)); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SubscribingWithNullCriteriaThrowsException()
		{
			//Arrange
			var registry = new EventsRegistry();
			var subscriber = Isolate.Fake.Instance<IEventSubscriber>();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (s) => { registry.Subscribe(default(IListenerCriteria), subscriber); });

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void SubscribingWithCriteriasAndNullActionAssignsOK()
		{
			var registry = new EventsRegistry();
			var criteria = new IListenerCriteria[] { };
			
			registry.Subscribe(criteria.AsEnumerable(), default(Action<PublishedEventDetails>));
		}
		
		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void SubscribingWithNullCriteriasAndActionAssignsOK()
		{
			var registry = new EventsRegistry();
			registry.Subscribe(default(IEnumerable<IListenerCriteria>), (p) => { });
		}

		[TestMethod]
		public void SubscribingWithNullSubscribersThrowsException()
		{
			//Arrange
			var registry = new EventsRegistry();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (s) => { registry.Subscribe(default(IEnumerable<SubscriptionEventDetails>)); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SubscribingWithNullSubscriberThrowsException()
		{
			//Arrange
			var registry = new EventsRegistry();
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (s) => { registry.Subscribe(criteria, default(IEventSubscriber)); });

			Isolate.CleanUp();
		}




		//[TestMethod]
		//public void AddingEventListenersForEventsWithNullsThrowsException()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();
		//    var subscriptionFake = Isolate.Fake.Instance<EventSubscription>();

		//    //Act

		//    //Assert
		//    ExceptionTester.CheckException(true, (src) => { registry.AddEventListener(null, new TestReceiver()); });
		//    ExceptionTester.CheckException(true, (src) => { registry.AddEventListener(subscriptionFake, null); });

		//    Isolate.CleanUp();
		//}

		//[TestMethod]
		//public void AddingEventListenersForTypesWithNullsThrowsException()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();

		//    //Act

		//    //Assert
		//    ExceptionTester.CheckException(true, (src) => { registry.AddEventListenerUsing(null, new TestReceiver()); });
		//    ExceptionTester.CheckException(true, (src) => { registry.AddEventListenerUsing(typeof(TestAttributedSubscription), null); });

		//    Isolate.CleanUp();
		//}

		//[TestMethod]
		//public void FiringEventsForEventListenersWithNullsThrowsException()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();
		//    var subscriptionFake = Isolate.Fake.Instance<EventSubscription>();

		//    //Act

		//    //Assert
		//    ExceptionTester.CheckException(true, (src) => { registry.FireEvent(null, new object()); });
		//    ExceptionTester.CheckException(true, (src) => { registry.FireEvent(subscriptionFake, null); });

		//    Isolate.CleanUp();
		//}

		//[TestMethod]
		//public void FiringEventsForTypesWithNullsThrowsException()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();
		//    var subscription = new TestAttributedSubscription();

		//    //Act

		//    //Assert
		//    ExceptionTester.CheckException(true, (src) => { registry.FireEventUsing(null, "Test"); });
		//    ExceptionTester.CheckException(true, (src) => { registry.FireEventUsing(subscription, null); });

		//    Isolate.CleanUp();
		//}

		//[TestMethod]
		//public void SubscribingToObjectsEventThroughReflectionWorksOK()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();
		//    var testSubscription = new TestAttributedSubscription();
		//    var testReceiver = new TestReceiver();

		//    //Act
		//    registry.AddEventListenerUsing(typeof(TestAttributedSubscription), "Test", testReceiver);
		//    registry.FireEventUsing(testSubscription, "Test");

		//    //Assert
		//    Assert.IsNotNull(testReceiver.Subscription);
		//    Assert.IsInstanceOf<TestEventSubscriptionAttribute>(testReceiver.Subscription);
		//    Assert.AreEqual(testSubscription, testReceiver.Source);
		//}

		//[TestMethod]
		//public void SubscribingToObjectsEventWorksOK()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();
		//    var testSubscription = new TestSubscription();
		//    var testReceiver = new TestReceiver();
			
		//    //Act
		//    registry.AddEventListener(TestSubscription.Clicked, testReceiver);
		//    registry.FireEvent(TestSubscription.Clicked, testSubscription);

		//    //Assert
		//    Assert.AreEqual(testSubscription, testReceiver.Source);
		//    Assert.AreEqual(TestSubscription.Clicked, testReceiver.Subscription);
		//}

		//[TestMethod]
		//public void SubscribingToObjectsMultipleEventsWorksOK()
		//{
		//    //Arrange
		//    var registry = new EventsRegistry();
		//    var testSubscription = new TestSubscription();
		//    var testReceiver = new TestReceiver();

		//    //Act
		//    registry.AddEventListener(TestSubscription.Clicked, testReceiver);
		//    registry.AddEventListener(TestSubscription.Changed, testReceiver);
		//    registry.FireEvent(TestSubscription.Clicked, testSubscription);
		//    registry.FireEvent(TestSubscription.Changed, testSubscription);

		//    //Assert
		//    Assert.AreEqual(2, testReceiver.EventCount);
		//    Assert.AreEqual(TestSubscription.Changed, testReceiver.Subscription);
		//}

		#endregion
	}
}
