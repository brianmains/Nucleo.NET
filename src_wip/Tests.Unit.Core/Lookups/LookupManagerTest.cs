using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.Lookups.Configuration;
using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Providers;
using Nucleo.Lookups.Repositories;



namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingManagerWorksOK()
		{
			LookupManager.Create();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GettingLookupRepositoryWithNullRegistrationsThrowsException()
		{
			var id = Isolate.Fake.Instance<ILookupIdentifier>();
			var mgr = Isolate.Fake.Instance<LookupManager>(Members.CallOriginal, ConstructorWillBe.Ignored);

			mgr.GetLookupRepository(null);
		}

		[TestMethod]
		public void GettingLookupRepositoryWithNoRegistrationsReturnsNull()
		{

		}

		[TestMethod]
		public void GettingLookupRepositoryWithNoSupportReturnsNull()
		{
			var id = Isolate.Fake.Instance<ILookupIdentifier>();
			var repos = Isolate.Fake.Instance<ILookupRepository>();

			var provider = Isolate.Fake.Instance<ILookupProvider>();
			Isolate.WhenCalled(() => provider.SupportsIdentifier(null)).WillReturn(false);
			Isolate.WhenCalled(() => provider.GetRepository(null)).WillReturn(repos);

			var mgr = Isolate.Fake.Instance<LookupManager>(Members.CallOriginal, ConstructorWillBe.Ignored);
			mgr.Register(provider);

			var output = mgr.GetLookupRepository(id);

			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingLookupRepositoryWorksOK()
		{
			var id = Isolate.Fake.Instance<ILookupIdentifier>();
			var repos = Isolate.Fake.Instance<ILookupRepository>();

			var provider = Isolate.Fake.Instance<ILookupProvider>();
			Isolate.WhenCalled(() => provider.SupportsIdentifier(null)).WillReturn(true);
			Isolate.WhenCalled(() => provider.GetRepository(null)).WillReturn(repos);

			var mgr = Isolate.Fake.Instance<LookupManager>(Members.CallOriginal, ConstructorWillBe.Ignored);
			mgr.Register(provider);

			var output = mgr.GetLookupRepository(id);

			Assert.IsNotNull(output);
			Assert.AreEqual(repos, output);
		}

		[TestMethod]
		public void RegisteringMultipleProvidersWorksOK()
		{
			var provider1 = Isolate.Fake.Instance<ILookupProvider>();
			var provider2 = Isolate.Fake.Instance<ILookupProvider>();
			var provider3 = Isolate.Fake.Instance<ILookupProvider>();
			var mgr = Isolate.Fake.Instance<LookupManager>(Members.CallOriginal, ConstructorWillBe.Ignored);
			mgr.Register(provider1);
			mgr.Register(provider2);
			mgr.Register(provider3);

			Assert.AreEqual(3, mgr.ProviderCount);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void RegisteringNullProviderWorksOK()
		{
			var mgr = Isolate.Fake.Instance<LookupManager>(Members.CallOriginal, ConstructorWillBe.Ignored);
			mgr.Register(null);
		}

		[TestMethod]
		public void RegisteringProvidersWorksOK()
		{
			var provider = Isolate.Fake.Instance<ILookupProvider>();
			var mgr = Isolate.Fake.Instance<LookupManager>(Members.CallOriginal, ConstructorWillBe.Ignored);
			mgr.Register(provider);

			Assert.AreEqual(1, mgr.ProviderCount);
		}

		#endregion
	}
}
