using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Pages;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlTestingUtilityTest
	{
		#region " Tests "

		[TestMethod]
		public void AppendingHeaderToControlAddsHeaderSuccessfully()
		{
			//Arrange
			Page page = new Page();

			//Act
			ControlTestingUtility.AppendHeaderToPage(page);

			//Assert
			Assert.IsNotNull(page.Header);
		}

		[TestMethod]
		public void CreatingSingleInstanceControlReturnsCorrectReference()
		{
			//Arrange

			//Act
			var control = ControlTestingUtility.CreateSingleInstanceControl<NucleoAjaxManager>();

			//Assert
			Assert.IsNotNull(control);
			Assert.IsNotNull(control.Page);
			Assert.AreEqual(control, control.Page.Controls[0]);
			Assert.IsNotNull(control.Page.Items[typeof(NucleoAjaxManager)]);
		}

		[TestMethod]
		public void FiringPageEventFiresSuccessfully()
		{
			//Arrange
			var page = new Page();

			//Act
			ControlTestingUtility.FirePageEvent(page, PageEvent.Init);
			ControlTestingUtility.FirePageEvent(page, PageEvent.Load);
			ControlTestingUtility.FirePageEvent(page, PageEvent.PreRender, System.EventArgs.Empty);

			//Assert
			
		}

		#endregion
	}
}
