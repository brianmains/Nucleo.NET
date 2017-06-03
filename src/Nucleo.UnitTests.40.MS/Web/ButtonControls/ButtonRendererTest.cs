using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ButtonControls
{
	[TestClass]
	public class ButtonRendererTest
	{
		#region " Methods "

		[TestMethod]
		public void CreatingButtonRendersCorrectHtml()
		{
			//Arrange
			var button = new Button();
			button.Page = new Page();
			button.DisableUntilPageLoad = true;
			button.Text = "Some Test";
			button.Mode = ButtonType.Button;
			
			//Act
			var render = new ButtonRenderer();
			render.Initialize(button);
			var tag = render.Render().Children[0];

			//Assert
			Assert.AreEqual("INPUT", tag.TagName);
			Assert.AreEqual("Some Test", tag.Attributes.GetAttribute("value").Value);
			Assert.AreEqual("disabled", tag.Attributes.GetAttribute("disabled").Value);
		}

		[TestMethod]
		public void CreatingImageButtonInServerModeRendersCorrectHtml()
		{
			//Arrange
			var button = new Button();
			button.Page = new Page();
			button.RenderingMode = RenderMode.ServerOnly;
			button.Mode = ButtonType.Image;
			button.ImageUrl = "test.jpg";

			//Act
			var render = new ButtonRenderer();
			render.Initialize(button);
			var tag = render.Render().Children[0];

			//Assert
			Assert.AreEqual("INPUT", tag.TagName);
			Assert.AreEqual("image", tag.Attributes.GetAttributeValue("type"));
		}

		[TestMethod]
		public void CreatingImageButtonRendersCorrectHtml()
		{
			//Arrange
			var button = new Button();
			button.Page = new Page();
			button.DisableUntilPageLoad = true;
			button.Text = "Some Test";
			button.Mode = ButtonType.Image;
			button.ImageUrl = "test.jpg";

			//Act
			var render = new ButtonRenderer();
			render.Initialize(button);
			var tag = render.Render().Children[0];

			//Assert
			Assert.AreEqual("test.jpg", tag.Attributes.GetAttribute("src").Value);
			Assert.IsTrue(string.IsNullOrEmpty(tag.Content));
			Assert.AreEqual("disabled", tag.Attributes.GetAttribute("disabled").Value);
		}

		[TestMethod]
		public void CreatingLinkButtonRendersCorrectHtml()
		{
			//Arrange
			var button = new Button();
			button.Page = new Page();
			button.DisableUntilPageLoad = true;
			button.Text = "Some Test";
			button.Mode = ButtonType.Link;

			//Act
			var render = new ButtonRenderer();
			render.Initialize(button);
			var tag = render.Render().Children[0];

			//Assert
			Assert.AreEqual("Some Test", tag.Content);
			Assert.AreEqual("disabled", tag.Attributes.GetAttribute("disabled").Value);
			Assert.IsNotNull(tag.Attributes.GetAttribute("href").Value);
		}

		[TestMethod]
		public void UsingSubmitBehaviorSetToFalseRendersSubmitButton()
		{
			//Arrange
			var button = new Button();
			button.Page = new Page();
			button.UseSubmitBehavior = false;
			button.Text = "Some Test";
			button.Mode = ButtonType.Button;

			//Act
			var renderer = new ButtonRenderer();
			renderer.Initialize(button);
			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("INPUT", tag.TagName);
			Assert.AreEqual("button", tag.Attributes.GetAttributeValue("type"));
		}

		[TestMethod]
		public void UsingSubmitBehaviorSetToTrueRendersSubmitButton()
		{
			//Arrange
			var button = new Button();
			button.Page = new Page();
			button.UseSubmitBehavior = true;
			button.Text = "Some Test";
			button.Mode = ButtonType.Button;

			//Act
			var renderer = new ButtonRenderer();
			renderer.Initialize(button);
			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("INPUT", tag.TagName);
			Assert.AreEqual("submit", tag.Attributes.GetAttributeValue("type"));
		}

		#endregion
	}
}
