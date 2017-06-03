using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Logs
{
	[TestClass]
	public class LogMessageTypesTest
	{

		#region " Tests "

		[TestMethod]
		public void GettingDefaultsWorksOK()
		{
			//Arrange

			//Act
			var def = LogMessageTypes.Default;

			//Assert
			Assert.AreEqual(3, def.Count);
			Assert.AreEqual("Information", def[0].Name);
			Assert.AreEqual("Warning", def[1].Name);
			Assert.AreEqual("Error", def[2].Name);
		}

		#endregion
	}
}
