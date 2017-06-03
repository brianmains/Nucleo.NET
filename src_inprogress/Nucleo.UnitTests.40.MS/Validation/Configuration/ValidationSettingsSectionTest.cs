using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation.Configuration
{
	[TestClass]
	public class ValidationSettingsSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesAssignsCorrectly()
		{
			//Arrange
			var settings = new ValidationSettingsSection();
			
			//Act
			settings.ThrowOnInvalid = true;
			settings.UseFirstFoundProviderOnly = true;

			//Assert
			Assert.AreEqual(true, settings.ThrowOnInvalid);
			Assert.AreEqual(true, settings.UseFirstFoundProviderOnly);
		}

		#endregion
	}
}
