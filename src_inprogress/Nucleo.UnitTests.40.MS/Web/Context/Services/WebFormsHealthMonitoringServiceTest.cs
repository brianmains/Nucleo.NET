using System;
using System.Web.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.Context.Services
{
	[TestClass]
	public class WebFormsHealthMonitoringServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void RaisingEventsThrowsException()
		{
			//Arrange
			var service = new WebFormsHealthMonitoringService();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { service.RaiseEvent(null); });
		}

		[TestMethod]
		public void RaisingEventsWorksOK()
		{
			//Arrange
			var eventInfo = Isolate.Fake.Instance<WebBaseEvent>();
			var service = new WebFormsHealthMonitoringService();
			
			//Act
			service.RaiseEvent(eventInfo);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => eventInfo.Raise());
		}

		#endregion
	}
}
