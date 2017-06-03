using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock;
using TypeMock.ArrangeActAssert;

using Nucleo.EventArguments;
using Nucleo.Exceptions;
using Nucleo.State.Configuration;
using Nucleo.TestingTools;


namespace Nucleo.State
{
	[TestClass]
	public class StateManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingStatePropertyFiresEvent()
		{
			//Arrange
			var provider = new FakeStateValuesProvider();
			provider.Items.Add("Test", 111);

			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(managerFake, "GetDefaultProvider").WillReturn(provider);

			var propFake = Isolate.Fake.Instance<StateProperty>();
			Isolate.WhenCalled(() => propFake.Name).WillReturn("Test");

			var userFake = new StateUser("Test", true);

			//Act
			managerFake.SetStateValue(userFake, propFake, 123);

			//Assert
			Isolate.Verify.NonPublic.WasCalled(managerFake, "OnPropertyChanged");
		}

		[TestMethod]
		public void GettingManagerInstanceReturnsActualValue()
		{
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>();
			Isolate.WhenCalled(() => StateManagementSection.Instance).WillReturn(sectionFake);

			StateManager manager = StateManager.GetInstance();
			Assert.IsNotNull(manager);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingNullConfigurationThrowsException()
		{
			Isolate.WhenCalled(() => StateManagementSection.Instance).WillReturn(null);
			ExceptionTester.CheckException(true, (src) => { StateManager.GetInstance(); }, 
				"No configuration section definition didn't throw an exception");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPropertyReturnsCorrectObject()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>(Members.CallOriginal);
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "Configuration").WillReturn(sectionFake);

			sectionFake.StateProperties.Add(new StatePropertyElement { Name = "Days Without Accident", DefaultValue = 100 });

			//Act
			var property = managerFake.GetProperty("Days Without Accident");
			
			//Assert
			Assert.IsNotNull(property);
			Assert.AreEqual(100, property.DefaultValue);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPropertyWithNoEquivalentPropertyNameReturnsNull()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>(Members.CallOriginal);
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "Configuration").WillReturn(sectionFake);

			//Act
			var property1 = managerFake.GetProperty("Themed Prop DSSDF");
			var property2 = managerFake.GetProperty("Favorites Prop SDFSDF");

