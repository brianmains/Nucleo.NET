using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Logs
{
	[TestClass]
	public class LoggerMessageEventTest
	{
		#region " Tests "

		[TestMethod]
		public void LoggingEventLogsSuccessfully()
		{
			//Arrange
			var evt = Isolate.Fake.Instance<LoggerMessageEvent>(Members.CallOriginal, ConstructorWillBe.Called);
			Isolate.Swap.NextInstance<LoggerMessageEvent>().With(evt);
			Isolate.WhenCalled(() => evt.Raise()).IgnoreCall();

			//Act
			var error = LoggerMessageEvent.Raise("My source", "Test msg");

			//Assert
			Assert.AreEqual("My source", error.EventSource);
			Assert.AreEqual("Test msg", error.Message);
			Assert.AreEqual(100000, error.EventCode);
		}

		#endregion
	}
}
