using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventInformationTest
	{
		[TestMethod]
		public void TestCreatingObjectWithFinalConstructorWorksOK()
		{
			//Arrange
			EventInformation info = default(EventInformation);

			//Act
			info = new EventInformation(Identifier.Create(1), "My Event", "West Shore", "My test event", new Uri("http://www.becominglikejesus.org"), 50, false, new DateTime(2007, 1, 1), new DateTime(2007, 1, 20));

			//Act
			Assert.AreEqual(1, info.ID.Get<int>());
			Assert.AreEqual("My Event", info.Name);
			Assert.AreEqual("West Shore", info.Location);
			Assert.AreEqual("My test event", info.Description);
			Assert.AreEqual("http://www.becominglikejesus.org/", info.Url.ToString());
			Assert.AreEqual(50, info.MaximumRegistration);
			Assert.AreEqual(false, info.IsCancelled);
			Assert.AreEqual(new DateTime(2007, 1, 1), info.BeginDate);
			Assert.AreEqual(new DateTime(2007, 1, 20), info.EndDate);
			Assert.AreEqual(false, info.IsCancelled);
		}

		[TestMethod]
		public void TestCreatingObjectWithMiddleConstructorWorksOK()
		{
			//Arrange
			EventInformation info = default(EventInformation);

			//Act
			info = new EventInformation("My Event", "West Shore", "My test event", new Uri("http://www.becominglikejesus.org"), 50, new DateTime(2007, 1, 1), new DateTime(2007, 1, 20));

			//Act
			Assert.AreEqual("My Event", info.Name);
			Assert.AreEqual("West Shore", info.Location);
			Assert.AreEqual("My test event", info.Description);
			Assert.AreEqual("http://www.becominglikejesus.org/", info.Url.ToString());
			Assert.AreEqual(50, info.MaximumRegistration);
			Assert.AreEqual(false, info.IsCancelled);
			Assert.AreEqual(new DateTime(2007, 1, 1), info.BeginDate);
			Assert.AreEqual(new DateTime(2007, 1, 20), info.EndDate);
		}
	}
}