using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Lookups.Identification;


namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupCriteriaTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingCriteriaForLookupAssignsOK()
		{
			//Arrange
			var criteria = default(LookupCriteria);
			var id = Isolate.Fake.Instance<ILookupIdentifier>();

			//Act
			criteria = new LookupCriteria(id, new DateTime(2007, 1, 23));

			//Assert
			Assert.AreEqual(id, criteria.Identifier);
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
			Assert.IsNull(criteria.Identifier);
			Assert.IsNull(criteria.TimeframeDate);
		}

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var criteria = default(LookupCriteria);
			var id = Isolate.Fake.Instance<ILookupIdentifier>();

			//Act
			criteria = new LookupCriteria
			{
				Identifier = id,
				TimeframeDate = new DateTime(2007, 1, 23)
			};

			//Assert
			Assert.AreEqual(id, criteria.Identifier);
			DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 23), criteria.TimeframeDate.Value);
		}

		#endregion
	}
}
