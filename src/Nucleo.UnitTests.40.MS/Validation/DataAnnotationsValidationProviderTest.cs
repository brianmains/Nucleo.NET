using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;


namespace Nucleo.Validation
{
	[TestClass]
	public class DataAnnotationsValidationProviderTest
	{
		#region " Test Classes "

		[DataAnnotatedInstance]
		protected class TestClass
		{
			[
			Required,
			StringLength(100)
			]
			public string Name { get; set; }

			[
			Required,
			StringLength(50)
			]
			public string City { get; set; }

			[
			Required,
			StringLength(2)
			]
			public string State { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CheckingForIsValidProviderReturnsFalse()
		{
			//Arrange
			var obj = new System.Data.DataTable();
			var provider = new DataAnnotationsValidationProvider();

			//Act
			var result = provider.IsCorrectValidator(obj);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void CheckingForIsValidProviderReturnsTrue()
		{
			//Arrange
			var obj = new TestClass();
			var provider = new DataAnnotationsValidationProvider();

			//Act
			var result = provider.IsCorrectValidator(obj);

			//Assert
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void ValidatingDataClassValidatesOK()
		{
			//Arrange
			var provider = new DataAnnotationsValidationProvider();

			//Act
			var obj = new TestClass();
			obj.Name = "Jane Doe";
			obj.City = "Beaver Falls";
			obj.State = "NY";

			var results = provider.Validate(obj);

			//Assert
			Assert.AreEqual(0, results.Count);
		}

		[TestMethod]
		public void ValidatingDataClassValidatesWithError()
		{
			//Arrange
			var provider = new DataAnnotationsValidationProvider();

			//Act
			var obj = new TestClass();
			obj.Name = null;
			obj.City = null;
			obj.State = "";

			var results = provider.Validate(obj);

			//Assert
			Assert.AreEqual(3, results.Count);
			Assert.IsTrue(results.IsInstanceOf<ValidationItem, ErrorValidationType>(i => i.ValidationResult), "The validation item doesn't contain an error");
		}

		#endregion
	}
}
