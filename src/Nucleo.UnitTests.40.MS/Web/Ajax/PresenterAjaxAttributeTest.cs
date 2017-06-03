using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Ajax
{
	[TestClass]
	public class PresenterAjaxAttributeTest
	{
		#region " Tests "
		
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var attrib = new PresenterAjaxAttribute();

			//Act
			attrib.EnableWebMethods = true;

			//Assert
			Assert.AreEqual(true, attrib.EnableWebMethods);
		}

		#endregion
	}
}
