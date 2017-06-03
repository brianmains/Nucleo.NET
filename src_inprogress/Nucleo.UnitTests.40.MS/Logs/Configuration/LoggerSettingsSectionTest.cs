using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;


namespace Nucleo.Logs.Configuration
{
	[TestClass]
	public class LoggerSettingsSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingLogManagersReturnsCorrectCollection()
		{
			var logManagersFake = new NameTypeElementCollection();
			logManagersFake.Add(new NameTypeElement("First", "FirstType"));
			logManagersFake.Add(new NameTypeElement("Second", "SecondType"));

			var sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.LogManagers).WillReturn(logManagersFake);

			var logManagers = sectionFake.LogManagers;
			Assert.AreEqual(2, logManagers.Count);
			Assert.AreEqual("FirstType", logManagers[0].Type);
			Assert.AreEqual("SecondType", logManagers[1].Type);
		}

		[TestMethod]
		public void CreatingMessageTypesReturnsCorrectCollection()
		{
			var messageTypesFake = new LogMessageTypeElementCollection();
			messageTypesFake.Add(new LogMessageTypeElement("First", 1));
			messageTypesFake.Add(new LogMessageTypeElement("Second", 2));

			var sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.MessageTypes).WillReturn(messageTypesFake);

			var messageTypes = sectionFake.MessageTypes;
			Assert.AreEqual(2, messageTypes.Count);
			Assert.AreEqual(1, messageTypes[0].Value);
			Assert.AreEqual(2, messageTypes[1].Value);
		}

		[TestMethod]
		public void CreatingVerbosityTypesReturnsCorrectCollection()
		{
			var verbosityTypesFake = new LogVerbosityTypeElementCollection();
			verbosityTypesFake.Add(new LogVerbosityTypeElement("First", 1));
			verbosityTypesFake.Add(new LogVerbosityTypeElement("Second", 2));

			var sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.VerbosityTypes).WillReturn(verbosityTypesFake);

			var verbosityTypes = sectionFake.VerbosityTypes;
			Assert.AreEqual(2, verbosityTypes.Count);
			Assert.AreEqual(1, verbosityTypes[0].Level);
			Assert.AreEqual(2, verbosityTypes[1].Level);
		}

		[TestMethod]
		public void GettingAndSettingCurrentVerbosityAssignsCorrectly()
		{
			LoggerSettingsSection section = new LoggerSettingsSection();
			section.CurrentVerbosityName = "Verbose";
			Assert.AreEqual("Verbose", section.CurrentVerbosityName);
		}

		#endregion
	}
}
