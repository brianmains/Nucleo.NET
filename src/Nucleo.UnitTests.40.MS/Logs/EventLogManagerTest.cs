using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class EventLogManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void LoggingErrorsLogsErrorsToInternalMethod()
		{
			var managerFake = Isolate.Fake.Instance<EventLogManager>();
			Isolate.WhenCalled(() => managerFake.LogError(null, null, null, null)).CallOriginal();
			Isolate.NonPublic.WhenCalled(managerFake, "WriteToEventLog").IgnoreCall();

			var messageTypeFake = Isolate.Fake.Instance<LogMessageType>();
			var verbosityFake = Isolate.Fake.Instance<LogVerbosityType>();

			managerFake.LogError(new Exception("This is my error"), "Test", messageTypeFake, verbosityFake);

			Isolate.Verify.NonPublic.WasCalled(managerFake, "WriteToEventLog");
		}

		#endregion
	}
}
