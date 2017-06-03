using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Nucleo.Web.ContainerControls
{
	[TestClass]
	public class PanelModalOptionsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingOptionsWorksOK()
		{
			//Arrange
			var options = new PanelModalOptions();

			//Act
			options.IsOpen = true;
			options.OKButtonID = "Test";

			//Assert
			Assert.AreEqual(true, options.IsOpen);
			Assert.AreEqual("Test", options.OKButtonID);
		}
		
		#endregion
	}
}
