using System;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryRequestHeaderServiceTest
	{
		[TestMethod]
		public void GettingAllKeysWorksAsExpected()
		{
			var service = new InMemoryRequestHeaderService();
			service.Add("A", "B");

			var output = service.GetAll();

			Assert.AreEqual(1, output.Count);
			Assert.AreEqual("B", output["A"]);
		}
	}
}
