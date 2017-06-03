using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Mappings
{
	[TestClass]
	public class HiddenFieldControlManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void DeterminingControlReferenceReturnsFalse()
		{
			HiddenFieldControlManager manager = new HiddenFieldControlManager();
			Assert.AreEqual(false, manager.IsCorrectControl(new Label()));
			Assert.AreEqual(false, manager.IsCorrectControl(new Panel()));
			Assert.AreEqual(false, manager.IsCorrectControl(new Table()));
			Assert.AreEqual(false, manager.IsCorrectControl(new HtmlTable()));
		}

		[TestMethod]
		public void DeterminingControlReferenceReturnsTrue()
		{
			HiddenFieldControlManager manager = new HiddenFieldControlManager();
			Assert.AreEqual(true, manager.IsCorrectControl(new HiddenField()));
			Assert.AreEqual(true, manager.IsCorrectControl(new HtmlInputHidden()));
		}

		[TestMethod]
		public void GettingHiddenFieldValueReturnsCorrectValue()
		{
			HiddenFieldControlManager manager = new HiddenFieldControlManager();
			HiddenField field = new HiddenField();
			field.Value = "D:SFJS:KLFJ";

			Assert.AreEqual("D:SFJS:KLFJ", manager.GetValue(field));
		}

		[TestMethod]
		public void GettingHiddenInputFieldValueReturnsCorrectValue()
		{
			HiddenFieldControlManager manager = new HiddenFieldControlManager();
			HtmlInputHidden field = new HtmlInputHidden();
			field.Value = "SDFSDFFS#$#$234324";

			Assert.AreEqual("SDFSDFFS#$#$234324", manager.GetValue(field));
		}

		[TestMethod]
		public void SettingHiddenFieldSetsCorrectValue()
		{
			HiddenFieldControlManager manager = new HiddenFieldControlManager();
			HiddenField field = new HiddenField();

			manager.SetValue(field, "3454356435");
			Assert.AreEqual("3454356435", field.Value);
		}

		[TestMethod]
		public void SettingHiddenInputFieldSetsCorrectValue()
		{
			HiddenFieldControlManager manager = new HiddenFieldControlManager();
			HtmlInputHidden field = new HtmlInputHidden();

			manager.SetValue(field, "ETKWJT434");
			Assert.AreEqual("ETKWJT434", field.Value);
		}

		#endregion
	}
}
