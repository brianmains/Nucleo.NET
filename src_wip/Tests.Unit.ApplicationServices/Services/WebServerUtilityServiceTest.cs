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
	public class WebServerUtilityServiceTest
	{
		[TestMethod]
		public void CreatingFromHttpContextCurrentWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContext>();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current).WillReturn(ctx);

			new WebServerUtilityService();

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingFromHttpContextCtorParameterWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			new WebServerUtilityService(ctx);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingMachineNameWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Server.MachineName).WillReturn("ABC");

			var service = new WebServerUtilityService(ctx);

			Assert.AreEqual("ABC", service.MachineName);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingScriptTimeoutWorksOK()
		{
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Server.ScriptTimeout).WillReturn(123);

			var service = new WebServerUtilityService(ctx);

			Assert.AreEqual(123, service.ScriptTimeout);

			Isolate.CleanUp();
		}




		[TestMethod]
		public void SettingScriptTimeoutWorksOK()
		{
			bool check = false;
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => { ctx.Server.ScriptTimeout = 123; }).DoInstead((m) => { check = true; });

			var service = new WebServerUtilityService(ctx);
			service.ScriptTimeout = 123;

			Assert.IsTrue(check);

			Isolate.CleanUp();
		}
	}
}
