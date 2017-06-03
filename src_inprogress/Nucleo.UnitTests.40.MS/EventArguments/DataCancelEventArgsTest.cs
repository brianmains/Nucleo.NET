using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class DataCancelEventArgsTest
	{
		
		[TestMethod]
		public void TestCreatingObjects()
		{
			DataCancelEventArgs<string> args = new DataCancelEventArgs<string>(null);
			Assert.IsNull(args.Data);

			args = new DataCancelEventArgs<string>("");
			Assert.AreEqual("", args.Data);
			Assert.AreEqual(false, args.Cancel);

			args = new DataCancelEventArgs<string>("This is my test", true);
			Assert.AreEqual("This is my test", args.Data);
			Assert.AreEqual(true, args.Cancel);
		}
	}
}
