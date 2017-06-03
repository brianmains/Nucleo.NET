using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class WebUrlResolutionServiceTest
	{
		



		[TestMethod]
		public void CreatingFromHttpContextCtorParameterWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			new WebUrlResolutionService(ctx);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingFromHttpContextCurrentWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContext>();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(ctx);

			new WebUrlResolutionService();

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingClientUrlWorksAsExpected()
		{
			var page = Isolate.Fake.Instance<Page>();
			Isolate.WhenCalled(() => page.ResolveClientUrl("test.aspx")).WillReturn("test.aspx");

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Handler).WillReturn(page);

			var service = new WebUrlResolutionService(ctx);

			var output = service.GetClientBasedUrl("~/test.aspx");

			Assert.AreEqual("test.aspx", output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingServerBasedUrlWorksAsExpected()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Server.MapPath(null)).WillReturn("test.aspx");

			var service = new WebUrlResolutionService(ctx);
			var output = service.GetWebServerUrl("c:\test.aspx");

			Assert.AreEqual("test.aspx", output);

			Isolate.CleanUp();
		}
	}
}
