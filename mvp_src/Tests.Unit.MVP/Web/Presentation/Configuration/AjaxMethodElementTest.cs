using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Presentation.Configuration
{
	[TestClass]
	public class AjaxMethodElementTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var el = new AjaxMethodElement();

			//Act
			el.MethodName = "DoThis";

			//Assert
			Assert.AreEqual("DoThis", el.MethodName);
		}
	}
}
