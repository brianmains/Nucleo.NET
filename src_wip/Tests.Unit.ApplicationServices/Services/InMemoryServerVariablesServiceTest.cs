using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryServerVariablesServiceTest
	{
		[TestMethod]
		public void GettingAllKeysWorksAsExpected()
		{
			var service = new InMemoryServerVariablesService();
			service.Add("A", "B");

			var output = service.GetAll();

			Assert.AreEqual(1, output.Count);
			Assert.AreEqual("B", output["A"]);
		}
	}
}
