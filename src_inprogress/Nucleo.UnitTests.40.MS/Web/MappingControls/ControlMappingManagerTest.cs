using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Pages;


namespace Nucleo.Web.MappingControls
{
	[TestClass]
	public class ControlMappingManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingManagerInstanceReturnsCorrectReference()
		{
			//Arrange
			var page = new FakePage();
			var control = new ControlMappingManager();
			page.Controls.Add(control);
			control.Page = page;

			page.Items[typeof(ControlMappingManager)] = control;
			
			//Act
			var ctl = ControlMappingManager.GetInstance(page);

			//Assert
			Assert.AreEqual(control, ctl);
		}

		#endregion
	}
}
