using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Validation
{
	[TestClass]
	public class ValidationItemTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningNullToValidationResultReturnsEmpty()
		{
			//Arrange
			var item = new ValidationItem("Test", new ErrorValidationType(), "Desc");

			//Act
			item.ValidationResult = null;

			//Assert
			Assert.IsInstanceOfType(item.ValidationResult, typeof(EmptyValidationType));
		}

		[TestMethod]
		public void AssigningValuesToItemChangesValuesAccordingly()
		{
			//Arrange
			ValidationItem item = new ValidationItem("FirstName",
				new ErrorValidationType(), "Please enter a first name, it is required.");

			//Act
			item.Description = "New Desc";
			item.ValidationResult = new WarningValidationType();

			//Assert
			Assert.AreEqual("New Desc", item.Description);
			Assert.IsInstanceOfType(item.ValidationResult, typeof(WarningValidationType));
		}

		[TestMethod]
		public void CreatingDisplayItemAssignsValuesCorrectly()
		{
			//Arrange/Act
			ValidationItem item = new ValidationItem("FirstName",
				new ErrorValidationType(), "Please enter a first name, it is required.");

			//Assert
			Assert.AreEqual("FirstName", item.Name);
			Assert.IsInstanceOfType(item.ValidationResult, typeof(ErrorValidationType));
			Assert.AreEqual("Please enter a first name, it is required.", item.Description);
		}

		#endregion
	}
}
