using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock;


namespace Nucleo.EventsManagement.Configuration
{
	[TestClass]
	public class EventsScheduleSectionTest
	{
		[TestMethod]
		public void ScheduleConfiguration()
		{
			ProviderSettingsCollection providers = new ProviderSettingsCollection();
			

			EventsScheduleSection section = new EventsScheduleSection();
			section.DefaultProvider = "Database";

			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				recorder.ExpectAndReturn(EventsScheduleSection.Instance, section).RepeatAlways();
			}

			Assert.IsNotNull(EventsScheduleSection.Instance);
			Assert.AreEqual("Database", EventsScheduleSection.Instance.DefaultProvider);
		}
	}
}
