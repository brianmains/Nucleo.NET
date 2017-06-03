using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.Logs.Configuration;



namespace Nucleo.Logs
{
	[TestClass]
	public class LoggerTest
	{
		#region " Tests "

		[TestMethod]
		public void AttachingLoggersToComponentAddsLoggersToCollection()
		{
			var logCollectionFake = Isolate.Fake.Instance<LogManagerCollection>();
			Isolate.Swap.NextInstance<LogManagerCollection>().With(logCollectionFake);
			Isolate.WhenCalled(() => logCollectionFake.Add(null)).IgnoreCall();

			var loggerFake = Isolate.Fake.Instance<Logger>();
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").CallOriginal();
			Isolate.WhenCalled(() => loggerFake.RegisterLogManager(null)).CallOriginal();

			var fakeManager = Isolate.Fake.Instance<FakeLogManager>();

			loggerFake.RegisterLogManager(fakeManager);

			Isolate.Verify.WasCalledWithAnyArguments(() => logCollectionFake.Add(fakeManager));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerWithNoConfigThrowsException()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(null);

			//Act


			//Assert
			ExceptionTester.CheckException(true, (s) => { Logger.Create(); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerWithCurrentVerbosityInConfigButWithMismatchedNameThrowsException()
		{
			var verbosityTypeElements = new LogVerbosityTypeElementCollection();
			verbosityTypeElements.Add(new LogVerbosityTypeElement { Name = "Third", Level = 3 });
			verbosityTypeElements.Add(new LogVerbosityTypeElement { Name = "Fourth", Level = 4 });

			LoggerSettingsSection sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.VerbosityTypes).WillReturn(verbosityTypeElements);
			Isolate.WhenCalled(() => sectionFake.CurrentVerbosityName).WillReturn("Fifth");

			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(sectionFake);

			//Assert
			try
			{
				Logger.Create();
				Assert.Fail("Creating logger with invalid params didn't throw exception");
			}
			catch (ArgumentException ex)
			{
				StringAssert.Contains(ex.Message, "The current verbosity setting does not match an item in the list.");
				Assert.AreEqual("CurrentVerbosityName", ex.ParamName, "Param name doesn't match");
			}

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerWithCurrentVerbosityInConfigEstablishesSetting()
		{
			var verbosityTypeElements = new LogVerbosityTypeElementCollection();
			verbosityTypeElements.Add(new LogVerbosityTypeElement { Name = "Third", Level = 3 });
			verbosityTypeElements.Add(new LogVerbosityTypeElement { Name = "Fourth", Level = 4 });

			LoggerSettingsSection sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.VerbosityTypes).WillReturn(verbosityTypeElements);
			Isolate.WhenCalled(() => sectionFake.CurrentVerbosityName).WillReturn("Fourth");

			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(sectionFake);

			//Act
			Logger logger = Logger.Create();

			//Assert
			Assert.AreEqual("Fourth", logger.CurrentVerbosity.Name);
			Assert.AreEqual(4, logger.CurrentVerbosity.Level);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerWithLogManagersInstantiatesCorrectNumberOfLogs()
		{
			var logManagerElements = new NameTypeElementCollection();
			logManagerElements.Add(new NameTypeElement { Name = "First", Type = "FirstType" });
			logManagerElements.Add(new NameTypeElement { Name = "Second", Type = "SecondType" });
			logManagerElements.Add(new NameTypeElement { Name = "Third", Type = "ThirdType" });

			LoggerSettingsSection sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.LogManagers).WillReturn(logManagerElements);

			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(sectionFake);

			//Act
			Isolate.NonPublic.WhenCalled(typeof(Logger), "CreateLogManagerInstance").WillReturn(new FakeLogManager());
			Logger logger = Logger.Create();

			var logManagers = logger.GetLogManagers();

			//Assert
			Assert.AreEqual(3, logManagers.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerWithMessageTypesReturnsLoggerWithMessageTypes()
		{
			var messageTypeElements = new LogMessageTypeElementCollection();
			messageTypeElements.Add(new LogMessageTypeElement { Name = "First", Value = 1 });
			messageTypeElements.Add(new LogMessageTypeElement { Name = "Second", Value = 2 });

			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			LoggerSettingsSection sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();	
			Isolate.WhenCalled(() => sectionFake.MessageTypes).WillReturn(messageTypeElements);
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(sectionFake);

			Logger logger = Logger.Create();

			var messageTypes = logger.GetMessageTypes();
			Assert.AreEqual(5, messageTypes.Count);
			Assert.AreEqual("First", messageTypes[3].Name);
			Assert.AreEqual("Second", messageTypes[4].Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerReturnsDefaultMessageTypes()
		{
			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(null);

			Logger logger = Logger.Create(new LoggerOptions());

			var messageTypes = logger.GetMessageTypes();
			Assert.AreEqual(3, messageTypes.Count);

			Assert.AreEqual("Information", messageTypes[0].Name);
			Assert.AreEqual(0, messageTypes[0].Value);

			Assert.AreEqual("Warning", messageTypes[1].Name);
			Assert.AreEqual(127, messageTypes[1].Value);

			Assert.AreEqual("Error", messageTypes[2].Name);
			Assert.AreEqual(255, messageTypes[2].Value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerReturnsDefaultVerbosity()
		{
			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(null);

			Logger logger = Logger.Create(new LoggerOptions());

			var verbosityTypes = logger.GetVerbosityTypes();
			Assert.AreEqual(3, verbosityTypes.Count);

			Assert.AreEqual("Minimal", verbosityTypes[0].Name);
			Assert.AreEqual(0, verbosityTypes[0].Level);

			Assert.AreEqual("Normal", verbosityTypes[1].Name);
			Assert.AreEqual(127, verbosityTypes[1].Level);

			Assert.AreEqual("Verbose", verbosityTypes[2].Name);
			Assert.AreEqual(255, verbosityTypes[2].Level);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingLoggerWithVerbosityTypesReturnsLoggerWithVerbosityTypes()
		{
			var verbosityTypeElements = new LogVerbosityTypeElementCollection();
			verbosityTypeElements.Add(new LogVerbosityTypeElement { Name = "Third", Level = 3 });
			verbosityTypeElements.Add(new LogVerbosityTypeElement { Name = "Fourth", Level = 4 });

			Isolate.Fake.StaticMethods(typeof(LoggerSettingsSection));
			LoggerSettingsSection sectionFake = Isolate.Fake.Instance<LoggerSettingsSection>();
			Isolate.WhenCalled(() => sectionFake.VerbosityTypes).WillReturn(verbosityTypeElements);
			Isolate.WhenCalled(() => LoggerSettingsSection.Instance).WillReturn(sectionFake);

			Logger logger = Logger.Create();

			var verbosityTypes = logger.GetVerbosityTypes();
			Assert.AreEqual(5, verbosityTypes.Count);
			Assert.AreEqual("Third", verbosityTypes[3].Name);
			Assert.AreEqual("Fourth", verbosityTypes[4].Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingDetailsOfObjectLogsCorrectInformation()
		{
			//Arrange
			var fakeManager = new FakeLogManager();
			var objectToLog = new LogVerbosityType("Test", 100);

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });

			var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityFake = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			loggerFake.LogObjectDetails(objectToLog, "Test", messageTypeFake, verbosityFake);
			var objectDetails = string.Format("{0}: {1}={2}, {3}={4}", objectToLog.GetType().FullName,
				"Level", objectToLog.Level, "Name", objectToLog.Name);

			//Assert
			var entries = fakeManager.GetEntries();
			Assert.AreEqual(1, entries.Count);
			Assert.AreEqual(objectDetails, entries[0].Message);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingExceptionsToLoggerCallsLogMethodsInAllLogs()
		{
			//Arrange
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogError(null, null, null, null)).CallOriginal();

			var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityFake = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			loggerFake.LogError(new Exception("Test"), "App", messageTypeFake, verbosityFake);

			//Assert
			var entries = fakeManager.GetEntries();
			Assert.AreEqual(1, entries.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessageToLoggerCallsLogMethodsInAllLogs()
		{
			//Arrange
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).CallOriginal();

			var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityFake = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			loggerFake.LogMessage("Test", "App", messageTypeFake, verbosityFake);

			//Assert
			var entries = fakeManager.GetEntries();
			Assert.AreEqual(1, entries.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessageWithCurrentVerbosityEqualsMessageVerbosityAt0DoesLogMessage()
		{
			//Arrange
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).CallOriginal();
			Isolate.WhenCalled(() => loggerFake.CurrentVerbosity).WillReturn(new LogVerbosityType("Verbose", 0));

			//Act
			var messageType = new LogMessageType("Information", 1);

			loggerFake.LogMessage("Test Message", "App", messageType,
				new LogVerbosityType("Verbose", 0));
			loggerFake.LogMessage("Test Message2", "App2", messageType,
				new LogVerbosityType("Verbose", 0));

			//Assert
			Assert.AreEqual(2, fakeManager.GetEntries().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessageWithCurrentVerbosityEqualsMessageVerbosityAt127DoesLogMessage()
		{
			//Arrange
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).CallOriginal();
			Isolate.WhenCalled(() => loggerFake.CurrentVerbosity).WillReturn(new LogVerbosityType("Verbose", 127));

			//Act
			var messageType = new LogMessageType("Information", 1);

			loggerFake.LogMessage("Test Message", "App", messageType,
				new LogVerbosityType("Verbose", 127));
			loggerFake.LogMessage("Test Message2", "App2", messageType,
				new LogVerbosityType("Verbose", 127));

			//Assert
			Assert.AreEqual(2, fakeManager.GetEntries().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessageWithCurrentVerbosityEqualsMessageVerbosityAt255DoesLogMessage()
		{
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).CallOriginal();
			Isolate.WhenCalled(() => loggerFake.CurrentVerbosity).WillReturn(new LogVerbosityType("Verbose", 255));

			var messageType = new LogMessageType("Information", 1);

			loggerFake.LogMessage("Test Message", "App", messageType, 
				new LogVerbosityType("Verbose", 255));
			loggerFake.LogMessage("Test Message2", "App2", messageType,
				new LogVerbosityType("Verbose", 255));

			//Assert
			Assert.AreEqual(2, fakeManager.GetEntries().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessageWithCurrentVerbosityGreaterThanMessageVerbosityDoesLogMessage()
		{
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).CallOriginal();
			Isolate.WhenCalled(() => loggerFake.CurrentVerbosity).WillReturn(new LogVerbosityType("Verbose", 255));

			var messageType = new LogMessageType("Information", 1);

			loggerFake.LogMessage("Test Message", "App", messageType, 
				new LogVerbosityType("Normal", 127));

			loggerFake.LogMessage("Test Message", "App", messageType, 
				new LogVerbosityType("Normal", 200));

			loggerFake.LogMessage("Test Message", "App", messageType,
				new LogVerbosityType("Normal", 254));

			Assert.AreEqual(3, fakeManager.GetEntries().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessageWithCurrentVerbosityLessThanMessageVerbosityDoesntLogMessage()
		{
			var fakeManager = new FakeLogManager();

			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(loggerFake, "Logs").WillReturn(
				new LogManagerCollection { fakeManager });
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).CallOriginal();
			Isolate.WhenCalled(() => loggerFake.CurrentVerbosity).WillReturn(new LogVerbosityType("Normal", 127));

			var messageType = new LogMessageType("Information", 1);

			loggerFake.LogMessage("Test Message", "App", messageType, 
				new LogVerbosityType("Verbose", 255));

			loggerFake.LogMessage("Test Message", "App", messageType,
				new LogVerbosityType("Verbose", 175));

			loggerFake.LogMessage("Test Message", "App", messageType,
				new LogVerbosityType("Verbose", 128));

			Assert.AreEqual(0, fakeManager.GetEntries().Count);

			Isolate.CleanUp();
		}

		#endregion
	}
}
