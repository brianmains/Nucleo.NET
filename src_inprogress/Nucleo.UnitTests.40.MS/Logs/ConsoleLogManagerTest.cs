using System;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class ConsoleLogManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void LoggingErrorsLogsToConsole()
		{
			//Arrange
			using (StringWriter writer = new StringWriter())
			{
				Console.SetOut(writer);

				var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
				var verbosityTypeFake = Isolate.Fake.Instance<LogVerbosityType>();

				//Act
				ConsoleLogManager manager = new ConsoleLogManager();
				manager.LogError(new Exception("Test Error Message"), "My Source", messageTypeFake, verbosityTypeFake);

				//Assert
				var output = writer.ToString();
				Assert.IsTrue(output.StartsWith("My Source:"));
				Assert.IsTrue(output.Contains("Test Error Message"));
			}
			
			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoggingMessagesLogsToConsole()
		{
			//Arrange
			using (StringWriter writer = new StringWriter())
			{
				Console.SetOut(writer);

				var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
				var verbosityTypeFake = Isolate.Fake.Instance<LogVerbosityType>();

				//Act
				ConsoleLogManager manager = new ConsoleLogManager();
				manager.LogMessage("My Message", "My Source", messageTypeFake, verbosityTypeFake);

				//Assert
				var output = writer.ToString();
				Assert.IsTrue(output.StartsWith("My Source:"));
				Assert.IsTrue(output.Contains("My Message"));
			}

			Isolate.CleanUp();
		}

		#endregion
	}
}
