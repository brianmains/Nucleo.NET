using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ButtonControls.ClientSettings
{
	[TestClass]
	public class ButtonClientEventsTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingScriptDescriptorWorksOK()
		{
			//Arrange
			var obj = new ButtonClientEvents();
			obj.OnClientNeedPostback = "Button_NeedPostback";

			var registrar = new ContentRegistrar();
			var descriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)obj).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.AreEqual(1, descriptor.References.Count);
			Assert.AreEqual("Button_NeedPostback", descriptor.References["needPostback"]);
		}

		[TestMethod]
		public void AssigningEventsWorksOK()
		{
			//Arrange
			var obj = new ButtonClientEvents();

			//Act
			obj.OnClientNeedPostback = "Button_NeedPostback";

			//Assert
			Assert.AreEqual("Button_NeedPostback", obj.OnClientNeedPostback);
		}

		#endregion
	}
}
