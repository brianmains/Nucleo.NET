using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.AccordionControls.ClientSettings
{
	[TestClass]
	public class AccordionClientEventsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var events = new AccordionClientEvents();

			//Act
			events.OnClientItemClosed = "Cd";
			events.OnClientItemClosing = "Cg";
			events.OnClientItemOpened = "Od";
			events.OnClientItemOpening = "Og";

			//Assert
			Assert.AreEqual("Cd", events.OnClientItemClosed);
			Assert.AreEqual("Cg", events.OnClientItemClosing);
			Assert.AreEqual("Od", events.OnClientItemOpened);
			Assert.AreEqual("Og", events.OnClientItemOpening);
		}

		[TestMethod]
		public void RegisteringAjaxDescriptorsWorksOK()
		{
			//Arrange
			var events = new AccordionClientEvents();
			events.OnClientItemClosed = "Cd";
			events.OnClientItemClosing = "Cg";
			events.OnClientItemOpened = "Od";
			events.OnClientItemOpening = "Og";

			var registrar = Isolate.Fake.Instance<IContentRegistrar>();
			var descriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)events).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.AreEqual("Cd", descriptor.References[AccordionClientEvents.ItemClosedEventName]);
			Assert.AreEqual("Cg", descriptor.References[AccordionClientEvents.ItemClosingEventName]);
			Assert.AreEqual("Od", descriptor.References[AccordionClientEvents.ItemOpenedEventName]);
			Assert.AreEqual("Og", descriptor.References[AccordionClientEvents.ItemOpeningEventName]);

			Isolate.CleanUp();
		}

		#endregion
	}
}
