using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class EnumerableRangeExpressionMatchConstraintTest
	{
		#region " Test Classes "

		protected class RefValue
		{
			public int ID { get; set; }
			public string Value { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CheckingExpressionIsTrueForSingleEntryReturnsTrue()
		{
			//Arrange
			var list = new[]
				{
					new RefValue { ID = 1, Value = "A" },
					new RefValue { ID = 2, Value = "B" },
					new RefValue { ID = 3, Value = "C" },
					new RefValue { ID = 4, Value = "D" },
					new RefValue { ID = 5, Value = "E" }
				};

			var constraint = new EnumerableRangeExpressionMatchConstraint<RefValue>(list, 1, null);

			//Act
			bool matches = constraint.Matches(new Func<RefValue, bool>(i => i.ID == 1));
			int previousCount = constraint.PreviousMatchCount;

			bool matches2 = constraint.Matches(new Func<RefValue, bool>(i => i.ID == 5));
			int previousCount2 = constraint.PreviousMatchCount;

			//Assert
			Assert.AreEqual(true, matches);
			Assert.AreEqual(1, previousCount);
			Assert.AreEqual(true, matches2);
			Assert.AreEqual(1, previousCount2);
		}

		#endregion
	}
}
