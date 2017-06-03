using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Mappings
{
	[TestClass]
	public class CheckBoxControlManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingIfCorrectControlWorksCorrectly()
		{
			CheckboxControlManager manager = new CheckboxControlManager();

			CheckBox checkbox = new CheckBox();
			Assert.AreEqual(true, manager.IsCorrectControl(checkbox));

			RadioButton radio = new RadioButton();
			Assert.AreEqual(true, manager.IsCorrectControl(radio));

			HtmlInputCheckBox htmlCheck = new HtmlInputCheckBox();
			Assert.AreEqual(true, manager.IsCorrectControl(htmlCheck));

			HtmlInputRadioButton htmlRadio = new HtmlInputRadioButton();
			Assert.AreEqual(true, manager.IsCorrectControl(htmlRadio));
		}

		[TestMethod]
		public void GettingCheckboxValuesWorksCorrectly()
		{
			CheckboxControlManager manager = new CheckboxControlManager();

			CheckBox checkbox = new CheckBox();
			checkbox.Checked = true;
			Assert.AreEqual(true, manager.GetValue(checkbox));

			checkbox.Checked = false;
			Assert.AreEqual(false, manager.GetValue(checkbox));
		}

		[TestMethod]
		public void GettingHtmlCheckboxValuesWorksCorrectly()
		{
			CheckboxControlManager manager = new CheckboxControlManager();

			HtmlInputCheckBox checkbox = new HtmlInputCheckBox();
			checkbox.Checked = true;
			Assert.AreEqual(true, manager.GetValue(checkbox));

			checkbox.Checked = false;
			Assert.AreEqual(false, manager.GetValue(checkbox));
		}

		[TestMethod]
		public void GettingHtmlRadioButtonValuesWorksCorrectly()
		{
			CheckboxControlManager manager = new CheckboxControlManager();

			HtmlInputRadioButton radio = new HtmlInputRadioButton();
			radio.Checked = true;
			Assert.AreEqual(true, manager.GetValue(radio));

			radio.Checked = false;
			Assert.AreEqual(false, manager.GetValue(radio));
		}

		[TestMethod]
		public void GettingRadioButtonValuesWorksCorrectly()
		{
			CheckboxControlManager manager = new CheckboxControlManager();

			RadioButton radio = new RadioButton();
			radio.Checked = true;
			Assert.AreEqual(true, manager.GetValue(radio));

			radio.Checked = false;
			Assert.AreEqual(false, manager.GetValue(radio));
		}

		[TestMethod]
		public void SettingValuesWorksCorrectly()
		{
			
		}

		#endregion
	}
}
