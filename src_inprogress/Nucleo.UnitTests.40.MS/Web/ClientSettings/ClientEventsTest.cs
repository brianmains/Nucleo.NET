using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.ClientSettings
{
	[TestClass]
	public class ClientEventsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var events = new ClientEvents();

			//Act
			events.OnClientClicked = "0";
			events.OnClientDoubleClicked = "1";
			events.OnClientGotFocus = "2";
			events.OnClientKeyAfterPress = "3";
			events.OnClientKeyBeforePress = "4";
			events.OnClientKeyPressed = "5";
			events.OnClientLostFocus = "6";
			events.OnClientMousedDown = "7";
			events.OnClientMousedOut = "8";
			events.OnClientMousedOver = "9";
			events.OnClientMousedUp = "10";
			events.OnClientMouseMove = "11";

			//Assert
			Assert.AreEqual("0", events.OnClientClicked);
			Assert.AreEqual("1", events.OnClientDoubleClicked);
			Assert.AreEqual("2", events.OnClientGotFocus);
			Assert.AreEqual("3", events.OnClientKeyAfterPress);
			Assert.AreEqual("4", events.OnClientKeyBeforePress);
			Assert.AreEqual("5", events.OnClientKeyPressed);
			Assert.AreEqual("6", events.OnClientLostFocus);
			Assert.AreEqual("7", events.OnClientMousedDown);
			Assert.AreEqual("8", events.OnClientMousedOut);
			Assert.AreEqual("9", events.OnClientMousedOver);
			Assert.AreEqual("10", events.OnClientMousedUp);
			Assert.AreEqual("11", events.OnClientMouseMove);
		}

		[TestMethod]
		public void RegisteringAjaxDescriptorsWorksOK()
		{
			//Arrange
			var events = new ClientEvents();
			events.OnClientClicked = "0";
			events.OnClientDoubleClicked = "1";
			events.OnClientGotFocus = "2";
			events.OnClientKeyAfterPress = "3";
			events.OnClientKeyBeforePress = "4";
			events.OnClientKeyPressed = "5";
			events.OnClientLostFocus = "6";
			events.OnClientMousedDown = "7";
			events.OnClientMousedOut = "8";
			events.OnClientMousedOver = "9";
			events.OnClientMousedUp = "10";
			events.OnClientMouseMove = "11";

			var registrar = Isolate.Fake.Instance<IContentRegistrar>();
			var descriptor = new FakeDescriptor();

			//Act
			((IScriptComponent)events).RegisterAjaxDescriptors(registrar, descriptor);

			//Assert
			Assert.AreEqual("0", descriptor.References[ClientEvents.ClickedEventName]);
			Assert.AreEqual("1", descriptor.References[ClientEvents.DoubleClickedEventName]);
			Assert.AreEqual("2", descriptor.References[ClientEvents.GotFocusEventName]);
			Assert.AreEqual("3", descriptor.References[ClientEvents.KeyAfterPressEventName]);
			Assert.AreEqual("4", descriptor.References[ClientEvents.KeyBeforePressEventName]);
			Assert.AreEqual("5", descriptor.References[ClientEvents.KeyPressedEventName]);
			Assert.AreEqual("6", descriptor.References[ClientEvents.LostFocusEventName]);
			Assert.AreEqual("7", descriptor.References[ClientEvents.MousedDownEventName]);
			Assert.AreEqual("8", descriptor.References[ClientEvents.MousedOutEventName]);
			Assert.AreEqual("9", descriptor.References[ClientEvents.MousedOverEventName]);
			Assert.AreEqual("10", descriptor.References[ClientEvents.MousedUpEventName]);
			Assert.AreEqual("11", descriptor.References[ClientEvents.MouseMoveEventName]);

			Isolate.CleanUp();
		}

		#endregion
	}
}