			//Assert
			Assert.IsNull(property1, "Themed property was not null");
			Assert.IsNull(property2, "Favorites property was not null");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPropertyWithNullNameThrowsException()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>();
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "Configuration").WillReturn(sectionFake);

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { managerFake.GetProperty(null); }, "Null property didn't throw");
			ExceptionTester.CheckException(true, (src) => { managerFake.GetProperty(string.Empty); }, "Empty property didn't throw");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingRegionPropertyWithNullNameThrowsException()
		{
			//Arrange
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { managerFake.GetRegionProperty("Reg", null); }, "Null property didn't throw");
			ExceptionTester.CheckException(true, (src) => { managerFake.GetRegionProperty("Reg", string.Empty); }, "Empty property didn't throw");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingRegionPropertyWithNullRegionThrowsException()
		{
			//Arrange
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { managerFake.GetRegionProperty(null, "Test"); }, "Null region didn't throw");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingRegionPropertyWorksOK()
		{
			//Arrange
			var region = new StateRegionElement { Name = "Default" };
			region.Properties.Add(new StatePropertyElement { Name = "Test", DefaultValue = "123" });
			region.Properties.Add(new StatePropertyElement { Name = "Test2", DefaultValue = "123" });

			var sectionFake = Isolate.Fake.Instance<StateManagementSection>(Members.CallOriginal);
			Isolate.WhenCalled(() => sectionFake.StateRegions).WillReturn(new StateRegionElementCollection { region });

			var managerFake = Isolate.Fake.Instance<StateManager>();
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "Configuration").WillReturn(sectionFake);
			Isolate.WhenCalled(() => managerFake.GetRegionProperty(null, null)).CallOriginal();

			//Act
			var property = managerFake.GetRegionProperty("Default", "Test");

			//Assert
			Assert.IsNotNull(property, "Property is null");
		}

		[TestMethod]
		public void GettingStateValueThatDoesntExistThrowsException()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>();
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(managerFake, "GetDefaultProvider").WillReturn(new FakeStateValuesProvider());

			var user = new StateUser("Test", true);

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { managerFake.GetStateValue(user, "SDFSDFSDFDSFFSDFFDFSD"); },
				"An invalid state value property name does not throw an exception");
			ExceptionTester.CheckException(true, (src) => { managerFake.GetStateValue(user, "SFEWTWET:KLJ:KLJ:LKJ"); },
				"An invalid state value property name does not throw an exception");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingStateValueWithNullValueThrowsException()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>();
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.NonPublic.WhenCalled(managerFake, "GetDefaultProvider").WillReturn(new FakeStateValuesProvider());

			var user = new StateUser("Test", true);

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { managerFake.GetStateValue(user, (StateProperty)null); },
				"Null value should have thrown exception");
			ExceptionTester.CheckException(true, (src) => { managerFake.GetStateValue(user, (string)null); },
				"Null value should have thrown exception");
			ExceptionTester.CheckException(true, (src) => { managerFake.GetStateValue(user, string.Empty); },
				"Empty value should have thrown exception");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingStateValueReturnsActualValue()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>();
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			Isolate.WhenCalled(() => managerFake.GetProperty("Application Name")).WillReturn(new StateProperty("Application Name", "Site Manager"));
			Isolate.WhenCalled(() => managerFake.GetProperty("Current Employee Count")).WillReturn(new StateProperty("Current Employee Count", 376));
			Isolate.NonPublic.WhenCalled(managerFake, "GetDefaultProvider").WillReturn(new FakeStateValuesProvider());

			var user = new StateUser("Test", true);

			//Act
			object value1 = managerFake.GetStateValue(user, "Application Name");
			object value2 = managerFake.GetStateValue(user, "Current Employee Count");
			
			//Assert
			Assert.IsNotNull(value1);
			Assert.IsInstanceOfType(value1, typeof(string));
			Assert.AreEqual("Site Manager", value1);
			
			Assert.IsNotNull(value2);
			Assert.IsInstanceOfType(value2, typeof(int));
			Assert.AreEqual(376, value2);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void MissingRegionNameOrPropertyReturnsNull()
		{
			//Arrange
			var region = new StateRegionElement { Name = "Default" };
			region.Properties.Add(new StatePropertyElement { Name = "Test", DefaultValue = "123" });
			region.Properties.Add(new StatePropertyElement { Name = "Test2", DefaultValue = "123" });

			var sectionFake = Isolate.Fake.Instance<StateManagementSection>(Members.CallOriginal);
			Isolate.WhenCalled(() => sectionFake.StateRegions).WillReturn(new StateRegionElementCollection { region });

			var managerFake = Isolate.Fake.Instance<StateManager>();
			Isolate.NonPublic.Property.WhenGetCalled(managerFake, "Configuration").WillReturn(sectionFake);
			Isolate.WhenCalled(() => managerFake.GetRegionProperty(null, null)).CallOriginal();

			//Act
			var prop1 = managerFake.GetRegionProperty("Default", "Test3");
			var prop2 = managerFake.GetRegionProperty("Test", "Test");

			//Assert
			Assert.IsNull(prop1, "Prop1 isn't null");
			Assert.IsNull(prop2, "Prop1 isn't null");
		}

		[TestMethod]
		public void SettingStateValueAssignsValue()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<StateManagementSection>();
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);
			var provider = new FakeStateValuesProvider();

			Isolate.WhenCalled(() => managerFake.GetProperty("Application Name")).WillReturn(new StateProperty("Application Name", "Site Manager"));
			Isolate.WhenCalled(() => managerFake.GetProperty("Current Employee Count")).WillReturn(new StateProperty("Current Employee Count", 376));
			Isolate.NonPublic.WhenCalled(managerFake, "GetDefaultProvider").WillReturn(provider);

			var user = new StateUser("Test", true);

			//Act
			managerFake.SetStateValue(user, "Application Name", "New Test");
			managerFake.SetStateValue(user, "Current Employee Count", 5);

			//Assert
			Assert.AreEqual(provider.Items["Application Name"], "New Test");
			Assert.AreEqual(provider.Items["Current Employee Count"], 5);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingStateValueWithNullPropertyThrowsException()
		{
			//Arrange
			var managerFake = Isolate.Fake.Instance<StateManager>(Members.CallOriginal);

			var user = new StateUser("Test", true);

			//Act/Assert
			ExceptionTester.CheckException(true, (src) => { managerFake.SetStateValue(user, (StateProperty)null, 123); }, "Null state property didn't throw exception");
			ExceptionTester.CheckException(true, (src) => { managerFake.SetStateValue(user, (string)null, 123); }, "Null state property name didn't throw exception");
			ExceptionTester.CheckException(true, (src) => { managerFake.SetStateValue(user, string.Empty, 123); }, "Empty state property name didn't throw exception");

			Isolate.CleanUp();
		}

		#endregion
	}
}