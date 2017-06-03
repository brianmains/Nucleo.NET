using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Configuration
{
	[TestClass]
	public class TypeRegistrationElementTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var el = new TypeRegistrationElement();

			//Act
			el.ContractTypeName = "C";
			el.MappedTypeName = "M";

			//Assert
			Assert.AreEqual("C", el.ContractTypeName);
			Assert.AreEqual("M", el.MappedTypeName);
		}
	}
}
