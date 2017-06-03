using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class ErrorValidationTypeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingErrorValidationUsesCorrectValues()
		{
			ErrorValidationType validation = new ErrorValidationType();
			Assert.AreEqual("Error", validation.Name);
			Assert.AreEqual(255, validation.Level);
		}

		#endregion
	}
}
