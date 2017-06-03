using System;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryPostDataServiceTest
	{
		[TestMethod]
		public void GettingAllPostDataWorksOK()
		{
			var service = new InMemoryPostDataService(new NameValueCollection
			{
				{ "A", "B" }
			});

			var output = service.GetAll();

			Assert.AreEqual(1, output.Count);
			Assert.AreEqual("B", output["A"]);
		}

		[TestMethod]
		public void GettingPostDataByKeyWorksOK()
		{
			var service = new InMemoryPostDataService(new NameValueCollection
			{
				{ "A", "B" }
			});

			Assert.IsNotNull(service.Get("A"));
		}

		[TestMethod]
		public void GettingPostDataByIndexWorksOK()
		{
			var service = new InMemoryPostDataService(new NameValueCollection
			{
				{ "A", "B" }
			});

			Assert.IsNotNull(service.Get(0));
		}
	}
}
