using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ValidationControls
{
	[TestClass]
	public class AspNetValidatorCompatibilityOptionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var options = new AspNetValidatorCompatibilityOptions();

			//Act
			options.AttachToValidators = true;

			//Assert
			Assert.AreEqual(true, options.AttachToValidators);
		}

		#endregion
	}
}
