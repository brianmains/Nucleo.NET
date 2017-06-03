using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.Context.Configuration;
using Nucleo.Context.Providers;
using Nucleo.Context.Services;

using Nucleo.Configuration;


namespace Nucleo.Context
{
	[TestClass]
	public class ApplicationContextTest
	{
		#region " Test Classes "

		public interface IFakeNameService : IService
		{
			string GetGreeting(string name);
		}

		public class FakeNameService : IFakeNameService
		{
			#region " Methods "

			public string GetGreeting(string name)
			{
				return "Hello, " + name;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingContextInstantiatesConfigurationProvider()
		{
			//Arrange
			var section = new ContextSettingsSection();
			section.ServiceRegistryType = null;
			section.Services.Add(new TypeRegistrationElement 
			{ 
				ContractTypeName = typeof(IFakeNameService).AssemblyQualifiedName,
				MappedTypeName = typeof(FakeNameService).AssemblyQualifiedName
			});

			Isolate.Fake.StaticMethods(typeof(ContextSettingsSection));
			Isolate.WhenCalled(() => ContextSettingsSection.Instance).WillReturn(section);

			//Act
			var context = ApplicationContext.GetCurrent();

			//Assert
			Assert.IsNotNull(context);
			Assert.IsNotNull(context.GetService<IFakeNameService>());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingContextInstantiatesSuccessfully()
		{
			//Arrange
			var settingsFake = Isolate.Fake.Instance<ContextSettingsSection>(Members.CallOriginal);
			Isolate.WhenCalled(() => settingsFake.ServiceRegistryType).WillReturn(typeof(InMemoryApplicationContextServiceRegistry).AssemblyQualifiedName);

			Isolate.Fake.StaticMethods(typeof(ContextSettingsSection));
			Isolate.WhenCalled(() => ContextSettingsSection.Instance).WillReturn(settingsFake);
			
			//Act
			var context = ApplicationContext.GetCurrent();

			//Assert
			Assert.IsNotNull(context);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingContextWithRegistryInstantiatesSuccessfully()
		{
			//Arrange
			var typeRegistry = Isolate.Fake.Instance<IApplicationContextServiceRegistry>();

			//Act
			var context = ApplicationContext.GetCurrent(typeRegistry);

			//Assert
			Assert.IsNotNull(context);
			Isolate.Verify.WasCalledWithAnyArguments(() => typeRegistry.LoadServices(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingContextWithInvalidServiceRegistryTypeThrowsException()
		{
			//Arrange
			var settingsFake = Isolate.Fake.Instance<ContextSettingsSection>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => settingsFake.ServiceRegistryType).WillReturn(typeof(FakeNameService).AssemblyQualifiedName);

			Isolate.Fake.StaticMethods(typeof(ContextSettingsSection));
			Isolate.WhenCalled(() => ContextSettingsSection.Instance).WillReturn(settingsFake);

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { ApplicationContext.GetCurrent(); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingContextWithNoConfigReturnsNull()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ContextSettingsSection));
			Isolate.WhenCalled(() => ContextSettingsSection.Instance).WillReturn(null);

			//Act
			var context = ApplicationContext.GetCurrent();
			
			//Assert
			Assert.IsNull(context, "Context wasn't null");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingServicesReturnsCorrectValues()
		{
			//Arrange
			
		}

		#endregion
	}
}
