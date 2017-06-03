using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class DataEventArgsTest
	{
		[TestMethod]
		public void TestUsingReferenceObject()
		{
			DataEventArgs<DataTable> args = new DataEventArgs<DataTable>(new DataTable());
			Assert.IsNotNull(args);
			Assert.IsNotNull(args.Data);
		}

		[TestMethod]
		public void TestUsingStructureObject()
		{
			DataEventArgs<string> args = new DataEventArgs<string>("Test");
			Assert.IsNotNull(args);
			Assert.AreEqual("Test", args.Data);
		}
	}
}
