using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Orm.Configuration
{
	[TestClass]
	public class UnitOfWorkSectionTest
	{
		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var section = new UnitOfWorkSection();

			//Act
			section.DiscoveryStrategyTypeName = "X";

			//Assert
			Assert.AreEqual("X", section.DiscoveryStrategyTypeName);
		}
	}
}
