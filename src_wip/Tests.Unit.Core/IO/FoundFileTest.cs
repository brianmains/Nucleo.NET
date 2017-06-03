using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.IO
{
	[TestClass]
	public class FoundFileTest
	{
		[TestMethod]
		public void CreatingAssignsOK()
		{
			var directory = new FoundFile("test.txt", @"c:\test.txt");

			Assert.AreEqual("test.txt", directory.ShortName);
			Assert.AreEqual(@"c:\test.txt", directory.FullName);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyFullNameThrowsException()
		{
			new FoundFile("test", string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyShortNameThrowsException()
		{
			new FoundFile(string.Empty, @"c:\test");
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullFullNameThrowsException()
		{
			new FoundFile("test", null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullShortNameThrowsException()
		{
			new FoundFile(null, @"c:\test");
		}
	}
}
