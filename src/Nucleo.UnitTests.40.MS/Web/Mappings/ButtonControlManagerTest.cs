using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NB = Nucleo.Web.ButtonControls;


namespace Nucleo.Web.Mappings
{
	[TestClass]
	public class ButtonControlManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void DeterminingCorrectControlReturnsFalse()
		{
			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual(false, manager.IsCorrectControl(new Panel()));
			Assert.AreEqual(false, manager.IsCorrectControl(new Label()));
			Assert.AreEqual(false, manager.IsCorrectControl(new GridView()));
			Assert.AreEqual(false, manager.IsCorrectControl(new HyperLink()));
			Assert.AreEqual(false, manager.IsCorrectControl(new ImageMap()));
		}

		[TestMethod]
		public void DeterminingCorrectControlReturnsTrue()
		{
			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual(true, manager.IsCorrectControl(new Button()));
			Assert.AreEqual(true, manager.IsCorrectControl(new LinkButton()));
			Assert.AreEqual(true, manager.IsCorrectControl(new NB.Button()));
			Assert.AreEqual(true, manager.IsCorrectControl(new ImageButton()));
			Assert.AreEqual(true, manager.IsCorrectControl(new HtmlButton()));
		}

		[TestMethod]
		public void GettingValueFromButtonReturnsCorrectValue()
		{
			Button button = new Button();
			button.Text = "Try Me";

			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual("Try Me", manager.GetValue(button));

			button.Text = "Click this &nbsp; ><";
			Assert.AreEqual("Click this &nbsp; ><", manager.GetValue(button));
		}

		[TestMethod]
		public void GettingValueFromHtmlButtonReturnsCorrectValue()
		{
			HtmlButton button = new HtmlButton();
			button.InnerHtml = "Try Me";

			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual("Try Me", manager.GetValue(button));

			button.InnerHtml = "Click this &nbsp; ><";
			Assert.AreEqual("Click this &nbsp; ><", manager.GetValue(button));
		}

		[TestMethod]
		public void GettingValueFromHtmlInputButtonReturnsCorrectValue()
		{
			HtmlInputButton button = new HtmlInputButton();
			button.Value = "Try Me";

			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual("Try Me", manager.GetValue(button));
			
			button.Value = "Click this &nbsp; ><";
			Assert.AreEqual("Click this &nbsp; ><", manager.GetValue(button));
		}

		[TestMethod]
		public void GettingValueFromLinkButtonReturnsCorrectValue()
		{
			LinkButton button = new LinkButton();
			button.Text = "TrY THiS";

			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual("TrY THiS", manager.GetValue(button));

			button.Text = "Click ME %%&&$$";
			Assert.AreEqual("Click ME %%&&$$", manager.GetValue(button));
		}

		[TestMethod]
		public void GettingValueFromNucleoButtonReturnsCorrectValue()
		{
			NB.Button button = new NB.Button();
			button.Text = "SFSDFFSDDFF";

			ButtonControlManager manager = new ButtonControlManager();
			Assert.AreEqual("SFSDFFSDDFF", manager.GetValue(button));

			button.Text = "SD:LFJ:SLFJ:ST#$*()%&$*(&";
			Assert.AreEqual("SD:LFJ:SLFJ:ST#$*()%&$*(&", manager.GetValue(button));
		}

		[TestMethod]
		public void SettingValueForButtonSetsCorrectValue()
		{
			Button button = new Button();
			ButtonControlManager manager = new ButtonControlManager();
			manager.SetValue(button, "pREsS ThiS; it BRiNGS gOoD LuCK");

			Assert.AreEqual("pREsS ThiS; it BRiNGS gOoD LuCK", button.Text);
		}

		[TestMethod]
		public void SettingValueForLinkButtonSetsCorrectValue()
		{
			LinkButton button = new LinkButton();
			ButtonControlManager manager = new ButtonControlManager();
			manager.SetValue(button, "SFK:LJS:DKFJ#$%#$%");

			Assert.AreEqual("SFK:LJS:DKFJ#$%#$%", button.Text);
		}

		[TestMethod]
		public void SettingValueForNucleoButtonSetsCorrectValue()
		{
			NB.Button button = new NB.Button();
			ButtonControlManager manager = new ButtonControlManager();
			manager.SetValue(button, "214235");

			Assert.AreEqual("214235", button.Text);
		}

        #endregion
	}
}