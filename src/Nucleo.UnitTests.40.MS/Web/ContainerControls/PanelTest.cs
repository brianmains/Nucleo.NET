using System;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;
using Nucleo.Web.Pages;
using Nucleo.Web.ContainerControls.ClientSettings;
using Nucleo.Web.Templates;


namespace Nucleo.Web.ContainerControls
{
	[TestClass]
	public class PanelTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningPropsWorksOK()
		{
			//Arrange
			var panel = new Panel();
			var content = Isolate.Fake.Instance<ControlElementTemplate>();
			var dragDrop = Isolate.Fake.Instance<PanelDragDropOptions>();
			var hover = Isolate.Fake.Instance<PanelHoverOptions>();
			var modal = Isolate.Fake.Instance<PanelModalOptions>();
			var resizing = Isolate.Fake.Instance<PanelResizeOptions>();
			var time = Isolate.Fake.Instance<PanelTimeSensitivityOptions>();

			//Act
			panel.Content = content;
			panel.DragDrop = dragDrop;
			panel.Hovering = hover;
			panel.Modal = modal;
			panel.Resizing = resizing;
			panel.TimeSensitivity = time;
			panel.Title = "Test";

			//Assert
			Assert.AreEqual(content, panel.Content);
			Assert.AreEqual(dragDrop, panel.DragDrop);
			Assert.AreEqual(hover, panel.Hovering);
			Assert.AreEqual(modal, panel.Modal);
			Assert.AreEqual(resizing, panel.Resizing);
			Assert.AreEqual(time, panel.TimeSensitivity);
			Assert.AreEqual("Test", panel.Title);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void DragDropClientEventsGetsRegistered()
		{
			//Arrange
			var panel = new Panel();
			var clientEvents = Isolate.Fake.Instance<PanelDraggingClientEvents>();
			var dragDrop = Isolate.Fake.Instance<PanelDragDropOptions>();
			Isolate.WhenCalled(() => dragDrop.ClientEvents).WillReturn(clientEvents);

			panel.DragDrop = dragDrop;

			//Act
			panel.NonPublic().Method("AddScriptComponents").Invoke();

			//Assert
			Assert.AreEqual(1, panel.ScriptComponents.Count);
			Assert.AreEqual(clientEvents, panel.ScriptComponents[0]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PreRenderWithHoveringFindClientID()
		{
			//Arrange
			var page = new FakePage();
			var panel = new Panel();
			panel.Page = page;

			var hover = Isolate.Fake.Instance<PanelHoverOptions>(Members.CallOriginal);
			hover.ControlID = "SomeControlID";
			panel.Hovering = hover;

			var control = Isolate.Fake.Instance<TextBox>();
			Isolate.WhenCalled(() => control.ClientID).WillReturn("SomeControlID");

			Isolate.Fake.StaticMethods(typeof(ControlUtility));
			Isolate.WhenCalled(() => ControlUtility.FindControl(panel, "SomeControlID")).WillReturn(control);

			//Act
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Assert.AreEqual("SomeControlID", panel.Hovering.ControlID);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PreRenderWithModalFindClientID()
		{
			//Arrange
			var page = new FakePage();
			var panel = new Panel();
			panel.Page = page;

			var modal = Isolate.Fake.Instance<PanelModalOptions>(Members.CallOriginal);
			modal.OKButtonID = "SomeControlID";
			panel.Modal = modal;

			var control = Isolate.Fake.Instance<TextBox>();
			Isolate.WhenCalled(() => control.ClientID).WillReturn("MyNewID");

			Isolate.Fake.StaticMethods(typeof(ControlUtility));
			Isolate.WhenCalled(() => ControlUtility.FindControl(panel, "SomeControlID")).WillReturn(control);

			//Act
			page.FireEvent(PageEvent.PreRender);

			//Assert
			Assert.AreEqual("SomeControlID", panel.Modal.OKButtonID);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void TimeSensitivityInRangeButCoreVisiblePropertyIsFalseHidesPanel()
		{
			//Arrange
			var panel = new Panel();
			panel.Visible = false;
			var time = Isolate.Fake.Instance<PanelTimeSensitivityOptions>();
			Isolate.WhenCalled(() => time.IsVisible).WillReturn(true);
			panel.TimeSensitivity = time;

			//Act
			bool visible = panel.Visible;

			//Assert
			Assert.AreEqual(false, visible);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void TimeSensitivityInRangeShowsPanel()
		{
			//Arrange
			var panel = new Panel();
			var time = Isolate.Fake.Instance<PanelTimeSensitivityOptions>();
			Isolate.WhenCalled(() => time.IsVisible).WillReturn(true);
			panel.TimeSensitivity = time;

			//Act
			bool visible = panel.Visible;

			//Assert
			Assert.AreEqual(true, visible);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void TimeSensitivityOutOfRangeHidesPanel()
		{
			//Arrange
			var panel = new Panel();
			var time = Isolate.Fake.Instance<PanelTimeSensitivityOptions>();
			Isolate.WhenCalled(() => time.IsVisible).WillReturn(false);
			panel.TimeSensitivity = time;

			//Act
			bool visible = panel.Visible;

			//Assert
			Assert.AreEqual(false, visible);

			Isolate.CleanUp();
		}

		#endregion
	}
}
