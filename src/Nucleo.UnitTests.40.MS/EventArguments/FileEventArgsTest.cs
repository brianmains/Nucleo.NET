using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class FileEventArgsTest
	{
		[TestMethod]
		public void TestUsingObject()
		{
			string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
			FileEventArgs args = new FileEventArgs(files[0]);
			Assert.IsNotNull(args);
			Assert.AreEqual(files[0], args.FileName);

			FileStream stream = args.Stream;
			Assert.IsNotNull(stream);
			stream.Dispose();
		}
	}
}
