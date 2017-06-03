using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingValueChangesInternalValue()
		{
			TagAttribute attribute = new TagAttribute("width", "100px");
			attribute.Value = "200px";

			Assert.AreEqual("200px", attribute.Value);
		}

		[TestMethod]
		public void CreatingAttributeAssignsCorrectly()
		{
			TagAttribute attribute = new TagAttribute("width", "100px");
			Assert.AreEqual("width", attribute.Name);
			Assert.AreEqual("100px", attribute.Value);
		}

		#endregion
	}
}
