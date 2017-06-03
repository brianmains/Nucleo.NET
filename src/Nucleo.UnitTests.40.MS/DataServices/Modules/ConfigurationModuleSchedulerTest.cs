using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.DataServices.Modules.Configuration;


namespace Nucleo.DataServices.Modules
{
	[TestClass]
	public class ConfigurationModuleSchedulerTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingModulesForExecutionReturnsResults()
		{
			//Arrange
			var section = new ModuleSettingsSection();
			section.ExecutingModules.Add(new ExecutingModuleElement { Name = "First" });
			section.ExecutingModules.Add(new ExecutingModuleElement { Name = "Second" });
			section.ExecutingModules.Add(new ExecutingModuleElement { Name = "Third" });
			section.ExecutingModules.Add(new ExecutingModuleElement { Name = "Fourth" });
			section.ExecutingModules.Add(new ExecutingModuleElement { Name = "Fifth" });

			Isolate.Fake.StaticMethods(typeof(ModuleSettingsSection));
			Isolate.WhenCalled(() => ModuleSettingsSection.Instance).WillReturn(section);

			var scheduler = new ConfigurationModuleScheduler();

			//Act
			var identifiers = scheduler.GetModulesForExecution();

			//Assert
			Assert.AreEqual(5, identifiers.Count);
			Assert.AreEqual("First", identifiers[0].Name);
			Assert.AreEqual("Second", identifiers[1].Name);
			Assert.AreEqual("Third", identifiers[2].Name);
			Assert.AreEqual("Fourth", identifiers[3].Name);
			Assert.AreEqual("Fifth", identifiers[4].Name);

			Isolate.CleanUp();
		}

		#endregion
	}
}
