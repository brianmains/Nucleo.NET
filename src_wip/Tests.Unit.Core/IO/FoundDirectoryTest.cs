using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.IO
{
	[TestClass]
	public class FoundDirectoryTest
	{
		[TestMethod]
		public void CreatingAssignsOK()
		{
			var directory = new FoundDirectory("test", @"c:\test");

			Assert.AreEqual("test", directory.ShortName);
			Assert.AreEqual(@"c:\test", directory.FullName);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyFullNameThrowsException()
		{
			new FoundDirectory("test", string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyShortNameThrowsException()
		{
			new FoundDirectory(string.Empty, @"c:\test");
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullFullNameThrowsException()
		{
			new FoundDirectory("test", null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullShortNameThrowsException()
		{
			new FoundDirectory(null, @"c:\test");
		}
	}
}
