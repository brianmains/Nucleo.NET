using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Logs
{
	[TestClass]
	public class LogVerbosityTypesTest
	{
		[TestMethod]
		public void DefaultWorksOK()
		{
			//Arrange

			//Act
			var def = LogVerbosityTypes.Default;

			//Assert
			Assert.AreEqual("Minimal", def[0].Name);
			Assert.AreEqual("Normal", def[1].Name);
			Assert.AreEqual("Verbose", def[2].Name);
		}
	}
}
