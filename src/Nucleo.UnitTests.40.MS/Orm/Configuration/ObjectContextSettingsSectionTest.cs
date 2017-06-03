using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Orm.Configuration
{
	[TestClass]
	public class ObjectContextSettingsSectionTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWOrksOK()
		{
			//Arrange
			var section = new ObjectContextSettingsSection();

			//Act
			section.ConnectionStringName = "A";
			section.ShouldFireTriggers = true;

			//Assert
			Assert.AreEqual("A", section.ConnectionStringName);
			Assert.AreEqual(true, section.ShouldFireTriggers);
		}
	}
}
