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
	public class PublishedEventDetailsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingDetailsWithCriteriaAndDictionaryWorksOK()
		{
			//Arrange
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();
			var dict = new Dictionary<string, object>();

			//Act
			var details = new PublishedEventDetails(null, criteria, dict);

			//Assert
			Assert.AreEqual(criteria, details.Criteria);
			Assert.AreEqual(dict, details.Attributes);
		}

		[TestMethod]
		public void CreatingDetailsWithCriteriaWorksOK()
		{
			//Arrange
			var criteria = Isolate.Fake.Instance<IListenerCriteria>();

			//Act
			var details = new PublishedEventDetails(criteria, criteria);

			//Assert
			Assert.AreEqual(criteria, details.Criteria);
		}

		#endregion
	}
}
