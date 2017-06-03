using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;
using Nucleo.EventsManagement.Configuration;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventsScheduleTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingEventsWorksOK()
		{
			//Arrange
			var provider = new FakeEventScheduleProvider();
			var schedule = EventsSchedule.Create(provider);

			//Act
			schedule.AddEvent(new EventInformation
			{
				ID = Identifier.Create(4),
				Name = "Test",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 5, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 5, 10, 0, 0)
			});
			schedule.AddEvent(new EventInformation
			{
				ID = Identifier.Create(5),
				Name = "That this",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 6, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 6, 10, 0, 0)
			});
			schedule.AddEvent(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "Works",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 7, 10, 0, 0)
			});

			//Assert
			Assert.AreEqual(3, provider.Events.Count);
			Assert.AreEqual("Test", provider.Events[0].Name);
			Assert.AreEqual("Works", provider.Events[2].Name);
		}

		[TestMethod]
		public void DeletingEventsWorksOK()
		{
			//Arrange
			var provider = new FakeEventScheduleProvider();
			var schedule = EventsSchedule.Create(provider);

			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(4),
				Name = "Test",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 5, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 5, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(5),
				Name = "That this",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 6, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 6, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "Works",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 7, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "NotFound",
				Location = "Here",
				BeginDate = new DateTime(2010, 5, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 5, 7, 10, 0, 0)
			});

			var deleteEvent = provider.Events[1];

			//Act
			schedule.DeleteEvent(deleteEvent);

			//Assert
			Assert.AreEqual(3, provider.Events.Count);
			Assert.AreEqual("Works", provider.Events[1].Name);
		}

		[TestMethod]
		public void GettingEventsForADayWorksOK()
		{
			//Arrange
			var provider = new FakeEventScheduleProvider();
			var schedule = EventsSchedule.Create(provider);

			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(4),
				Name = "Test",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 5, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 5, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(5),
				Name = "That this",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 6, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 6, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "Works",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 7, 10, 0, 0)
			});

			//Act
			var events = schedule.GetEventsForDay(new DateTime(2010, 4, 7));
			Assert.AreEqual(1, events.Count);
			Assert.AreEqual("Works", events[0].Name);
		}

		[TestMethod]
		public void GettingEventsForAMonthWorksOK()
		{
			//Arrange
			var provider = new FakeEventScheduleProvider();
			var schedule = EventsSchedule.Create(provider);

			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(4),
				Name = "Test",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 5, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 5, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(5),
				Name = "That this",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 6, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 6, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "Works",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 7, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "NotFound",
				Location = "Here",
				BeginDate = new DateTime(2010, 5, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 5, 7, 10, 0, 0)
			});

			//Act
			var events = schedule.GetEventsForMonth(2010, 4);

			//Assert
			Assert.AreEqual(3, events.Count);
			Assert.AreEqual("Test", events[0].Name);
			Assert.AreEqual("That this", events[1].Name);
			Assert.AreEqual("Works", events[2].Name);
		}

		[TestMethod]
		public void GettingEventsWithARangeWorksOK()
		{
			//Arrange
			var provider = new FakeEventScheduleProvider();
			var schedule = EventsSchedule.Create(provider);

			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(4),
				Name = "Test",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 5, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 5, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(5),
				Name = "That this",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 6, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 6, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "Works",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 7, 10, 0, 0)
			});

			//Act
			var events = schedule.GetEventsForRange(new DateTime(2010, 4, 6), new DateTime(2010, 4, 7, 11, 59, 59));
			Assert.AreEqual(2, events.Count);
			Assert.AreEqual("Works", events[1].Name);
		}

		[TestMethod]
		public void PullingProviderFromConfig()
		{
			//Arrange
			var section = new EventsScheduleSection();
			section.DefaultProvider = "Nucleo.EventsManagement.FakeEventScheduleProvider," + typeof(FakeEventScheduleProvider).Assembly.FullName;

			Isolate.WhenCalled(() => EventsScheduleSection.Instance).WillReturn(section);

			//Act
			var schedule = EventsSchedule.Create();

			//Assert
			Assert.IsInstanceOfType(schedule.NonPublic().Property("DefaultProvider").GetValue(), typeof(FakeEventScheduleProvider));
		}

		[TestMethod]
		public void UpdatingEventWorksOK()
		{
			//Arrange
			var provider = new FakeEventScheduleProvider();
			var schedule = EventsSchedule.Create(provider);

			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(4),
				Name = "Test",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 5, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 5, 10, 0, 0)
			});
			provider.Events.Add(new EventInformation
			{
				ID = Identifier.Create(5),
				Name = "That this",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 6, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 6, 10, 0, 0)
			});

			var updateEvent = new EventInformation
			{
				ID = Identifier.Create(6),
				Name = "Works",
				Location = "Here",
				BeginDate = new DateTime(2010, 4, 7, 9, 0, 0),
				EndDate = new DateTime(2010, 4, 7, 10, 0, 0)
			};
			provider.Events.Add(updateEvent);

			updateEvent.Url = new Uri("http://www.yahoo.com");

			//Act
			schedule.UpdateEvent(updateEvent);

			//Assert
			Assert.AreEqual("http://www.yahoo.com/", updateEvent.Url.ToString());
		}

		#endregion
	}
}
