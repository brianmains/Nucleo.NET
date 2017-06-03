using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Models.Cache;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Application
{
	[TestClass]
	public class MvpApplicationConfigurationsExtensionsTest
	{
		[TestMethod]
		public void CreatingMvpStructureCallsFrameworkMethods()
		{
			var mvp = Isolate.Fake.Instance<MvpApplicationConfiguration>();
			Isolate.Swap.NextInstance<MvpApplicationConfiguration>().With(mvp);

			var cfg = Isolate.Fake.Instance<IApplicationConfigurations>();

			cfg.Mvp((b) => { });

			Isolate.Verify.WasCalledWithAnyArguments(() => { ((IApplicationConfiguration)mvp).Initialize(null); });
			Isolate.Verify.WasCalledWithAnyArguments(() => { ((IApplicationConfiguration)mvp).Configure(); });
			Isolate.CleanUp();
		}

		[TestMethod]
		public void MvpServicesAssignOK()
		{
			var mvp = Isolate.Fake.Instance<MvpApplicationConfiguration>();
			Isolate.Swap.NextInstance<MvpApplicationConfiguration>().With(mvp);

			var cfg = Isolate.Fake.Instance<IApplicationConfigurations>();
			var cache = Isolate.Fake.Instance<Nucleo.Models.Cache.IModelCache>();

			cfg.Mvp((b) =>
			{
				b.ModelCache = cache;
			});

			Isolate.Verify.WasCalledWithAnyArguments(() => mvp.ModelCache = cache);
			Isolate.CleanUp();
		}
	}
}
