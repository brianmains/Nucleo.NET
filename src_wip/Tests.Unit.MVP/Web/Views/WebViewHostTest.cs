using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Services;


namespace Nucleo.Web.Views
{
	[TestClass]
	public class WebViewHostTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingNewWebViewHostWorksOK()
		{
			var ctx = Isolate.Fake.Instance<IStaticInstanceManager>();
			var resolver = new DictionaryBasedDependencyResolver(new Dictionary<Type, object>
			{
				{ typeof(IStaticInstanceManager), ctx }
			});

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.Resolver).WillReturn(resolver);

			//Act
			var host = WebViewHost.CreateOrGet();

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.AddEntry<WebViewHost>(null));

			Isolate.CleanUp();
		}

		#endregion
	}
}
