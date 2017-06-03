using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.EventsManagement.Listeners
{
	[TestClass]
	public class AnyListenerCriteriaTest
	{
		#region " Tests "

		[TestMethod]
		public void MatchingCriteriaReturnsTrue()
		{
			//Arrange
			var criteria = new AnyListenerCriteria();
			var criteria2 = Isolate.Fake.Instance<IListenerCriteria>();

			//Act
			var match1 = criteria.IsMatch(null);
			var match2 = criteria.IsMatch(criteria2);

			//Assert
			Assert.IsTrue(match1);
			Assert.IsTrue(match2);

			Isolate.CleanUp();
		}

		#endregion
	}
}
