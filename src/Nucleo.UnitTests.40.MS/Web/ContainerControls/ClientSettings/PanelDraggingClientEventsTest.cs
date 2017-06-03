using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.ContainerControls.ClientSettings
{
	[TestClass]
	public class PanelDraggingClientEventsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEventsWorksOK()
		{
			//Arrange
			var events = new PanelDraggingClientEvents();

			//Act
			events.OnClientDragEnding = "End";
			events.OnClientDragStarting = "Start";
			events.OnClientDropped = "Drop";

			//Assert
			Assert.AreEqual("End", events.OnClientDragEnding);
			Assert.AreEqual("Start", events.OnClientDragStarting);
			Assert.AreEqual("Drop", events.OnClientDropped);
		}

		[TestMethod]
		public void RegisteringDescriptorsWorksOK()
		{
			//Arrange
			var events = new PanelDraggingClientEvents();
			var descriptor = new FakeDescriptor();
			var registrar = Isolate.Fake.Instance<IContentRegistrar>();

			//Act
			events.OnClientDragEnding = "End";
			events.OnClientDragStarting = "Start";
			events.OnClientDropped = "Drop";
			((IScriptComponent)events).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.AreEqual(3, descriptor.References.Count);
			Assert.AreEqual("Start", descriptor.References[PanelDraggingClientEvents.DragStartingEventName]);
			Assert.AreEqual("End", descriptor.References[PanelDraggingClientEvents.DragEndingEventName]);
			Assert.AreEqual("Drop", descriptor.References[PanelDraggingClientEvents.DroppedEventName]);

			Isolate.CleanUp();
		}

		#endregion
	}
}
