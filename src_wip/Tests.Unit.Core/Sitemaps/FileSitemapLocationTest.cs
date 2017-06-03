using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Sitemaps
{
	[TestClass]
	public class FileSitemapLocationTest
	{
		[TestMethod]
		public void CreatingAssignsOK()
		{
			var location = new FileSitemapLocation(@"c:\test.aspx");

			Assert.AreEqual(@"c:\test.aspx", location.FullName);
		}
	}
}
