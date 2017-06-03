using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Context.Providers;


namespace Nucleo.Models.Contracts
{
	[TestClass]
	public class ContractModelDataLoaderTest
	{
		#region " Test Classes "

		protected class TestClass { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingMetadataWithNoServiceReturnsNull()
		{
			//Arrange
			var loader = new ContractModelDataLoader(null);

			//Act
			var result = loader.GetModelData(null);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void GettingMetadataWithValidServiceReturnsNull()
		{
			//Arrange
			var cls = new TestClass();
			var service = Isolate.Fake.Instance<IDependencyInjectionService>();
			Isolate.WhenCalled(() => service.Resolve(null)).WillReturn(cls);
			var loader = new ContractModelDataLoader(service);

			var metadata = Isolate.Fake.Instance<ModelMemberMetadata>();
			Isolate.WhenCalled(() => metadata.ValueType).WillReturn(typeof(TestClass));

			//Act
			var result = loader.GetModelData(metadata);

			//Assert
			Assert.AreEqual(cls, result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ServiceLoadsFromApplicationContext()
		{
			//Arrange
			var service = Isolate.Fake.Instance<IDependencyInjectionService>();

			var ctx = Isolate.Fake.Instance<ApplicationContext>();
			Isolate.WhenCalled(() => ctx.GetService<IDependencyInjectionService>()).WillReturn(service);
			Isolate.Fake.StaticMethods(typeof(ApplicationContext));
			Isolate.WhenCalled(() => ApplicationContext.GetCurrent()).WillReturn(ctx);
			
			//Act
			var loader = new ContractModelDataLoader();

			//Assert
			Isolate.Verify.WasCalledWithExactArguments(() => ctx.GetService<IDependencyInjectionService>());

			Isolate.CleanUp();
		}

		#endregion
	}
}
