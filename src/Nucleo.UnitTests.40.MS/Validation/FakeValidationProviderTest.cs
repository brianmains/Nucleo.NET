using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Validation
{
	[TestClass]
	public class FakeValidationProviderTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingIfCorrectProviderReturnsCorrectResult()
		{
			//Arrange
			var obj = new object();
			var provider1 = new FakeValidationProvider();
			var provider2 = new FakeValidationProvider(false, null);

			//Act
			provider1.IsCorrectProvider = true;
			var result1 = provider1.IsCorrectValidator(obj);
			var result2 = provider2.IsCorrectValidator(obj);

			//Assert
			Assert.AreEqual(true, result1);
			Assert.AreEqual(false, result2);
		}

		[TestMethod]
		public void CheckingValidateReturnsCorrectResult()
		{
			//Arrange
			var obj = new object();
			var provider1 = new FakeValidationProvider(true, new ValidationItemCollection());

			//Act
			var result1 = provider1.Validate(obj);

			//Assert
			Assert.IsNotNull(result1);
		}

		#endregion
	}
}
