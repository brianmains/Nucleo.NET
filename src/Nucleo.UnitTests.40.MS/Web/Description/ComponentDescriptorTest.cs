using System;
using System.Web.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class ComponentDescriptorTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingForControlsExistenceReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			bool has = descriptor.HasControls;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForControlsExistenceReturnsTrue()
		{
			//Arrange
			var descriptor = Isolate.Fake.Instance<ComponentDescriptor>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(descriptor, "Controls").WillReturn(new ControlDescriptionCollection
			{
				{ "Login", Isolate.Fake.Instance<ScriptControl>() }
			});

			//Act
			bool has = descriptor.HasControls;

			//Assert
			Assert.AreEqual(true, has);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForControlsExistenceWhenCallingGetEventsAlsoReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			descriptor.GetControls();

			//Act
			bool has = descriptor.HasControls;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForElementsExistenceReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			bool has = descriptor.HasElements;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForElementsExistenceReturnsTrue()
		{
			//Arrange
			var descriptor = Isolate.Fake.Instance<ComponentDescriptor>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(descriptor, "Elements").WillReturn(new ElementDescriptionCollection
			{
				{ "login", "loginbox" }
			});

			//Act
			bool has = descriptor.HasElements;

			//Assert
			Assert.AreEqual(true, has);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForElementsExistenceWhenCallingGetEventsAlsoReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			descriptor.GetElements();

			//Act
			bool has = descriptor.HasElements;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForEventsExistenceReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			bool has = descriptor.HasEvents;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForEventsExistenceReturnsTrue()
		{
			//Arrange
			var descriptor = Isolate.Fake.Instance<ComponentDescriptor>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(descriptor, "Events").WillReturn(new EventDescriptionCollection
			{
				{ "init", "initialized" }
			});

			//Act
			bool has = descriptor.HasEvents;

			//Assert
			Assert.AreEqual(true, has);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForEventsExistenceWhenCallingGetEventsAlsoReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			descriptor.GetEvents();

			//Act
			bool has = descriptor.HasEvents;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForExtendersExistenceReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			bool has = descriptor.HasExtenders;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForExtendersExistenceReturnsTrue()
		{
			//Arrange
			var descriptor = Isolate.Fake.Instance<ComponentDescriptor>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(descriptor, "Extenders").WillReturn(new ExtenderDescriptionCollection
			{
				{ "Login", Isolate.Fake.Instance<ExtenderControl>() }
			});

			//Act
			bool has = descriptor.HasExtenders;

			//Assert
			Assert.AreEqual(true, has);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForExtendersExistenceWhenCallingGetEventsAlsoReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			descriptor.GetExtenders();

			//Act
			bool has = descriptor.HasExtenders;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForPropertiesExistenceReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			bool has = descriptor.HasProperties;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void CheckingForPropertiesExistenceReturnsTrue()
		{
			//Arrange
			var descriptor = Isolate.Fake.Instance<ComponentDescriptor>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(descriptor, "Properties").WillReturn(new PropertyDescriptionCollection
			{
				{ "text", "test text" }
			});

			//Act
			bool has = descriptor.HasProperties;

			//Assert
			Assert.AreEqual(true, has);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingForPropertiesExistenceWhenCallingGetPropertiesAlsoReturnsFalse()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			descriptor.GetProperties();

			//Act
			bool has = descriptor.HasProperties;

			//Assert
			Assert.AreEqual(false, has);
		}

		[TestMethod]
		public void RegisteringControlsAddsToList()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			var control = Isolate.Fake.Instance<ScriptControl>();

			//Act
			descriptor.RegisterControl("login", control);

			//Assert
			Assert.AreEqual(1, descriptor.GetControls().Count);
			Assert.AreEqual(control, descriptor.GetControls()["login"]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RegisteringElementsAddsToList()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			descriptor.RegisterElement("login", "loginbox");

			//Assert
			Assert.AreEqual(1, descriptor.GetElements().Count);
			Assert.AreEqual("loginbox", descriptor.GetElements()["login"]);
		}

		[TestMethod]
		public void RegisteringEventsAddsToList()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			descriptor.RegisterEvent("loaded", "testPageLoaded");
			descriptor.RegisterEvent("init", "testPageInit");

			//Assert
			Assert.AreEqual(2, descriptor.GetEvents().Count);
			Assert.AreEqual("testPageLoaded", descriptor.GetEvents()["loaded"]);
			Assert.AreEqual("testPageInit", descriptor.GetEvents()["init"]);
		}

		[TestMethod]
		public void RegisteringExtendersAddsToList()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");
			var extender = Isolate.Fake.Instance<ExtenderControl>();

			//Act
			descriptor.RegisterExtender("login", extender);

			//Assert
			Assert.AreEqual(1, descriptor.GetExtenders().Count);
			Assert.AreEqual(extender, descriptor.GetExtenders()["login"]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RegisteringPropertiesAddsToList()
		{
			//Arrange
			var descriptor = new ComponentDescriptor("Nucleo.Pages.TestPage");

			//Act
			descriptor.RegisterProperty("text", "Test Text");
			descriptor.RegisterProperty("title", "Test Title");
			descriptor.RegisterProperty("initialText", "Test Initial Text");

			//Assert
			Assert.AreEqual(3, descriptor.GetProperties().Count);
			Assert.AreEqual("Test Text", descriptor.GetProperties()["text"]);
			Assert.AreEqual("Test Title", descriptor.GetProperties()["title"]);
			Assert.AreEqual("Test Initial Text", descriptor.GetProperties()["initialText"]);
		}

		#endregion
	}
}
