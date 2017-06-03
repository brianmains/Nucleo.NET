using System;
using System.Web.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;




namespace Nucleo.Services
{
	[TestClass]
	public class WebHealthMonitoringServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void RaisingEventsThrowsException()
		{
			//Arrange
			var service = new WebHealthMonitoringService();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { service.RaiseEvent(null); });
		}

		[TestMethod]
		public void RaisingEventsWorksOK()
		{
			//Arrange
			var eventInfo = Isolate.Fake.Instance<WebBaseEvent>();
			var service = new WebHealthMonitoringService();
			
			//Act
			service.RaiseEvent(eventInfo);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => eventInfo.Raise());
		}

		#endregion
	}
}
