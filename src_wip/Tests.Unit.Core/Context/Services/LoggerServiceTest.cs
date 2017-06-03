using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Logs;


namespace Nucleo.Context.Services
{
	[TestClass]
	public class LoggerServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingMessageTypesReturnsLoggerValues()
		{
			//Arrange
			var loggerFake = Isolate.Fake.Instance<Logger>();
			Isolate.WhenCalled(() => Logger.Create()).WillReturn(loggerFake);
			Isolate.WhenCalled(() => loggerFake.GetMessageTypes()).WillReturn(
				new LogMessageTypeCollection
				{
					new LogMessageType("Information", 0),
					new LogMessageType("Warning", 64),
					new LogMessageType("Severe Warning", 128),
					new LogMessageType("Error", 200),
					new LogMessageType("Severe Error", 255)
				});
			
			//Act
			var messages = loggerFake.GetMessageTypes();

			//Assert
			Assert.AreEqual(5, messages.Count);
			Assert.AreEqual("Severe Warning", messages[2].Name);
			Assert.AreEqual(128, messages[2].Value);
			Assert.AreEqual("Severe Error", messages[4].Name);
			Assert.AreEqual(255, messages[4].Value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingVebosityTypesReturnsLoggerValues()
		{
			//Arrange
			var loggerFake = Isolate.Fake.Instance<Logger>();
			Isolate.WhenCalled(() => Logger.Create()).WillReturn(loggerFake);
			Isolate.WhenCalled(() => loggerFake.GetVerbosityTypes()).WillReturn(
				new LogVerbosityTypeCollection
				{
					new LogVerbosityType("Information", 0),
					new LogVerbosityType("Warning", 64),
					new LogVerbosityType("Severe Warning", 128),
					new LogVerbosityType("Error", 200),
					new LogVerbosityType("Severe Error", 255)
				});

			//Act
			var verbosities = loggerFake.GetVerbosityTypes();

			//Assert
			Assert.AreEqual(5, verbosities.Count);
			Assert.AreEqual("Severe Warning", verbosities[2].Name);
			Assert.AreEqual(128, verbosities[2].Level);
			Assert.AreEqual("Severe Error", verbosities[4].Name);
			Assert.AreEqual(255, verbosities[4].Level);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingErrorLogsValidMessage()
		{
			//Arrange
			var loggerFake = Isolate.Fake.Instance<Logger>();
			Isolate.WhenCalled(() => Logger.Create()).WillReturn(loggerFake);
			Isolate.WhenCalled(() => loggerFake.LogError(null, null, null, null)).IgnoreCall();
			var messageFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityFake = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			loggerFake.LogError(new Exception(), "Test", messageFake, verbosityFake);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => loggerFake.LogError(null, null, null, null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessagesLogsValidMessage()
		{
			//Arrange
			var loggerFake = Isolate.Fake.Instance<Logger>();
			Isolate.WhenCalled(() => Logger.Create()).WillReturn(loggerFake);
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).IgnoreCall();
			var messageFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityFake = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			loggerFake.LogMessage("Message", "Test", messageFake, verbosityFake);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => loggerFake.LogMessage(null, null, null, null));

			Isolate.CleanUp();
		}

		#endregion
	}
}
