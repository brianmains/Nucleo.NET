using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class SubscriptionEventDetailsTest
	{
		#region " Test Classes "

		protected class TestEventSubscriber : IEventSubscriber
		{
			public void Receive(PublishedEventDetails eventDetails)
			{
				throw new NotImplementedException();
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingWithActionWorksOK()
		{
			//Arrange
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();

			//Act
			var sed = new SubscriptionEventDetails(criteria, (s) => { });

			//Assert
			Assert.AreEqual(criteria, sed.Criteria);
			Assert.IsNotNull(sed.Action);
		}

		[TestMethod]
		public void CreatingWithEventSubscriptionWorksOK()
		{
			//Arrange
			var subscriber = new TestEventSubscriber();
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();

			//Act
			var sed = new SubscriptionEventDetails(criteria, subscriber);

			//Assert
			Assert.AreEqual(criteria, sed.Criteria);
			Assert.AreEqual(subscriber, sed.Receiver);
		}

		#endregion
	}
}
