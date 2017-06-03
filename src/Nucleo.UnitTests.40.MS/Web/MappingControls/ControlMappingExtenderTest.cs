using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Pages;
using Nucleo.Web.Pages.Testing;
using Nucleo.TestingTools;


namespace Nucleo.Web.MappingControls
{
	[TestClass]
	public class ControlMappingExtenderTest
	{
		#region " Tests "

		[TestMethod]
		public void EnsuringManagerIDOnPreRenderDoesntThrowException()
		{
			//Arrange
			var extender = new ControlMappingExtender();
			extender.TargetControlID = "Test2";
			var pageRunner = new PageRunner();
			pageRunner.AddControl(extender);

			//Act
			extender.ManagerID = "Test";
			pageRunner.FireEvent(PageControllerEvent.ValidateState);

			//Assert
			
		}

		[TestMethod]
		public void NullManagerIDOnPreRenderDoesThrowException()
		{
			//Arrange
			var extender = new ControlMappingExtender();
			var pageRunner = new PageRunner();
			pageRunner.AddControl(extender);

			//Act
			extender.ManagerID = null;

			//Assert
			ExceptionTester.CheckException(true, (src) => { pageRunner.FireEvent(PageControllerEvent.ValidateState); });
		}

		#endregion
	}
}
