using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.Context.Services;


namespace Nucleo.Web.Filters
{
	[TestClass]
	public class ExceptionLoggerAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//arrange
			ExceptionLoggerAttribute logger = new ExceptionLoggerAttribute();

			//Act
			logger.HandleException = true;
			logger.Source = "Test";

			//Assert
			Assert.AreEqual(true, logger.HandleException);
			Assert.AreEqual("Test", logger.Source);
		}

		[TestMethod]
		public void LoggingExceptionWorksOK()
		{
			//Arrange
			var loggerFake = Isolate.Fake.Instance<ILoggerService>();
			var contextFake = Isolate.Fake.Instance<ApplicationContext>();

			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(contextFake);
			Isolate.WhenCalled(() => contextFake.GetService<ILoggerService>()).WillReturn(loggerFake);

			//Act
			var attrib = new ExceptionLoggerAttribute();
			attrib.OnException(new ExceptionContext(new ControllerContext(), new Exception("My Exception")));

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => loggerFake.LogError(null, null, null, null));

			Isolate.CleanUp();
		}

		#endregion
	}
}
