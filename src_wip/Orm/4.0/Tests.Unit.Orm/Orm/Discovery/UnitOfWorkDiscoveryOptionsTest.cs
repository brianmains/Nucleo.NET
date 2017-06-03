using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Orm.Discovery
{
	[TestClass]
	public class UnitOfWorkDiscoveryOptionsTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var options = new UnitOfWorkDiscoveryOptions();

			//Act
			options.Name = "X";

			//Assert
			Assert.AreEqual("X", options.Name);
		}
	}
}
