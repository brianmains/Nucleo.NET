using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.State;


namespace Nucleo.Context.Services
{
	[TestClass]
	public class StateManagementServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingStateValueWithPropertyWorksOK()
		{
			//Arrange
			var stateManager = Isolate.Fake.Instance<StateManager>();
			Isolate.WhenCalled(() => stateManager.GetStateValue(null, default(StateProperty))).WillReturn(123);
			Isolate.WhenCalled(() => StateManager.GetInstance()).WillReturn(stateManager);

			//Act
			var service = new StateManagementService();
			var value = service.GetStateValue(new StateUser("TestUser", true), new StateProperty("Test", 900));

			//Assert
			Assert.AreEqual(123, value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingStateValueWithPropertyNameWorksOK()
		{
			//Arrange
			var stateManager = Isolate.Fake.Instance<StateManager>();
			Isolate.WhenCalled(() => stateManager.GetStateValue(null, default(string))).WillReturn(123);
			Isolate.WhenCalled(() => StateManager.GetInstance()).WillReturn(stateManager);

			//Act
			var service = new StateManagementService();
			var value = service.GetStateValue(new StateUser("TestUser", true), "Test");

			//Assert
			Assert.AreEqual(123, value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingStateValueWithPropertyWorksOK()
		{
			//Arrange
			var stateManager = Isolate.Fake.Instance<StateManager>();
			Isolate.WhenCalled(() => stateManager.SetStateValue(null, default(StateProperty), null)).IgnoreCall();
			Isolate.WhenCalled(() => StateManager.GetInstance()).WillReturn(stateManager);

			//Act
			var service = new StateManagementService();
			service.SetStateValue(new StateUser("TestUser", true), new StateProperty("Test", 900), 456);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => stateManager.SetStateValue(null, default(StateProperty), null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingStateValueWithPropertyNameWorksOK()
		{
			//Arrange
			var stateManager = Isolate.Fake.Instance<StateManager>();
			Isolate.WhenCalled(() => stateManager.SetStateValue(null, default(string), null)).IgnoreCall();
			Isolate.WhenCalled(() => StateManager.GetInstance()).WillReturn(stateManager);

			//Act
			var service = new StateManagementService();
			service.SetStateValue(new StateUser("TestUser", true), "Test", 456);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => stateManager.SetStateValue(null, default(string), null));

			Isolate.CleanUp();
		}

		#endregion
	}
}
