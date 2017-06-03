using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Logs;

namespace Nucleo.Web.Filters
{
	[TestClass]
	public class ExecutionLoggerAttributeTest
	{
		[TestMethod]
		public void LoggingErrorsOnActionExecutedWorksCorrectly()
		{
			//Arrange
			var context = Isolate.Fake.Instance<ActionExecutedContext>();
			Isolate.WhenCalled(() => context.ActionDescriptor.ActionName).WillReturn("ContactUs");
			Isolate.WhenCalled(() => context.ActionDescriptor.ControllerDescriptor.ControllerName).WillReturn("Home");
			Isolate.WhenCalled(() => context.Exception).WillReturn(new Exception("This is a test"));

			var service = Isolate.Fake.Instance<ILoggerService>();
			Isolate.WhenCalled(() => service.LogMessage(null, null, default(LogMessageType), default(LogVerbosityType))).IgnoreCall();

			var attr = Isolate.Fake.Instance<ExecutionLoggerAttribute>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.NonPublic.WhenCalled(attr, "GetService").WillReturn(service);

			//Act
			attr.OnActionExecuted(context);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => service.LogMessage(null, null, default(LogMessageType), default(LogVerbosityType)));

			Isolate.CleanUp();
		}
	}
}
