using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Lookups.Identification
{
	[TestClass]
	public class NameLookupIdentifierTest
	{
		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			var id = new NameLookupIdentifier();

			id.Name = "X";

			Assert.AreEqual("X", id.Name);
		}
	}
}
