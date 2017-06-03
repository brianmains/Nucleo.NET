using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Logs;


namespace Nucleo.Web.Logs
{
	[TestClass]
	public class HealthMonitoringLogManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void LoggingErrorWithHealthMonitoringPassesInfoToErrorEvent()
		{
			//Arrange
			var errorFake = Isolate.Fake.Instance<LoggerErrorEvent>();
			Isolate.WhenCalled(() => errorFake.EventCode).WillReturn(10000);
			Isolate.WhenCalled(() => errorFake.Message).WillReturn("Test");
			Isolate.WhenCalled(() => errorFake.EventSource).WillReturn("TestSource");

			Isolate.WhenCalled(() => LoggerErrorEvent.Raise(null, null)).WillReturn(errorFake);

			var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityTypeFake = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			var manager = new HealthMonitoringLogManager();
			manager.LogError(new Exception("ex"), "TestSource", messageTypeFake, verbosityTypeFake);

			//Assert

			Isolate.CleanUp();
		}

		#endregion
	}
}
