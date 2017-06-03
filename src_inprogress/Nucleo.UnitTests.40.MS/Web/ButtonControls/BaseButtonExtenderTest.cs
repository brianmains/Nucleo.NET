using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;
using Nucleo.Web.Pages;


namespace Nucleo.Web.ButtonControls
{
	[TestClass]
	public class BaseButtonExtenderTest
	{
		#region " Test Classes "

		public class BaseButtonExtenderTestControl : BaseButtonExtender
		{

		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void EnsuringReceiverControlIDExistsRunsOKWhenNotNull()
		{
			//Arrange
			var ext = new BaseButtonExtenderTestControl { RegisterWithScriptManager = false };
			var page = new FakePage(ext);
			ext.TargetControlID = "C";
			ext.ReceiverControlID = "A";

			//Act


			//Assert
			ExceptionTester.CheckException(false, (src) => { page.FireEvent(PageEvent.PreRender); });
		}

		[TestMethod]
		public void EnsuringReceiverControlIDExistsThrowsExceptionWhenNull()
		{
			//Arrange
			var ext = new BaseButtonExtenderTestControl();
			var page = new FakePage(ext);

			//Act
			

			//Assert
			ExceptionTester.CheckException(true, (src) => { page.FireEvent(PageEvent.PreRender); });
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var ext = new BaseButtonExtenderTestControl();

			//Act
			ext.AllowPostback = true;
			ext.ReceiverControlID = "T";

			//Assert
			Assert.AreEqual(true, ext.AllowPostback);
			Assert.AreEqual("T", ext.ReceiverControlID);
		}

		#endregion
	}
}
