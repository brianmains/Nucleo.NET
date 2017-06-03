using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Presentation.Configuration
{
	[TestClass]
	public class PresenterWebSettingsSectionTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var section = new PresenterWebSettingsSection();

			//Act
			section.Presenters.Add(new PresenterElement());

			//Assert
			Assert.AreEqual(1, section.Presenters.Count);
		}
	}
}
