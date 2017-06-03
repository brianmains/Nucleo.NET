using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Modules
{
	[TestClass]
	public class ModuleAttributeTest
	{
		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithEmptyTypeNameThrowsException()
		{
			new ModuleAttribute(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullTypeNameThrowsException()
		{
			new ModuleAttribute(null);
		}

		[TestMethod]
		public void CreatingWithTypeNameAssignsOK()
		{
			var attrib = new ModuleAttribute("MyModule");

			Assert.AreEqual("MyModule", attrib.TypeName);
		}
	}
}
