using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Core;


namespace Nucleo.Web.Views
{
	[TestClass]
	public class WebViewHostTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingNewWebViewHostWorksOK()
		{
			//Arrange
			var dict = new Dictionary<object, object>();
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.LocalStorage).WillReturn(dict);

			//Act
			var host = WebViewHost.CreateOrGet(ctx);

			//Assert
			Assert.IsTrue(dict.ContainsKey(typeof(WebViewHost)));
			Assert.AreEqual(host, dict[typeof(WebViewHost)]);
		}

		#endregion
	}
}
