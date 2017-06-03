using System;
using System.Collections.Generic;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Mvc.Elements.Forms
{
	[TestClass]
	public class HtmlFormTest
	{
		#region " Tests "

		[TestMethod]
		public void CollectionsReturnNotNullWhenNotAssigned()
		{
			//Arrange
			var form = new HtmlForm();

			//Act

			//Assert
			Assert.IsNotNull(form.HtmlAttributes);
			Assert.IsNotNull(form.RouteValues);
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var form = new HtmlForm();

			//Act
			form.ActionName = "Index";
			form.ControllerName = "Home";
			form.HtmlAttributes = new Dictionary<string, object>();
			form.RouteValues = new RouteValueDictionary();

			//Assert
			Assert.AreEqual("Index", form.ActionName);
			Assert.AreEqual("Home", form.ControllerName);
			Assert.AreEqual(0, form.HtmlAttributes.Count);
			Assert.AreEqual(0, form.RouteValues.Count);
		}

		#endregion
	}
}
