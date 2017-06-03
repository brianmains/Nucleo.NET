using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ControlStorage
{
	[TestClass]
	public class ControlPropertyValueTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var obj = new ControlPropertyValue();

			//Act
			obj.Key = "A";
			obj.Value = "C";
			obj.Options = new ControlPropertyOptions();

			//Assert
			Assert.AreEqual("A", obj.Key);
			Assert.AreEqual("C", obj.Value);
			Assert.IsNotNull(obj.Options);
		}
	}
}
