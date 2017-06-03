using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryUrlResolutionServiceTest
	{
		[TestMethod]
		public void GetClientBasedUrlReturnsCorrectValue()
		{
			var service = new InMemoryUrlResolutionService();

			var output = service.GetClientBasedUrl("~/test.aspx");

			Assert.AreEqual("test.aspx", output);
		}

		[TestMethod]
		public void GetWebServerUrlReturnsCorrectValue()
		{
			var service = new InMemoryUrlResolutionService();

			var output = service.GetWebServerUrl("~/test.aspx");

			Assert.AreEqual("test.aspx", output);
		}
	}
}
