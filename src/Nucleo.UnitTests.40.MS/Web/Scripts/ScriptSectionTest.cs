using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Scripts
{
	[TestClass]
	public class ScriptSectionTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var section = new ScriptSection();

			//Act
			section.RegionName = "X";
			section.Blocks = new ScriptBlockCollection() { };

			//Assert
			Assert.AreEqual("X", section.RegionName);
			Assert.IsNotNull(section.Blocks);
		}
	}
}
