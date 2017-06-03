using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class ValidationItemCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsInBulkAddsOK()
		{
			//Arrange
			var list = new ValidationItemCollection();

			//Act
			list.AddRange(new ValidationItem[]
			{
				new ValidationItem("Test1", new InformationValidationType(), "Test"),
				new ValidationItem("Test2", new InformationValidationType(), "Test"),
				new ValidationItem("Test3", new InformationValidationType(), "Test")
			});

			//Assert
			Assert.AreEqual(3, list.Count);
		}

		[TestMethod]
		public void ContainsErrorReturnsFalse()
		{
			//Arrange
			var list = new ValidationItemCollection();

			//Act
			list.AddRange(new ValidationItem[]
			{
				new ValidationItem("Test1", new InformationValidationType(), "Test"),
				new ValidationItem("Test2", new InformationValidationType(), "Test"),
				new ValidationItem("Test3", new WarningValidationType(), "Test")
			});

			//Assert
			Assert.IsFalse(list.ContainsError());
		}

		[TestMethod]
		public void ContainsErrorReturnsTrue()
		{
			//Arrange
			var list = new ValidationItemCollection();

			//Act
			list.AddRange(new ValidationItem[]
			{
				new ValidationItem("Test1", new InformationValidationType(), "Test"),
				new ValidationItem("Test2", new ErrorValidationType(), "Test"),
				new ValidationItem("Test3", new WarningValidationType(), "Test")
			});

			//Assert
			Assert.IsTrue(list.ContainsError());
		}

		[TestMethod]
		public void GettingDisplayItemByNameReturnsCorrectObject()
		{
			var list = new ValidationItemCollection();
			list.Add(new ValidationItem("First", new ErrorValidationType(), "Test 1"));
			list.Add(new ValidationItem("Second", new ErrorValidationType(), "Test 2"));
			list.Add(new ValidationItem("Third", new ErrorValidationType(), "Test 3"));
			list.Add(new ValidationItem("Fourth", new ErrorValidationType(), "Test 4"));
			list.Add(new ValidationItem("Fifth", new ErrorValidationType(), "Test 5"));

			Assert.AreEqual("Test 1", list.GetByName("First").Description, "Desc's don't match");
			Assert.AreEqual("Test 3", list.GetByName("Third").Description, "Desc's don't match");
			Assert.AreEqual("Test 5", list.GetByName("Fifth").Description, "Desc's don't match");
			Assert.IsNull(list.GetByName("Sixth"), "Shouldn't find sixth entry");
		}

		[TestMethod]
		public void GettingErrorsWorksOK()
		{
			//Arrange
			var list = new ValidationItemCollection();
			list.AddRange(new ValidationItem[]
			{
				new ValidationItem("Test1", new InformationValidationType(), "Test"),
				new ValidationItem("Test2", new ErrorValidationType(), "Test"),
				new ValidationItem("Test3", new ErrorValidationType(), "Test")
			});

			//Act
			var error = list.GetErrors();

			//Assert
			Assert.IsNotNull(error);
			Assert.AreEqual(2, error.Count());
		}

		[TestMethod]
		public void GettingFirstErrorWorksOK()
		{
			//Arrange
			var list = new ValidationItemCollection();
			list.AddRange(new ValidationItem[]
			{
				new ValidationItem("Test1", new InformationValidationType(), "Test"),
				new ValidationItem("Test2", new ErrorValidationType(), "Test"),
				new ValidationItem("Test3", new WarningValidationType(), "Test")
			});

			//Act
			var error = list.GetFirstError();

			//Assert
			Assert.IsNotNull(error);
			Assert.AreEqual("Test2", error.Name);
		}

		#endregion
	}
}
