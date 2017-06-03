using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class CustomScriptIDFormatterTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingIDWithNullsWorksOK()
		{
			//Arrange
			var formatter = new CustomScriptIDFormatter(null, null);

			//Act
			var id = formatter.GetFormattedID("ctl1", ScriptIDFormatting.Standard);

			//Assert
			Assert.AreEqual("ctl1", id);
		}

		[TestMethod]
		public void GettingIDWorksOK()
		{
			//Arrange
			var formatter = new CustomScriptIDFormatter("$(\"#", "\")");

			//Act
			var id = formatter.GetFormattedID("ctl1", ScriptIDFormatting.Standard);

			//Assert
			Assert.AreEqual("$(\"#ctl1\")", id);
		}

		#endregion
	}
}
