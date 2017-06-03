using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;


namespace Nucleo.Context.Providers
{
	[TestClass]
	public class FakeApplicationContextServiceRegistryTest
	{
		#region " Tests "
		
		[TestMethod]
		public void LoadingServicesWorksOK()
		{
			//Arrange
			var source = Isolate.Fake.Instance<TypeRegistry>();

			var reg = new InMemoryApplicationContextServiceRegistry(source);

			//Act
			var output = Isolate.Fake.Instance<TypeRegistry>();
			reg.LoadServices(output);

			//Assert
			Isolate.Verify.WasCalledWithExactArguments(() => output.CopyFrom(source));

			Isolate.CleanUp();
		}

		#endregion
	}
}
