using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Models;
using Nucleo.Models.Cache;


namespace Nucleo.Web.Models.Cache
{
	[TestClass]
	public class WebRequestModelCacheTest
	{
		[TestMethod]
		public void CreatingThatPullsFromHttpContextAssignsOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContext>();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(ctx);

			new WebRequestModelCache();

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWithHttpRequestWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();

			new WebRequestModelCache(ctx);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingFromSharedCachePullsFromItemDictionary()
		{
			var model = Isolate.Fake.Instance<ICacheableModel>();
			var items = new Dictionary<object, object>();

			var httpContext = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => httpContext.Items).WillReturn(items);
			var dict = new Dictionary<string, object>();
			dict.Add("Global_$_FirstName", "Bob");

			httpContext.Items.Add(typeof(WebRequestModelCache), dict);

			var cache = new WebRequestModelCache(httpContext);
			var value = cache.GetValueFromCache(model, "FirstName", ShareAccessLevel.Global);

			Assert.AreEqual("Bob", value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingFromPerModelCachePullsFromItemDictionary()
		{
			var model = Isolate.Fake.Instance<ICacheableModel>();
			var items = new Dictionary<object, object>();

			var httpContext = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => httpContext.Items).WillReturn(items);
			var dict = new Dictionary<string, object>();
			dict.Add("PerModel_" + model.GetType().FullName + "_$_FirstName", "Bob");

			httpContext.Items.Add(typeof(WebRequestModelCache), dict);

			var cache = new WebRequestModelCache(httpContext);
			var value = cache.GetValueFromCache(model, "FirstName", ShareAccessLevel.PerModel);

			Assert.AreEqual("Bob", value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingFromGlobalCacheWithMissingKeyReturnsNull()
		{
			var model = Isolate.Fake.Instance<ICacheableModel>();
			var items = new Dictionary<object, object>();

			var httpContext = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => httpContext.Items).WillReturn(items);
			var dict = new Dictionary<string, object>();
			dict.Add("Global_$_FirstName", "Bob");

			httpContext.Items.Add(typeof(WebRequestModelCache), dict);


			var cache = new WebRequestModelCache(httpContext);
			var value = cache.GetValueFromCache(model, "Address", ShareAccessLevel.Global);

			Assert.IsNull(value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingFromPerModelCacheWithMissingKeyReturnsNull()
		{
			var model = Isolate.Fake.Instance<ICacheableModel>();
			var items = new Dictionary<object, object>();

			var httpContext = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => httpContext.Items).WillReturn(items);
			var dict = new Dictionary<string, object>();
			dict.Add("PerModel_" + model.GetType().FullName + "_$_FirstName", "Bob");

			httpContext.Items.Add(typeof(WebRequestModelCache), dict);


			var cache = new WebRequestModelCache(httpContext);
			var value = cache.GetValueFromCache(model, "Address", ShareAccessLevel.PerModel);

			Assert.IsNull(value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingFromGlobalCachePullsWithNoCachedValuesReturnsNull()
		{
			var model = Isolate.Fake.Instance<ICacheableModel>();
			var items = new Dictionary<object, object>();

			var httpContext = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => httpContext.Items).WillReturn(items);

			var cache = new WebRequestModelCache(httpContext);
			var value = cache.GetValueFromCache(model, "FirstName", ShareAccessLevel.Global);

			Assert.IsNull(value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingFromPerModelCachePullsWithNoCachedValuesReturnsNull()
		{
			var model = Isolate.Fake.Instance<ICacheableModel>();
			var items = new Dictionary<object, object>();

			var httpContext = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => httpContext.Items).WillReturn(items);

			var cache = new WebRequestModelCache(httpContext);
			var value = cache.GetValueFromCache(model, "FirstName", ShareAccessLevel.PerModel);

			Assert.IsNull(value);

			Isolate.CleanUp();
		}
	}
}
