using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Core.Configuration
{
	[TestClass]
	public class FrameworkSettingsSectionTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var section = new FrameworkSettingsSection();

			//Act
			section.PresenterCacheTypeName = "X";
			section.PresenterCreatorTypeName = "Y";

			//Assert
			Assert.AreEqual("X", section.PresenterCacheTypeName);
			Assert.AreEqual("Y", section.PresenterCreatorTypeName);
		}
	}
}
