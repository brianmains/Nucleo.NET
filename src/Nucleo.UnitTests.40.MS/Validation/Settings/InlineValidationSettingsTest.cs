using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation.Settings
{
	[TestClass]
	public class InlineValidationSettingsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingSettingsWorksOK()
		{
			//Arrange
			var settings = default(InlineValidationSettings);

			//Act
			settings = new InlineValidationSettings(new ValidationProviderCollection
			{
				new FakeValidationProvider(),
				new FakeValidationProvider()
			}, true, false);

			//Assert
			Assert.AreEqual(true, settings.ThrowOnInvalid);
			Assert.AreEqual(false, settings.UseFirstFoundProviderOnly);
			Assert.IsNotNull(settings.Providers);
			Assert.AreEqual(2, settings.Providers.Count);
		}

		#endregion
	}
}
