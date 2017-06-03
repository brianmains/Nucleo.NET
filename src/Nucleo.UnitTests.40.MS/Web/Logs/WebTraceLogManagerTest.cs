using System;
using System.Web;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Logs;


namespace Nucleo.Web.Logs
{
	[TestClass]
	public class WebTraceLogManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void TracingErrorsWorksOK()
		{
			//Arrange
			var page = Isolate.Fake.Instance<Page>();

			var contextFake = Isolate.Fake.Instance<HttpContext>();
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.Handler).WillReturn(page);

			var traceContext = Isolate.Fake.Instance<TraceContext>();
			Isolate.WhenCalled(() => page.Trace).WillReturn(traceContext);

			var messageType = Isolate.Fake.Instance<LogMessageType>();
			var verbosityType = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			var manager = new WebTraceLogManager();
			manager.LogError(new Exception(), "Test", messageType, verbosityType);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => { traceContext.Warn(null, null, null); });
		}

		[TestMethod]
		public void TracingMessagesWorksOK()
		{
			//Arrange
			var page = Isolate.Fake.Instance<Page>();

			var contextFake = Isolate.Fake.Instance<HttpContext>();
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.Handler).WillReturn(page);

			var traceContext = Isolate.Fake.Instance<TraceContext>();
			Isolate.WhenCalled(() => page.Trace).WillReturn(traceContext);

			var messageType = Isolate.Fake.Instance<LogMessageType>();
			var verbosityType = Isolate.Fake.Instance<LogVerbosityType>();

			//Act
			var manager = new WebTraceLogManager();
			manager.LogMessage("Test", "Test", messageType, verbosityType);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => { traceContext.Write(null, null); });
		}

		#endregion
	}
}
