using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventSubscriptionTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEventKeyWorksOK()
		{
			//Arrange
			var key = default(EventSubscription);

			//Act
			key = new EventSubscription(typeof(object), "DocumentChanged");

			//Assert
			Assert.AreEqual(typeof(object), key.SourceType);
			Assert.AreEqual("DocumentChanged", key.Name);
		}

		#endregion
	}
}
