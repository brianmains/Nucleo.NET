using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Presentation.Configuration
{
	[TestClass]
	public class PresenterElementTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var el = new PresenterElement();

			//Act
			el.TypeName = "XYZ";

			//Assert
			Assert.AreEqual("XYZ", el.TypeName);
		}
	}
}
