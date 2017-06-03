using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ContainerControls
{
	[TestClass]
	public class PanelHoverOptionsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingOptionsWorksOK()
		{
			//Arrange
			var options = new PanelHoverOptions();

			//Act
			options.ControlID = "Test";
			options.RelocatePanel = true;
			options.RelocatePosition = PanelPosition.BottomLeft;

			//Assert
			Assert.AreEqual("Test", options.ControlID);
			Assert.AreEqual(true, options.RelocatePanel);
			Assert.AreEqual(PanelPosition.BottomLeft, options.RelocatePosition);
		}

		#endregion
	}
}
