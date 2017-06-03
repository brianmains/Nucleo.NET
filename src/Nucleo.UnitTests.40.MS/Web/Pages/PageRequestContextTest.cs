using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context;
using Nucleo.Web.Core;
using Nucleo.Web.Searching;


namespace Nucleo.Web.Pages
{
	[TestClass]
	public class PageRequestContextTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var appContext = Isolate.Fake.Instance<IApplicationContext>();
			var webContext = Isolate.Fake.Instance<IWebContext>();
			var search = Isolate.Fake.Instance<IControlSearcher>();
			var singletons = Isolate.Fake.Instance<IWebSingletonManager>();


			//Act
			var ctx = new PageRequestContext();
			ctx.AppContext = appContext;
			ctx.Context = webContext;
			ctx.ControlSearcher = search;
			ctx.Singletons = singletons;

			//Assert
			Assert.AreEqual(appContext, ctx.AppContext);
			Assert.AreEqual(webContext, ctx.Context);
			Assert.AreEqual(search, ctx.ControlSearcher);
			Assert.AreEqual(singletons, ctx.Singletons);
		}

		#endregion
	}
}
