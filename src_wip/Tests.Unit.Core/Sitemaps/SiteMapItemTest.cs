using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

namespace Nucleo.Sitemaps
{
	[TestClass]
	public class SiteMapItemTest
	{
		[TestMethod]
		public void AddingItemsAddsOK()
		{
			var item = Isolate.Fake.Instance<SitemapItem>();
			var parent = new SitemapItem();

			parent.Items.Add(item);

			Assert.AreEqual(1, parent.Items.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingLocationAssignsOK()
		{
			var map = new SitemapItem();
			var location = Isolate.Fake.Instance<ISitemapLocation>();

			map.Location = location;

			Assert.AreEqual(location, map.Location);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingNameAssignsOK()
		{
			var map = new SitemapItem();

			map.Name = "X";

			Assert.AreEqual("X", map.Name);
		}
	}
}
