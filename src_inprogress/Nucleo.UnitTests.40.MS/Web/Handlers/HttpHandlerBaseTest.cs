using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Handlers
{
	[TestClass]
	public class HttpHandlerBaseTest
	{
		protected class TestHandler : HttpHandlerBase
		{
			public bool Assigned = false;

			public override void ProcessRequest(System.Web.HttpContextBase context)
			{
				Assigned = true;
			}
		}


		[TestMethod]
		public void IsReusableReturnsFalse()
		{
			var handler = new TestHandler();
			Assert.AreEqual(false, handler.IsReusable);
		}

		[TestMethod]
		public void ProcessingRequestAssignsOK()
		{
			var context = Isolate.Fake.Instance<HttpContext>();
			var handler = new TestHandler();
			handler.ProcessRequest(context);

			Assert.IsTrue(handler.Assigned);

			Isolate.CleanUp();
		}
	}
}
