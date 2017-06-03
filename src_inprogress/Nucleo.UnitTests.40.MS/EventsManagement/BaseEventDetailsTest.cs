using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class BaseEventDetailsTest
	{
		#region " Test Classes "

		protected class TestEventDetails : BaseEventDetails
		{
			public TestEventDetails(IListenerCriteria criteria)
				: base(criteria) { }
		}
		
		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingDetailsWithCriteriaWorksOK()
		{
			//Arrange
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();

			//Act
			var details = new TestEventDetails(criteria);

			//Assert
			Assert.AreEqual(criteria, details.Criteria);
		}

		#endregion
	}
}
