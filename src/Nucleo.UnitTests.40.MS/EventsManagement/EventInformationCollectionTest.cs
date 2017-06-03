using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventInformationCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingEventsByNameReturnsCorrectEvents()
		{
			//Arrange
			var events = new EventInformationCollection
			{
				new EventInformation("Test", "Test Loc", null, null, 0, DateTime.Now, DateTime.Now.AddHours(1)),
				new EventInformation("Test 2", "Test Loc", null, null, 0, DateTime.Now, DateTime.Now.AddHours(1))
			};

			//Act
			var foundEvent = events.GetEventByName("Test");

			//Assert
			Assert.AreEqual("Test Loc", foundEvent.Location);
		}

		#endregion
	}
}
