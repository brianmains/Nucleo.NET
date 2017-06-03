using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class WebPostDataServiceTest
	{
		[TestMethod]
		public void CreatingFromHttpContextCurrentWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContext>();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(ctx);

			new WebPostDataService();

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingFromHttpContextCtorParameterWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			new WebPostDataService(ctx);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAllReturnsRequestCollection()
		{
			var values = new NameValueCollection();
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Form).WillReturn(values);

			var service = new WebPostDataService(ctx);
			var output = service.GetAll();

			Assert.AreEqual(values, output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByKeyReturnsValue()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Form.Get("ABC")).WillReturn("123");

			var service = new WebPostDataService(ctx);
			var output = service.Get("ABC");

			Assert.AreEqual("123", output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByIndexReturnsValue()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Form.Get(0)).WillReturn("123");

			var service = new WebPostDataService(ctx);
			var output = service.Get(0);

			Assert.AreEqual("123", output);

			Isolate.CleanUp();
		}
	}
}
