using System;
using System.Web.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.Context.Services
{
	[TestClass]
	public class InlineHealthMonitoringServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void RaisingEventsThrowsException()
		{
			//Arrange
			var service = new InlineHealthMonitoringService();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { service.RaiseEvent(null); });
		}

		[TestMethod]
		public void RegisteringEventsWorksOK()
		{
			//Arrange
			var service = new InlineHealthMonitoringService();
			var eventInfo = Isolate.Fake.Instance<WebBaseEvent>();

			//Act
			service.RaiseEvent(eventInfo);

			//Assert
			Assert.AreEqual(1, service.Events.Count);
		}

		#endregion
	}
}
