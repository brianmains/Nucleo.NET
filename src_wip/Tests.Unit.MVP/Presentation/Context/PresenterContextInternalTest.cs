using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Presentation.Context.Caching;


namespace Nucleo.Presentation.Context
{
	[TestClass]
	public class PresenterContextInternalTest
	{
		[TestMethod]
		public void GettingContextFromCacheWorksOK()
		{
			var context = new PresenterContext();

			var cache = Isolate.Fake.Instance<IPresenterContextCache>();
			Isolate.WhenCalled(() => cache.CanCache).WillReturn(true);
			Isolate.WhenCalled(() => cache.GetCurrentContext()).WillReturn(context);

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.ContextCache).WillReturn(cache);

			var output = PresenterContextInternal.CreateContextOrGetFromCache();

			Assert.IsNotNull(output);
			Assert.AreEqual(context, output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingContextFromResolverWorksOK()
		{
			var context = new PresenterContext();

			var creator = Isolate.Fake.Instance<IPresenterContextCreator>();
			Isolate.WhenCalled(() => creator.Create()).WillReturn(context);

			var resolver = Isolate.Fake.Instance<IDependencyResolver>();
			Isolate.WhenCalled(() => resolver.GetDependency<IPresenterContextCreator>()).WillReturn(creator);

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.Resolver).WillReturn(resolver);

			var output = PresenterContextInternal.CreateContextOrGetFromCache();

			Assert.IsNotNull(output);
			Assert.AreEqual(context, output);

			Isolate.CleanUp();
		}
	}
}
