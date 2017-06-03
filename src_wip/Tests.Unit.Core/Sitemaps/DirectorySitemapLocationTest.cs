using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Sitemaps
{
	[TestClass]
	public class DirectorySitemapLocationTest
	{
		[TestMethod]
		public void CreatingAssignsOK()
		{
			var location = new DirectorySitemapLocation(@"c:\test.aspx");

			Assert.AreEqual(@"c:\test.aspx", location.FullName);
		}
	}
}
