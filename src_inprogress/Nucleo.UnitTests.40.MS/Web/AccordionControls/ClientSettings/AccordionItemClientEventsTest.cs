using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.AccordionControls.ClientSettings
{
	[TestClass]
	public class AccordionItemClientEventsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var events = new AccordionItemClientEvents();

			//Act
			events.OnClientClosed = "Cd";
			events.OnClientOpened = "Cg";
			events.OnClientSelected = "Od";

			//Assert
			Assert.AreEqual("Cd", events.OnClientClosed);
			Assert.AreEqual("Cg", events.OnClientOpened);
			Assert.AreEqual("Od", events.OnClientSelected);
		}

		[TestMethod]
		public void RegisteringAjaxDescriptorsWorksOK()
		{
			//Arrange
			var events = new AccordionItemClientEvents();
			events.OnClientClosed = "Cd";
			events.OnClientOpened = "Cg";
			events.OnClientSelected = "Od";

			var registrar = Isolate.Fake.Instance<IContentRegistrar>();
			var descriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)events).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.AreEqual("Cd", descriptor.References[AccordionItemClientEvents.ClosedEventName]);
			Assert.AreEqual("Cg", descriptor.References[AccordionItemClientEvents.OpenedEventName]);
			Assert.AreEqual("Od", descriptor.References[AccordionItemClientEvents.SelectedEventName]);

			Isolate.CleanUp();
		}

		#endregion
	}
}
