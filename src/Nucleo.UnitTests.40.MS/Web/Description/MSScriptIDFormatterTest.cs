using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class MSScriptIDFormatterTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingIDOfControlWorksOK()
		{
			//Arrange
			var formatter = new MSScriptIDFormatter();

			//Act
			string format = formatter.GetFormattedID("ctl1", ScriptIDFormatting.Control);

			//Assert
			Assert.AreEqual("$find(\"ctl1\")", format);
		}

		[TestMethod]
		public void GettingIDOfElementWorksOK()
		{
			//Arrange
			var formatter = new MSScriptIDFormatter();

			//Act
			string format = formatter.GetFormattedID("ctl1", ScriptIDFormatting.Element);

			//Assert
			Assert.AreEqual("$get(\"ctl1\")", format);
		}

		[TestMethod]
		public void GettingIDOfExtenderWorksOK()
		{
			//Arrange
			var formatter = new MSScriptIDFormatter();

			//Act
			string format = formatter.GetFormattedID("ctl1", ScriptIDFormatting.Extender);

			//Assert
			Assert.AreEqual("$find(\"ctl1\")", format);
		}

		[TestMethod]
		public void GettingIDOfStandardWorksOK()
		{
			//Arrange
			var formatter = new MSScriptIDFormatter();

			//Act
			string format = formatter.GetFormattedID("ctl1", ScriptIDFormatting.Standard);

			//Assert
			Assert.AreEqual("ctl1", format);
		}

		#endregion
	}
}
