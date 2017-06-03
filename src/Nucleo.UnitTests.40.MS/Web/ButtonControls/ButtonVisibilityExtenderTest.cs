using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ButtonControls
{
	[TestClass]
	public class ButtonVisibilityExtenderTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var ext = new ButtonVisibilityExtender();

			//Act
			ext.IsVisibleInitially = true;
			ext.OnClientVisibilityStatusChanged = "A";

			//Assert
			Assert.AreEqual(true, ext.IsVisibleInitially);
			Assert.AreEqual("A", ext.OnClientVisibilityStatusChanged);
		}

		#endregion
	}
}
