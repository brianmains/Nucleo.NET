using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Controls
{
	[TestClass]
	public class LinkRendererTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingDefaultLinkInClientSideOnlyModeAddsVoidHref()
		{
			//Arrange
			var link = new Link();
			link.Page = new Page();
			link.Text = "My Text";
			link.ClickAction = LinkClickAction.FireEvent;
			link.RenderingMode = RenderMode.ClientOnly;

			//Act
			var renderer = new LinkRenderer();
			renderer.Initialize(link);

			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("javascript:void(0);", tag.Attributes.GetAttribute("href").Value);
		}

		[TestMethod]
		public void CreatingDefaultLinkInServerSideOnlyModeAddsVoidHref()
		{
			//Arrange
			var link = new Link();
			link.Page = new Page();
			link.Text = "My Text";
			link.ClickAction = LinkClickAction.FireEvent;
			link.RenderingMode = RenderMode.ServerOnly;

			//Act
			var renderer = new LinkRenderer();
			renderer.Initialize(link);

			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual(NucleoAjaxManager.GetPostbackClientHyperlink(renderer.Component, "click"), tag.Attributes.GetAttribute("href").Value);
		}

		[TestMethod]
		public void CreatingDefaultLinkSetsPropertiesCorrectly()
		{
			//Arrange
			var link = new Link();
			link.Page = new Page();
			link.Text = "My Text";

			//Act
			var renderer = new LinkRenderer();
			renderer.Initialize(link);

			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("A", tag.TagName);
			Assert.AreEqual(link.GetText(), tag.Content);
		}

		[TestMethod]
		public void CreatingRedirectLinkSetsPropertiesCorrectly()
		{
			//Arrange
			var link = new Link();
			link.Page = new Page();
			link.Text = "My Text";
			link.Target = LinkTargetOptions.NewWindow;
			link.NavigateUrl = "http://localhost";
			link.ClickAction = LinkClickAction.Redirect;
			
			//Act
			var renderer = new LinkRenderer();
			renderer.Initialize(link);

			var tag = renderer.Render().Children[0];

			//Arrange
			Assert.AreEqual("A", tag.TagName);
			Assert.AreEqual(link.GetUrl(), tag.Attributes.GetAttribute("href").Value);
			Assert.AreEqual(link.GetTarget(), tag.Attributes.GetAttribute("target").Value);
			Assert.AreEqual(link.GetText(), tag.Content);
		}

		#endregion
	}
}
