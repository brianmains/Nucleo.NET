using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class IButtonControlsExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void ConvertingToButtonWorksOK()
		{
			//Arrange
			var button1 = new LinkButton();

			//Act
			button1.CausesValidation = true;
			button1.CommandArgument = "1";
			button1.CommandName = "A";
			button1.PostBackUrl = "test.aspx";
			button1.Text = "My Button";
			button1.ValidationGroup = "Val";

			var button2 = button1.ToButton();

			//Assert
			Assert.AreEqual(true, button2.CausesValidation);
			Assert.AreEqual("1", button2.CommandArgument);
			Assert.AreEqual("A", button2.CommandName);
			Assert.AreEqual("test.aspx", button2.PostBackUrl);
			Assert.AreEqual("My Button", button2.Text);
			Assert.AreEqual("Val", button2.ValidationGroup);
			Assert.AreEqual("Val", button2.ValidationGroup);
		}

		[TestMethod]
		public void ConvertingToImageButtonWorksOK()
		{
			//Arrange
			var button1 = new Button();

			//Act
			button1.CausesValidation = true;
			button1.CommandArgument = "1";
			button1.CommandName = "A";
			button1.PostBackUrl = "test.aspx";
			button1.Text = "My Button";
			button1.ValidationGroup = "Val";

			var button2 = button1.ToImageButton();

			//Assert
			Assert.AreEqual(true, button2.CausesValidation);
			Assert.AreEqual("1", button2.CommandArgument);
			Assert.AreEqual("A", button2.CommandName);
			Assert.AreEqual("test.aspx", button2.PostBackUrl);
			Assert.AreEqual("Val", button2.ValidationGroup);
			Assert.AreEqual("Val", button2.ValidationGroup);
		}

		[TestMethod]
		public void ConvertingToLinkButtonWorksOK()
		{
			//Arrange
			var button1 = new Button();

			//Act
			button1.CausesValidation = true;
			button1.CommandArgument = "1";
			button1.CommandName = "A";
			button1.PostBackUrl = "test.aspx";
			button1.Text = "My Button";
			button1.ValidationGroup = "Val";

			var button2 = button1.ToLinkButton();

			//Assert
			Assert.AreEqual(true, button2.CausesValidation);
			Assert.AreEqual("1", button2.CommandArgument);
			Assert.AreEqual("A", button2.CommandName);
			Assert.AreEqual("test.aspx", button2.PostBackUrl);
			Assert.AreEqual("My Button", button2.Text);
			Assert.AreEqual("Val", button2.ValidationGroup);
			Assert.AreEqual("Val", button2.ValidationGroup);
		}

		[TestMethod]
		public void CopyingPropertiesWorksOK()
		{
			//Arrange
			IButtonControl button1 = new Button();
			IButtonControl button2 = new Button();

			//Act
			button1.CausesValidation = true;
			button1.CommandArgument = "1";
			button1.CommandName = "A";
			button1.PostBackUrl = "test.aspx";
			button1.Text = "My Button";
			button1.ValidationGroup = "Val";

			button1.CopyAttributes(button2);

			//Assert
			Assert.AreEqual(true, button2.CausesValidation);
			Assert.AreEqual("1", button2.CommandArgument);
			Assert.AreEqual("A", button2.CommandName);
			Assert.AreEqual("test.aspx", button2.PostBackUrl);
			Assert.AreEqual("My Button", button2.Text);
			Assert.AreEqual("Val", button2.ValidationGroup);
			Assert.AreEqual("Val", button2.ValidationGroup);
		}

		#endregion
	}
}
