using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;
using Microsoft.Practices.EnterpriseLibrary.Caching;

using Nucleo.TestingTools;

namespace Nucleo.Presentation
{
	[TestClass]
	public class EntLibCachingPresenterContextCacheTest
	{
		[TestMethod]
		public void CreatingWithNullCacheManagerThrowsException()
		{
			//Assert
			ExceptionTester.CheckException(true, (s) => { new EntLibCachingPresenterContextCache(null); });
		}

		[TestMethod]
		public void GettingCurrentContextReturnsCorrectValue()
		{
			//Arrange
			var ctx = new PresenterContext();
			var cache = Isolate.Fake.Instance<ICacheManager>();
			Isolate.WhenCalled(() => cache.GetData(EntLibCachingPresenterContextCache.CacheKey)).WillReturn(ctx);

			//Act
			var context = new EntLibCachingPresenterContextCache(cache);
			var output = context.GetCurrentContext();

			//Assert
			Assert.AreEqual(ctx, output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingDefaultCacheManagerOnConstructionWorksOK()
		{
			//Arrange
			var cache = Isolate.Fake.Instance<ICacheManager>();
			var factory = Isolate.Fake.Instance<CacheManagerFactory>();
			Isolate.Swap.NextInstance<CacheManagerFactory>().With(factory);
			Isolate.WhenCalled(() => factory.CreateDefault()).WillReturn(cache);

			//Act
			var output = new EntLibCachingPresenterContextCache();

			//Assert
			Assert.IsTrue(output.CanCache);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void UpdatingCurrentContextSetsNewContext()
		{
			//Arrange
			var ctx = new PresenterContext();
			var cache = Isolate.Fake.Instance<ICacheManager>();
			Isolate.WhenCalled(() => cache.Add(EntLibCachingPresenterContextCache.CacheKey, ctx)).IgnoreCall();

			//Act
			var context = new EntLibCachingPresenterContextCache(cache);
			var output = context.UpdateCurrentContext(ctx);

			//Assert
			Isolate.Verify.WasCalledWithExactArguments(() => cache.Add(EntLibCachingPresenterContextCache.CacheKey, ctx));

			Isolate.CleanUp();
		}
	}
}
