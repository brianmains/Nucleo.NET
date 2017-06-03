using System;
using System.Web;
using System.Linq;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Context.Services
{
	[TestClass]
	public class WebFormsCookieServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingCookiesAddsToUnderlyingCollection()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Response.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);
			
			//Act
			service.Add("Test", 1);

			//Assert
			Assert.AreEqual("1", cookies["Test"].Value);
		}

		[TestMethod]
		public void ContainsCookiesReturnsCorrectValues()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			cookies.Add(new HttpCookie("Test", "Value"));
			cookies.Add(new HttpCookie("First", "1"));
			cookies.Add(new HttpCookie("Second", "2"));

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);

			//Act
			var value1 = service.Contains("First");
			var value2 = service.Contains("Second");
			var value3 = service.Contains("Third");

			//Assert
			Assert.IsTrue(value1);
			Assert.IsTrue(value2);
			Assert.IsFalse(value3);
		}

		[TestMethod]
		public void GettingCookiesByCookieReferenceReturnsCorrectValues()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			cookies.Add(new HttpCookie("Test", "Value"));
			cookies.Add(new HttpCookie("First", "1"));
			cookies.Add(new HttpCookie("Second", "2"));

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);

			//Act
			var value1 = service.GetCookie("First");
			var value2 = service.GetCookie("Test");

			//Assert
			Assert.AreEqual("1", value1.Value);
			Assert.AreEqual("Value", value2.Value);
		}

		[TestMethod]
		public void GettingCookiesByKeyAndIndexReturnsCorrectValues()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			cookies.Add(new HttpCookie("Test", "Value"));
			cookies.Add(new HttpCookie("First", "1"));
			cookies.Add(new HttpCookie("Second", "2"));

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);

			//Act
			var value1 = service.Get("First");
			var value2 = service.Get(0);

			//Assert
			Assert.AreEqual("1", value1);
			Assert.AreEqual("Value", value2);
		}

		[TestMethod]
		public void GettingCookiesWithMissingValuesReturnsNull()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			cookies.Add(new HttpCookie("Test", "Value"));
			cookies.Add(new HttpCookie("First", "1"));
			cookies.Add(new HttpCookie("Second", "2"));

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);

			//Act
			var value1 = service.Get("Fifty");
			var value2 = service.Get("Three");

			//Assert
			Assert.IsTrue(value1 == null || value1 == "");
			Assert.IsTrue(value2 == null || value2 == "");
		}

		[TestMethod]
		public void RemovingCookiesByKeyReturnsCorrectValues()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			cookies.Add(new HttpCookie("Test", "Value"));
			cookies.Add(new HttpCookie("First", "1"));
			cookies.Add(new HttpCookie("Second", "2"));

			var cookiesResponse = new HttpCookieCollection();
			cookiesResponse.Add(new HttpCookie("Test", "Value"));
			cookiesResponse.Add(new HttpCookie("First", "1"));
			cookiesResponse.Add(new HttpCookie("Second", "2"));

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Cookies).WillReturn(cookies);
			Isolate.WhenCalled(() => ctx.Response.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);

			//Act
			service.Remove("First");
			service.Remove("Third");

			//Assert
			Assert.AreEqual(2, service.Count);
		}

		[TestMethod]
		public void RemovingCookiesByIndexReturnsCorrectValues()
		{
			//Arrange
			var cookies = new HttpCookieCollection();
			cookies.Add(new HttpCookie("Test", "Value"));
			cookies.Add(new HttpCookie("First", "1"));
			cookies.Add(new HttpCookie("Second", "2"));

			var cookiesResponse = new HttpCookieCollection();
			cookiesResponse.Add(new HttpCookie("Test", "Value"));
			cookiesResponse.Add(new HttpCookie("First", "1"));
			cookiesResponse.Add(new HttpCookie("Second", "2"));

			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Request.Cookies).WillReturn(cookies);
			Isolate.WhenCalled(() => ctx.Response.Cookies).WillReturn(cookies);

			var service = new WebFormsCookieService(ctx);

			//Act
			service.RemoveAt(2);
			service.RemoveAt(1);

			//Assert
			Assert.AreEqual(1, service.Count);
		}

		#endregion
	}
}
