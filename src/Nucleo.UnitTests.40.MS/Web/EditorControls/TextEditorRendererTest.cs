using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Tags;


namespace Nucleo.Web.EditorControls
{
	[TestClass]
	public class TextEditorRendererTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingStateToErrorAssignsNormalCssClass()
		{
			//Arrange
			var renderer = new TextEditorRenderer();
			var control = new TextEditor();
			control.Page = new Page();
			control.CurrentState = EditorCurrentState.Error;

			//Act
			renderer.Initialize(control);

			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("NucleoTextEditorErrorState", tag.Attributes.GetAttribute("class").Value);
		}

		[TestMethod]
		public void ChangingStateToNormalAssignsNormalCssClass()
		{
			//Arrange
			var renderer = new TextEditorRenderer();
			var control = new TextEditor();
			control.Page = new Page();
			control.CurrentState = EditorCurrentState.Normal;

			//Act
			renderer.Initialize(control);

			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("NucleoTextEditorNormalState", tag.Attributes.GetAttribute("class").Value);
		}

		[TestMethod]
		public void ControlSetsUpOK()
		{
			//Arrange
			var renderer = new TextEditorRenderer();
			var control = new TextEditor();
			control.Page = new Page();
			control.Text = "My Text";

			//Act
			renderer.Initialize(control);

			var tag = renderer.Render().Children[0];

			//Assert
			Assert.AreEqual("text", tag.Attributes.GetAttribute("type").Value);
			Assert.AreEqual(control.Text, tag.Attributes.GetAttribute("value").Value);
		}

		#endregion
	}
}
