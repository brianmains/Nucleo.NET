using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Sitemaps
{
	[TestClass]
	public class SitemapItemCollectionTest
	{
		[TestMethod]
		public void AddingRangeOfItems()
		{
			var list = new SitemapItemCollection();

			list.AddRange(new[] { new SitemapItem(), new SitemapItem() });

			Assert.AreEqual(2, list.Count);
		}
	}
}
