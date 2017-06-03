using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupCriteriaTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingCriteriaForLookupRelativeDateWorksOK()
		{
			//Arrange
			var criteria = default(LookupCriteria);

			//Act
			criteria = new LookupCriteria(new DateTime(2007, 1, 23));

			//Assert
			DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 23), criteria.TimeframeDate.Value);
		}

		[TestMethod]
		public void CreatingEmptyCriteriaWorksOK()
		{
			//Arrange
			var criteria = default(LookupCriteria);

			//Act
			criteria = new LookupCriteria();

			//Assert
			Assert.IsNull(criteria.TimeframeDate);
		}

		#endregion
	}
}
