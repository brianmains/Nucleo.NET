using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class LoggerTextWriterTest
	{
		#region " Properties "

		[TestMethod]
		public void CreatingWriterWithSourceAndMessageTypeWorksOK()
		{
			//Arrange
			var message = Isolate.Fake.Instance<LogMessageType>();
			var writer = default(LoggerTextWriter);

			//Act
			writer = new LoggerTextWriter("Test", message);

			//Assert
			Assert.AreEqual("Test", writer.Source);
			Assert.AreEqual(message.Value, writer.MessageType.Value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWriterWithSourceMessageTypeAndVerbosityTypeWorksOK()
		{
			//Arrange
			var message = Isolate.Fake.Instance<LogMessageType>();
			var verbosity = Isolate.Fake.Instance<LogVerbosityType>();
			var writer = default(LoggerTextWriter);

			//Act
			writer = new LoggerTextWriter("Test", message, verbosity);

			//Assert
			Assert.AreEqual("Test", writer.Source);
			Assert.AreEqual(message.Value, writer.MessageType.Value);
			Assert.AreEqual(verbosity.Level, writer.VerbosityType.Level);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void WritingStringContentLogsToLogger()
		{
			//Arrange
			var writer = Isolate.Fake.Instance<LoggerTextWriter>(Members.CallOriginal);
			var loggerFake = Isolate.Fake.Instance<Logger>(Members.CallOriginal);
			Isolate.WhenCalled(() => loggerFake.LogMessage(null, null, null, null)).IgnoreCall();
			
			Isolate.Fake.StaticMethods(typeof(Logger));
			Isolate.WhenCalled(() => Logger.Create()).WillReturn(loggerFake);

			//Act
			writer.Write("This is my statement");
			writer.Write("This is my statement");
			writer.Flush();

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => loggerFake.LogMessage(null, null, null, null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void WritingStringContentWorksOK()
		{
			//Arrange
			var writer = Isolate.Fake.Instance<LoggerTextWriter>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(writer, "WriteContent").IgnoreCall();

			//Act
			writer.Write("This is my statement");
			writer.Write("This is my statement");

			string content = writer.FlushContent();
			
			//Assert
			Assert.AreEqual("This is my statementThis is my statement", content);

			Isolate.CleanUp();
		}

		#endregion
	}
}
