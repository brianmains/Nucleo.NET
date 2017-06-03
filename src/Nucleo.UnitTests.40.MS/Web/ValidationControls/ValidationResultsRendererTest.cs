using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.ValidationControls
{
	[TestClass]
	public class ValidationResultsRendererTest
	{
		#region " Tests "

		[TestMethod]
		public void RenderingControlWithNoItemsRendersAsHidden()
		{
			//Arrange
			var renderer = new ValidationResultsRenderer();
			var control = new ValidationResults();
			control.Page = new Page();
			var writer = new StringControlWriter();

			//Act
			renderer.Initialize(control, control.Page);

			renderer.Render(writer);
			var output = writer.ToString();

			//Assert
			
		}

		#endregion
	}
}
