using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class WebCurrentRequestServiceTest
	{
		[TestMethod]
		public void GettingRawUrlWorksOK()
		{
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Request.RawUrl).WillReturn("test.aspx");

			var service = new WebCurrentRequestService();

			Assert.AreEqual("test.aspx", service.RawUrl);
			Isolate.CleanUp();
		}
	}
}
