using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.IO
{
	[TestClass]
	public class ExtensionTest
	{
		[TestMethod]
		public void CreatingAssignsOK()
		{
			var ext = new Extension("aspx");

			Assert.AreEqual("aspx", ext.Name);
		}

		[TestMethod]
		public void CreatingWithPeriodAssignsOK()
		{
			var ext = new Extension(".aspx");

			Assert.AreEqual("aspx", ext.Name);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyNameThrowsException()
		{
			new Extension(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullNameThrowsException()
		{
			new Extension(null);
		}
	}
}
