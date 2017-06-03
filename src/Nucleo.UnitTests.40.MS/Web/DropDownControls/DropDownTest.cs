using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Templates;


namespace Nucleo.Web.DropDownControls
{
	[TestClass]
	public class DropDownTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var dd = new DropDown();

			//Act
			dd.Content = new ControlElementTemplate();
			dd.InputOptions = new DropDownInputOptions { ControlID = "A" };
			dd.MenuOptions = new DropDownMenuOptions { ControlID = "B" };
			dd.SelectorOptions = new DropDownSelectorOptions { ControlID = "C" };
			dd.Text = "D";

			//Assert
			Assert.IsNotNull(dd.Content);
			Assert.AreEqual("A", dd.InputOptions.ControlID);
			Assert.AreEqual("B", dd.MenuOptions.ControlID);
			Assert.AreEqual("C", dd.SelectorOptions.ControlID);
			Assert.AreEqual("D", dd.Text);
		}

		#endregion
	}
}
