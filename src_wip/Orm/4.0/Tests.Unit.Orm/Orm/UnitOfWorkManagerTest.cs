using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Orm.Caching;
using Nucleo.Orm.Creation;
using Nucleo.Orm.Configuration;
using Nucleo.Orm.Discovery;


namespace Nucleo.Orm
{
	[TestClass]
	public class UnitOfWorkManagerTest
	{
        protected class TestUOW : IUnitOfWork
        {
            public TestUOW() { }

            public void SaveChanges() { }
        }



		#region " Tests "

		[TestMethod]
		public void CachingDiscoveredUnitOfWorkSetsToCache()
		{
			//Arrange
			var strategy = Isolate.Fake.Instance<IUnitOfWorkDiscoveryStrategy>();
            Isolate.WhenCalled(() => strategy.LocateUnitOfWork(null)).WillReturn(new UnitOfWorkDiscoveryResults
                {
                    UnitOfWorkType = typeof(TestUOW)
                });
			var caching = Isolate.Fake.Instance<IUnitOfWorkCaching>();
			Isolate.WhenCalled(() => caching.GetUnitOfWork(null)).WillReturn(null);

			//Act
			var mgr = UnitOfWorkManager.Create(new UnitOfWorkManagerOptions
			{
				DiscoveryStrategy = strategy,
				Caching = caching
			});
			var output = mgr.LocateUnitOfWork("Test");

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => { caching.SaveUnitOfWork("Test", null); });
			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ConfigurationErrorsException)),
		Isolated
		]
		public void CreatingFromConfigWhenConfigDoesntExistThrowsException()
		{
			Isolate.Fake.StaticMethods(typeof(UnitOfWorkSection));
			Isolate.WhenCalled(() => UnitOfWorkSection.Instance).WillReturn(null);

			UnitOfWorkManager.Create();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullOptionsThrowsException()
		{
			UnitOfWorkManager.Create(null);
		}

		[TestMethod]
		public void CreatingWithOptionsAssignsOK()
		{
			var caching = Isolate.Fake.Instance<IUnitOfWorkCaching>();
			var creator = Isolate.Fake.Instance<IUnitOfWorkCreator>();
			var discovery = Isolate.Fake.Instance<IUnitOfWorkDiscoveryStrategy>();

			var mgr = UnitOfWorkManager.Create(new UnitOfWorkManagerOptions
				{
					Caching = caching,
					Creator = creator,
					DiscoveryStrategy = discovery
				});

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void LocatingEmptyUnitOfWorkThrowsException()
		{
			var uow = Isolate.Fake.Instance<UnitOfWorkManager>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.LocateUnitOfWork(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void LocatingNullUnitOfWorkThrowsException()
		{
			var uow = Isolate.Fake.Instance<UnitOfWorkManager>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.LocateUnitOfWork(null);
		}

		[TestMethod]
		public void LocatingUnitOfWorkByNameWorksOK()
		{
			//Arrange
			var strategy = Isolate.Fake.Instance<IUnitOfWorkDiscoveryStrategy>();
            Isolate.WhenCalled(() => strategy.LocateUnitOfWork(null)).WillReturn(new UnitOfWorkDiscoveryResults
                {
                    UnitOfWorkType = typeof(TestUOW)
                });

			//Act
			var mgr = UnitOfWorkManager.Create(new UnitOfWorkManagerOptions { DiscoveryStrategy = strategy });
			var output = mgr.LocateUnitOfWork("Test");

			//Assert
            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(TestUOW));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void ServingCachedMethodWorksOK()
		{
			//Arrange
			var uow = Isolate.Fake.Instance<IUnitOfWork>();
			var strategy = Isolate.Fake.Instance<IUnitOfWorkDiscoveryStrategy>();
			var caching = Isolate.Fake.Instance<IUnitOfWorkCaching>();
			Isolate.WhenCalled(() => caching.GetUnitOfWork("Test")).WithExactArguments().WillReturn(uow);

			//Act
			var mgr = UnitOfWorkManager.Create(new UnitOfWorkManagerOptions 
			{ 
				DiscoveryStrategy = strategy,
				Caching = caching
			});
			var output = mgr.LocateUnitOfWork("Test");

			//Assert
			Assert.AreEqual(output, uow);
			Isolate.Verify.WasNotCalled(() => { strategy.LocateUnitOfWork(null); });
			Isolate.CleanUp();
		}

		#endregion
	}
}
