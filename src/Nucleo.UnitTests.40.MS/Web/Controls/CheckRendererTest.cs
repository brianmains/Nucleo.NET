using System;
using System.Web.UI;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Controls
{
	[TestClass]
	public class CheckRendererTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingCheckCreatesLabelAndImage()
		{
			//Arrange
			var check = ControlTestingUtility.CreateControl<Check>();
			check.ID = "chk";
			check.RenderingMode = RenderMode.ServerOnly;
			check.Checked = true;

			//Act
			var renderer = new CheckRenderer();
			renderer.Initialize(check);
			var tag = renderer.Render();

			//Assert
			Assert.AreEqual(2, tag.Children.TagCount);
			Assert.AreEqual("IMG", tag.Children[0].TagName);
			Assert.AreEqual("LABEL", tag.Children[1].TagName);
		}

		[TestMethod]
		public void CreatingCheckUsingServerSideModeAppendsPostbackScript()
		{
			//Arrange
			var check = new Check();
			check.Page = new Page();
			check.ID = "chk";
			check.RenderingMode = RenderMode.ServerOnly;
			check.Checked = true;

			//Act
			var renderer = new CheckRenderer();
			renderer.Initialize(check);
			var tag = renderer.Render();

			//Assert
			Assert.AreEqual(ControlUtility.GetPostbackClientMethod(check.ClientID, "toggle"), tag.Children[0].Attributes.GetAttribute("onclick").Value);
		}

		#endregion
	}
}
