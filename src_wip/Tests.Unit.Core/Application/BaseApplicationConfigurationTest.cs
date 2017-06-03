using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Application
{
	[TestClass]
	public class BaseApplicationConfigurationTest
	{
		protected class TestApplicationConfiguration : BaseApplicationConfiguration
		{
			protected override void Configure()
			{
				
			}
		}


		[TestMethod]
		public void InitializingRegistersConfiguration()
		{
			var configs = Isolate.Fake.Instance<IApplicationConfigurations>();
			var test = new TestApplicationConfiguration();

			((IApplicationConfiguration)test).Initialize(configs);

			Isolate.Verify.WasCalledWithAnyArguments(() => configs.Configurations.Add(null));

			Isolate.CleanUp();
		}
	}
}
