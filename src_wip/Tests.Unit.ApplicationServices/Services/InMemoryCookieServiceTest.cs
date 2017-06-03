using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryCookieServiceTest
	{
		[TestMethod]
		public void AddingItemsUsingCookieAndDomainAndSecureAddOK()
		{
			var service = new InMemoryCookieService();

			service.Add("A", "B", DateTime.Now, true, "abc.com");

			Assert.AreEqual(1, service.Count);
		}

		[TestMethod]
		public void AddingItemsUsingCookieAndSecureAddOK()
		{
			var service = new InMemoryCookieService();

			service.Add("A", "B", DateTime.Now, true);

			Assert.AreEqual(1, service.Count);
		}

		[TestMethod]
		public void GettingCookieReturnsEmptyCookie()
		{
			var service = new InMemoryCookieService();
			service.Add("A", "B");

			Assert.IsNotNull(service.GetCookie("B"));
		}

		[TestMethod]
		public void GettingCookieWorksOK()
		{
			var service = new InMemoryCookieService();
			service.Add("A", "B");

			Assert.IsNotNull(service.GetCookie("A"));
		}
	}
}
