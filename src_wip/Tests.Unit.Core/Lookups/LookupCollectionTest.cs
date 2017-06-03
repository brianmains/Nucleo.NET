using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupCollectionTest
	{
		[TestMethod]
		public void CreatingWithEmptyWorksOK()
		{
			var coll = new LookupCollection();

			Assert.AreEqual(0, coll.Count);
		}

		[TestMethod]
		public void CreatingWithItemsWorksOK()
		{
			var coll = new LookupCollection(new ILookup[]
				{
					new Lookup("Test", "T", "T"),
					new Lookup("Val", "V", "V")
				});

			Assert.AreEqual(2, coll.Count);
		}
	}
}
