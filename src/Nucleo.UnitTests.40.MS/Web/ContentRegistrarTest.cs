using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.Web.ButtonControls;
using Nucleo.Web.Description;


namespace Nucleo.Web
{
	[TestClass]
	public class ContentRegistrarTest
	{
		#region " Tests "

		[TestMethod]
		public void RegisteringComponentDescriptorAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();

			//Act
			registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails("ABC"));

			//Assert
			Assert.AreEqual(1, registrar.GetComponentDescriptors().Count);
		}

		[TestMethod]
		public void RegisteringDuplicateComponentDescriptorDoesntAdd()
		{
			//Arrange
			var registrar = new ContentRegistrar();
			registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails("ABC"));

			//Act
			registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails("ABC"));

			//Assert
			Assert.AreEqual(1, registrar.GetComponentDescriptors().Count);
		}

		[TestMethod]
		public void RegisteringCssReferencesAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();

			//Act
			registrar.AddCssReference(new CssReferenceRequestDetails("/Content/styles.css"));

			//Assert
			Assert.AreEqual(1, registrar.GetCssReferences().Count);
		}

		[TestMethod]
		public void RegisteringCssReferencesInDuplicateAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();

			//Act
			registrar.AddCssReference(new CssReferenceRequestDetails("/Content/styles.css"));
			registrar.AddCssReference(new CssReferenceRequestDetails("/Content/styles.css"));

			//Assert
			Assert.AreEqual(1, registrar.GetCssReferences().Count);
		}

		[TestMethod]
		public void RegisteringDescriptorAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();
			var controlFake = Isolate.Fake.Instance<Button>();
			Isolate.WhenCalled(() => controlFake.ClientID).WillReturn("TestID");

			var extenderFake = Isolate.Fake.Instance<ButtonEnabledExtender>();
			Isolate.WhenCalled(() => extenderFake.ClientID).WillReturn("TestButton");

			//Act
			registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
				controlFake, typeof(Button), controlFake.ClientID));
			registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
				extenderFake, typeof(ButtonEnabledExtender), extenderFake.ClientID));

			//Assert
			Assert.AreEqual(2, registrar.GetDescriptors().Count);
			Assert.IsInstanceOfType(registrar.GetDescriptors()[0], typeof(ScriptControlDescriptor));
			Assert.IsInstanceOfType(registrar.GetDescriptors()[1], typeof(ScriptBehaviorDescriptor));
		}

		[TestMethod]
		public void RegisteringDescriptorInDuplicateAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();
			var controlFake = Isolate.Fake.Instance<Button>();
			Isolate.WhenCalled(() => controlFake.ClientID).WillReturn("TestID");

			var extenderFake = Isolate.Fake.Instance<ButtonEnabledExtender>();
			Isolate.WhenCalled(() => extenderFake.ClientID).WillReturn("TestButton");

			//Act
			registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
				controlFake, typeof(Button), controlFake.ClientID));
			registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
				extenderFake, typeof(ButtonEnabledExtender), extenderFake.ClientID));

			registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
				controlFake, typeof(Button), controlFake.ClientID));
			registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
				extenderFake, typeof(ButtonEnabledExtender), extenderFake.ClientID));

			//Assert
			Assert.AreEqual(2, registrar.GetDescriptors().Count);
			Assert.IsInstanceOfType(registrar.GetDescriptors()[0], typeof(ScriptControlDescriptor));
			Assert.IsInstanceOfType(registrar.GetDescriptors()[1], typeof(ScriptBehaviorDescriptor));
		}

		[TestMethod]
		public void RegisteringDescriptorsInBulkAddsEntriesToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();
			var controlFake1 = Isolate.Fake.Instance<Button>();
			Isolate.WhenCalled(() => controlFake1.ClientID).WillReturn("FakeButton");
			var controlFake2 = Isolate.Fake.Instance<ButtonList>();
			Isolate.WhenCalled(() => controlFake2.ClientID).WillReturn("FakeButtonList");

			//Act
			var results = registrar.AddDescriptors(new ScriptDescriptionRequestDetailsCollection
			{
				new ScriptDescriptionRequestDetails(controlFake1, typeof(Button), controlFake1.ClientID),
				new ScriptDescriptionRequestDetails(controlFake2, typeof(ButtonList), controlFake2.ClientID)
			});

			//Assert
			Assert.AreEqual(2, results.Count, "Not 2 items");
		}

		[TestMethod]
		public void RegisteringReferenceAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();

			//Act
			registrar.AddReference(new ScriptReferencingRequestDetails(
				"path.js", ScriptMode.Debug));

			//Assert
			Assert.AreEqual(1, registrar.GetScripts().Count);
		}

		[TestMethod]
		public void RegisteringReferenceInDuplicateAddsToList()
		{
			//Arrange
			var registrar = new ContentRegistrar();

			//Act
			registrar.AddReference(new ScriptReferencingRequestDetails(
				"path.js", ScriptMode.Debug));
			registrar.AddReference(new ScriptReferencingRequestDetails(
				"path.js", ScriptMode.Debug));

			//Assert
			Assert.AreEqual(1, registrar.GetScripts().Count);
		}

		#endregion
	}
}
