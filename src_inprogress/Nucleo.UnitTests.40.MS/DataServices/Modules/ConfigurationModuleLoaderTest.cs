using System;
using System.Linq;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.DataServices.Modules.Configuration;


namespace Nucleo.DataServices.Modules
{
	[TestClass]
	public class ConfigurationModuleLoaderTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingModulesFromConfigurationWorksOK()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<ModuleSettingsSection>(Members.CallOriginal);
			sectionFake.Modules.Add(new ModuleElement { Name = "1", Type = "Nucleo.DataServices.Modules.FakeDataServiceModule," + typeof(FakeDataServiceModule).Assembly.FullName });
			sectionFake.Modules.Add(new ModuleElement { Name = "2", Type = "Nucleo.DataServices.Modules.FakeDataServiceModule," + typeof(FakeDataServiceModule).Assembly.FullName });
			sectionFake.Modules.Add(new ModuleElement { Name = "3", Type = "Nucleo.DataServices.Modules.FakeDataServiceModule," + typeof(FakeDataServiceModule).Assembly.FullName });
			sectionFake.Modules.Add(new ModuleElement { Name = "4", Type = "Nucleo.DataServices.Modules.FakeDataServiceModule," + typeof(FakeDataServiceModule).Assembly.FullName });
			sectionFake.Modules.Add(new ModuleElement { Name = "5", Type = "Nucleo.DataServices.Modules.FakeDataServiceModule," + typeof(FakeDataServiceModule).Assembly.FullName });

			Isolate.WhenCalled(() => ModuleSettingsSection.Instance).WillReturn(sectionFake);

			var loader = new ConfigurationModuleLoader();

			//Act
			var outputModules = loader.GetModules(new ModuleIdentifier[]
			{
				new ModuleIdentifier("1"),
				new ModuleIdentifier("3"),
				new ModuleIdentifier("5")
			});

			//Assert
			Assert.AreEqual(3, outputModules.Count());

			Isolate.CleanUp();
		}

		#endregion
	}
}
