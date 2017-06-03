using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ContainerControls
{
	[TestClass]
	public class PanelResizeOptionsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingOptionsWorksOK()
		{
			//Arrange
			var options = new PanelResizeOptions();

			//Act
			options.AutoCapHeight = true;
			options.MaxHeight = 500;
			options.MaxWidth = 550;
			options.MinHeight = 100;
			options.MinWidth = 150;

			//Assert
			Assert.AreEqual(true, options.AutoCapHeight);
			Assert.AreEqual(500, options.MaxHeight);
			Assert.AreEqual(550, options.MaxWidth);
			Assert.AreEqual(100, options.MinHeight);
			Assert.AreEqual(150, options.MinWidth);
		}

		#endregion
	}
}
