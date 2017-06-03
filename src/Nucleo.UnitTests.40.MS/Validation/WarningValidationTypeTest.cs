using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class WarningValidationTypeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingWarningValidationUsesCorrectValues()
		{
			WarningValidationType validationType = new WarningValidationType();
			Assert.AreEqual("Warning", validationType.Name);
			Assert.AreEqual(128, validationType.Level);
		}

		#endregion
	}
}
