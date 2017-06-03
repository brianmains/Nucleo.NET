using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.DataServices.Modules;
using Nucleo.DataServices.Modules.Configuration;
using Nucleo.DataServices.Results;


namespace Nucleo.DataServices
{
	[TestClass]
	public class DataServiceExecutorTest : DataServiceExecutor
	{
		#region " Tests "

		[TestMethod]
		public void CreatingExecutorWOrksOK()
		{
			//Arrange
			var executor = default(DataServiceExecutor);

			//Act
			executor = DataServiceExecutor.Create();

			//Assert
			Assert.IsNotNull(executor);
		}

		[TestMethod]
		public void GettingListOfModulesFromConfigurationWorksOK()
		{
			//Arrange
			var loader = new FakeModuleLoader();
			loader.LoadModules(new[]
				{
					FakeDataServiceModule.Create("Success"),
					FakeDataServiceModule.Create("Failed"),
					FakeDataServiceModule.Create("Success Again"),
					FakeDataServiceModule.Create("Success Last")
				}, new string[] { "1", "2", "3", "4" });
			var scheduler = new FakeDataServiceScheduler();
			scheduler.LoadIdentifiers(new[]
			{
				new ModuleIdentifier("1"),
				new ModuleIdentifier("2")
			});

			var executor = Isolate.Fake.Instance<DataServiceExecutorTest>(Members.CallOriginal);
			Isolate.WhenCalled(() => executor.GetLoaderFromConfiguration()).WillReturn(loader);
			Isolate.WhenCalled(() => executor.GetSchedulerFromConfiguration()).WillReturn(scheduler);

			//Act
			var modules = executor.GetModules(scheduler, loader);

			//Assert
			Assert.AreEqual(2, modules.Count());
			Assert.AreEqual("Success", modules.First().Execute().GetStatus());
			Assert.AreEqual("Failed", modules.Last().Execute().GetStatus());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingListOfModulesWorksOK()
		{
			//Arrange
			var executor = new DataServiceExecutorTest();

			var loader = new FakeModuleLoader();
			loader.LoadModules(new[]
				{
					FakeDataServiceModule.Create("Success"),
					FakeDataServiceModule.Create("Failed"),
					FakeDataServiceModule.Create("Success Again"),
					FakeDataServiceModule.Create("Success Last")
				}, new string[] { "1", "2", "3", "4" });
			var scheduler = new FakeDataServiceScheduler();
			scheduler.LoadIdentifiers(new[]
			{
				new ModuleIdentifier("1"),
				new ModuleIdentifier("4")
			});

			//Act
			var modules = executor.GetModules(scheduler, loader);

			//Assert
			Assert.AreEqual(2, modules.Count());
			Assert.AreEqual("Success", modules.First().Execute().GetStatus());
			Assert.AreEqual("Success Last", modules.Last().Execute().GetStatus());
		}

		[TestMethod]
		public void InvalidIdentifiersInListIgnoresEntries()
		{
			//Arrange
			var executor = new DataServiceExecutorTest();

			var loader = new FakeModuleLoader();
			loader.LoadModules(new[]
				{
					FakeDataServiceModule.Create("Success"),
					FakeDataServiceModule.Create("Failed"),
					FakeDataServiceModule.Create("Success Again"),
					FakeDataServiceModule.Create("Success Last")
				}, new string[] { "1", "2", "3", "4" });
			var scheduler = new FakeDataServiceScheduler();
			scheduler.LoadIdentifiers(new[]
			{
				new ModuleIdentifier("1"),
				new ModuleIdentifier("2"),
				new ModuleIdentifier("5")
			});

			//Act
			var modules = executor.GetModules(scheduler, loader);

			//Assert
			Assert.AreEqual(2, modules.Count());
			Assert.AreEqual("Success", modules[0].Execute().GetStatus());
			Assert.AreEqual("Failed", modules[1].Execute().GetStatus());
		}

		#endregion
	}
}
