using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Orm.Configuration
{
	[TestClass]
	public class UnitOfWorkRegistrationElementTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var el = new UnitOfWorkRegistrationElement();

			//Act
			el.Attributes.Add(new System.Configuration.NameValueConfigurationElement("X", "Y"));
			el.Name = "Test";
			el.TypeName = "X";

			//Assert
			Assert.AreEqual(1, el.Attributes.Count);
			Assert.AreEqual("Test", el.Name);
			Assert.AreEqual("X", el.TypeName);
		}

		#endregion
	}
}
