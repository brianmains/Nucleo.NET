using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Web.Presentation.Context.Caching;


namespace Nucleo.Web.Presentation.Context.Cache
{
	[TestClass]
	public class HttpContextPresenterContextCacheTest
	{
		#region " Tests "
		
		[TestMethod]
		public void CanCacheWithHttpContextProvidedReturnsTrue()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<HttpContext>();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(ctx);

			//Act
			var cache = new HttpContextPresenterContextCache();

			//Assert
			Assert.IsTrue(cache.CanCache);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CanCacheWithoutHttpContextProvidedReturnsFalse()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(null);

			//Act
			var cache = new HttpContextPresenterContextCache();

			//Assert
			Assert.IsFalse(cache.CanCache);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPresenterContextFromHttpContextReturnsNotNullValue()
		{
			//Arrange
			var presenterCtx = Isolate.Fake.Instance<PresenterContext>();
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items[typeof(PresenterContext)]).WillReturn(presenterCtx);

			//Act
			var cache = new HttpContextPresenterContextCache();
			var output = cache.GetCurrentContext();

			//Assert
			Assert.AreEqual(presenterCtx, output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void UpdatingPresenterContextFromHttpContextAssignsOK()
		{
			//Arrange
			var presenterCtx = Isolate.Fake.Instance<PresenterContext>();
			bool output = false;
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => { HttpContext.Current.Items[typeof(PresenterContext)] = null; })
				.DoInstead((m) => { output = true; });

			//Act
			var cache = new HttpContextPresenterContextCache();
			cache.UpdateCurrentContext(presenterCtx);

			//Assert
			Assert.IsTrue(output);

			Isolate.CleanUp();
		}

		#endregion
	}
}
