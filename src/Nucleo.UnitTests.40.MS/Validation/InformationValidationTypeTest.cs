using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class InformationValidationTypeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingInfomationValidationAssignsCorrectValues()
		{
			var validationType = new InformationValidationType();
			Assert.AreEqual("Information", validationType.Name);
			Assert.AreEqual(1, validationType.Level);
		}

		#endregion
	}
}
