using System;
using System.Web.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;




namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryHealthMonitoringServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void RaisingEventsThrowsException()
		{
			//Arrange
			var service = new InMemoryHealthMonitoringService();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { service.RaiseEvent(null); });
		}

		[TestMethod]
		public void RegisteringEventsWorksOK()
		{
			//Arrange
			var service = new InMemoryHealthMonitoringService();
			var eventInfo = Isolate.Fake.Instance<WebBaseEvent>();

			//Act
			service.RaiseEvent(eventInfo);

			//Assert
			Assert.AreEqual(1, service.Events.Count);
		}

		#endregion
	}
}
