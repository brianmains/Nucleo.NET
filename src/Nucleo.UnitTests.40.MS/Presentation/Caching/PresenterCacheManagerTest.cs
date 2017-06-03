using Nucleo.Presentation;
using Nucleo.Presentation;
using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Core;
using Nucleo.Core.Configuration;


namespace Nucleo.Presentation
{
	[TestClass]
	public class PresenterCacheManagerTest
	{
		#region " Test Classes "

		protected class TestCache : IPresenterContextCache
		{

			#region IPresenterContextCache Members

			public bool CanCache
			{
				get { throw new NotImplementedException(); }
			}

			public PresenterContext GetCurrentContext()
			{
				throw new NotImplementedException();
			}

			public bool UpdateCurrentContext(PresenterContext context)
			{
				throw new NotImplementedException();
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingCacheManagerWithNoConfigReturnsInstance()
		{
			//Arrange
			
			//Act
			var cache = PresenterCacheManager.Create();

			//Assert
			Assert.IsFalse(cache.CanCache);
		}

		[TestMethod]
		public void CreatingCacheManagerWithOptionsReturnsPopulatedInstance()
		{
			//Arrange
			var cacheInstance = Isolate.Fake.Instance<IPresenterContextCache>();
			Isolate.WhenCalled(() => cacheInstance.CanCache).WillReturn(true);

			//Act
			var cache = PresenterCacheManager.Create(new PresenterCacheOptions { ContextCache = cacheInstance });

			//Assert
			Assert.IsTrue(cache.CanCache);
		}

		[TestMethod]
		public void CreatingCacheManagerWithoutOptionsReturnsPopulatedInstance()
		{
			//Arrange
			var section = new FrameworkSettingsSection { PresenterCacheTypeName = typeof(TestCache).AssemblyQualifiedName };
			Isolate.Fake.StaticMethods(typeof(FrameworkSettingsSection));
			Isolate.WhenCalled(() => FrameworkSettingsSection.Instance).WillReturn(section);

			var cacheInstance = Isolate.Fake.Instance<IPresenterContextCache>();
			Isolate.WhenCalled(() => cacheInstance.CanCache).WillReturn(true);

			//Act
			var cache = PresenterCacheManager.Create(new PresenterCacheOptions { ContextCache = cacheInstance });

			//Assert
			Assert.IsTrue(cache.CanCache);
		}

		[TestMethod]
		public void GettingCurrentContextWorksOK()
		{
			//Arrange
			var ctx = new PresenterContext();
			var cacheInstance = Isolate.Fake.Instance<IPresenterContextCache>();
			Isolate.WhenCalled(() => cacheInstance.CanCache).WillReturn(true);
			Isolate.WhenCalled(() => cacheInstance.GetCurrentContext()).WillReturn(ctx);

			//Act
			var cache = PresenterCacheManager.Create(new PresenterCacheOptions { ContextCache = cacheInstance });
			var output = cache.GetCurrentContext();

			//Assert
			Assert.AreEqual(ctx, output);
		}

		[TestMethod]
		public void HasContextCacheEnabledReturnsTrue()
		{
			//Arrange
			var cache = Isolate.Fake.Instance<IPresenterContextCache>();

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.ContextCache).WillReturn(cache);

			//Act
			var output = PresenterCacheManager.HasContextCachingEnabled();

			//Assert
			Assert.IsTrue(output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void HasContextCacheEnabledWhenConfigDoesntExistReturnsFalse()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(FrameworkSettingsSection));
			Isolate.WhenCalled(() => FrameworkSettingsSection.Instance).WillReturn(null);

			//Act
			var cache = PresenterCacheManager.HasContextCachingEnabled();

			//Assert
			Assert.IsFalse(cache);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void HasContextCacheEnabledWhenConfigExistsReturnsFalse()
		{
			//Arrange
			var section = new FrameworkSettingsSection { PresenterCacheTypeName = null };
			Isolate.Fake.StaticMethods(typeof(FrameworkSettingsSection));
			Isolate.WhenCalled(() => FrameworkSettingsSection.Instance).WillReturn(section);

			//Act
			var cache = PresenterCacheManager.HasContextCachingEnabled();

			//Assert
			Assert.IsFalse(cache);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void UpdatingCurrentContextWorksOK()
		{
			//Arrange
			var ctx = new PresenterContext();
			var cacheInstance = Isolate.Fake.Instance<IPresenterContextCache>();
			Isolate.WhenCalled(() => cacheInstance.CanCache).WillReturn(true);

			//Act
			var cache = PresenterCacheManager.Create(new PresenterCacheOptions { ContextCache = cacheInstance });
			var output = cache.UpdateCurrentContext(ctx);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => cacheInstance.UpdateCurrentContext(null));
		}

		#endregion
	}
}
