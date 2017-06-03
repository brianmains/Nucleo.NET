using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.Newsletters.Configuration;
using Nucleo.Reflection;
using Nucleo.TestingTools;


namespace Nucleo.Newsletters
{
	[TestClass]
	public class NewsletterManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingNewsletterWorksOK()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			managerFake.AddNewsletter("Test", "My Test newsletter");

			//Assert
			Assert.AreEqual(1, fakeProvider.Newsletters.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void AddingSubscriptionWorksOK()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("Test", new NewsletterInformation("Test", "Test Desc"), new List<string>());

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			managerFake.AddSubscription("jtest@test.com", "Test");

			//Assert
			Assert.AreEqual(1, fakeProvider.Newsletters["Test"].Value2.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForNewsletterExistenceReturnsCorrectValue()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("Test", new NewsletterInformation("Test", "Test Desc"), new List<string>());

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			var val1 = managerFake.NewsletterExists("Test");
			var val2 = managerFake.NewsletterExists("3");

			//Assert
			Assert.IsTrue(val1);
			Assert.IsFalse(val2);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForSubscriptionExistenceWorksOK()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string> { "test@test.com" });
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string> { "a@a.com", "info@info.com" });
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string> { "test@test.com", "info@info.com" });
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string> { "a@a.com" });

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			bool val1 = managerFake.SubscriptionExists("info@info.com", "2");
			bool val2 = managerFake.SubscriptionExists("test@test.com", "1");
			bool val3 = managerFake.SubscriptionExists("test@test.com", "2");
			bool val4 = managerFake.SubscriptionExists("info@info.com", "4");

			//Assert
			Assert.IsTrue(val1);
			Assert.IsTrue(val2);
			Assert.IsFalse(val3);
			Assert.IsFalse(val4);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingManagerAssignsDefaultProvider()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			
			//Act
			var manager = NewsletterManager.Create(fakeProvider);

			//Assert
			Assert.IsInstanceOfType(manager.NonPublic().Property("DefaultProvider").GetValue(), typeof(FakeNewsletterProvider));
		}

		[TestMethod]
		public void CreatingManagerFromConfigAssignsDefaultProvider()
		{
			//Arrange
			var section = new NewsletterSection();
			section.DefaultProvider = "Nucleo.Newsletters.FakeNewsletterProvider," + typeof(FakeNewsletterProvider).Assembly.FullName;

			Isolate.Fake.StaticMethods(typeof(NewsletterSection));
			Isolate.WhenCalled(() => NewsletterSection.Instance).WillReturn(section);

			//Act
			var manager = NewsletterManager.Create();

			//Assert
			Assert.IsInstanceOfType(manager.NonPublic().Property("DefaultProvider").GetValue(), typeof(FakeNewsletterProvider));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingManagerFromMissingConfigThrowsException()
		{
			//Arrange
			Isolate.WhenCalled(() => NewsletterSection.Instance).WillReturn(null);


			//Assert
			ExceptionTester.CheckException(true, (src) => { NewsletterManager.Create(); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingManagerWithNullProvider()
		{
			//Arrange

			//Assert
			ExceptionTester.CheckException(true, (src) => { NewsletterManager.Create(null); });
		}

		[TestMethod]
		public void GettingAllNewslettersReturnsNewsletterInformation()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string>());
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string>());
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string>());
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string>());

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			var newsletters = managerFake.GetAllNewsletters();

			//Assert
			Assert.AreEqual("1", newsletters[0].Name);
			Assert.AreEqual("1d", newsletters[0].Description);
			Assert.AreEqual("2", newsletters[1].Name);
			Assert.AreEqual("3d", newsletters[2].Description);
			Assert.AreEqual("4", newsletters[3].Name);
			Assert.AreEqual("4d", newsletters[3].Description);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingNewslettersForSubscriberReturnsOnlySubscribersInformation()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string> { "test@test.com" });
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string> { "a@a.com", "info@info.com" });
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string> { "test@test.com", "info@info.com" });
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string> { "a@a.com" });

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			var subscribers1 = managerFake.GetNewslettersForSubscriber("test@test.com");
			var subscribers2 = managerFake.GetNewslettersForSubscriber("info@info.com" );

			//Assert
			Assert.AreEqual(2, subscribers1.Count);
			Assert.AreEqual(2, subscribers2.Count);
			Assert.AreEqual("1", subscribers1[0].Name);
			Assert.AreEqual("3", subscribers1[1].Name);
			Assert.AreEqual("2", subscribers2[0].Name);
			Assert.AreEqual("3", subscribers2[1].Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingSubscribersForNewsletterReturnsOnlyThoseSubscribers()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string> { "test@test.com" });
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string> { "a@a.com", "info@info.com" });
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string> { "test@test.com", "info@info.com" });
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string> { "a@a.com" });

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			var subscribers1 = managerFake.GetSubscribers("3");
			var subscribers2 = managerFake.GetSubscribers("1");

			//Assert
			Assert.AreEqual(2, subscribers1.Length);
			Assert.AreEqual(1, subscribers2.Length);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingAllSubscriptionsWorksOK()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string> { "test@test.com" });
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string> { "a@a.com", "info@info.com" });
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string> { "test@test.com", "info@info.com" });
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string> { "a@a.com" });

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			managerFake.RemoveAllSubscriptions("test@test.com");

			//Assert
			Assert.IsTrue(fakeProvider.Newsletters.IsAllTrue(i => !i.Value2.Contains("test@test.com")), "test@test.com still exists");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingNewsletterWorksOK()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string> { "test@test.com" });
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string> { "a@a.com", "info@info.com" });
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string> { "test@test.com", "info@info.com" });
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string> { "a@a.com" });

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			managerFake.RemoveNewsletter("4");
			managerFake.RemoveNewsletter("1");

			//Assert
			Assert.AreEqual(2, fakeProvider.Newsletters.Count);
			Assert.IsTrue(fakeProvider.Newsletters.IsAllTrue(i => i.Key != "1"));
			Assert.IsTrue(fakeProvider.Newsletters.IsAllTrue(i => i.Key != "4"));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingSubscriptionWorksOK()
		{
			//Arrange
			var fakeProvider = new FakeNewsletterProvider();
			fakeProvider.Newsletters.Add("1", new NewsletterInformation("1", "1d"), new List<string> { "test@test.com" });
			fakeProvider.Newsletters.Add("2", new NewsletterInformation("2", "2d"), new List<string> { "a@a.com", "info@info.com" });
			fakeProvider.Newsletters.Add("3", new NewsletterInformation("3", "3d"), new List<string> { "test@test.com", "info@info.com" });
			fakeProvider.Newsletters.Add("4", new NewsletterInformation("4", "4d"), new List<string> { "a@a.com" });

			var managerFake = Isolate.Fake.Instance<NewsletterManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "DefaultProvider").WillReturn(fakeProvider);

			//Act
			managerFake.RemoveSubscription("test@test.com", "1");

			//Assert
			Assert.IsFalse(fakeProvider.Newsletters["1"].Value2.Contains("test@test.com"));

			Isolate.CleanUp();
		}

		#endregion
	}
}
