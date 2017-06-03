using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryQuerystringServiceTest
	{
		[TestMethod]
		public void GettingAllKeysWorksAsExpected()
		{
			var service = new InMemoryQuerystringService();
			service.Add("A", "B");

			var output = service.GetAll();

			Assert.AreEqual(1, output.Count);
			Assert.AreEqual("B", output["A"]);
		}
	}
}
