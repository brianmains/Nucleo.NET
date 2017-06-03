using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class EnumerableTruthConstraintTest
	{
		#region " Test Classes "

		protected class RefValue
		{
			public int ID { get; set; }
			public string Value { get; set; }
		}

		protected class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public object Identifier { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CheckingThatAllItemsAreFalseFails()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = null },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = null },
				new RefValue { ID = 3, Value = null }
			};

			//Act
			var constraint = new EnumerableTruthConstraint<RefValue>(items, true);
			var value = constraint.Matches(new Func<RefValue, bool>(i => i.Value != null));

			//Assert
			Assert.IsFalse(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreFalseSucceeds()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = "C" }
			};

			//Act
			var constraint = new EnumerableTruthConstraint<RefValue>(items, false);
			var value = constraint.Matches(new Func<RefValue, bool>(i => i.Value == null));

			//Assert
			Assert.IsTrue(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreTrueFails()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = null }
			};

			//Act
			var constraint = new EnumerableTruthConstraint<RefValue>(items, true);
			var value = constraint.Matches(new Func<RefValue, bool>(i => i.Value != null));

			//Assert
			Assert.IsFalse(value);
		}

		[TestMethod]
		public void CheckingThatAllItemsAreTrueSucceeds()
		{
			//Arrange
			var items = new[]
			{
				new RefValue { ID = 1, Value = "A" },
				new RefValue { ID = 2, Value = "B" },
				new RefValue { ID = 3, Value = "C" }
			};

			//Act
			var constraint = new EnumerableTruthConstraint<RefValue>(items, true);
			var value = constraint.Matches(new Func<RefValue, bool>(i => i.Value != null));

			//Assert
			Assert.IsTrue(value);
		}

		#endregion
	}
}
