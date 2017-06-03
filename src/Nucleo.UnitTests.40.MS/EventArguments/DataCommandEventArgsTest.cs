using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class DataCommandEventArgsTest
	{
		[TestMethod]
		public void TestCreatingObject()
		{
			DataCommandEventArgs<DateTime> args = new DataCommandEventArgs<DateTime>("cmd", DateTime.MaxValue);
			Assert.AreEqual("cmd", args.Command);
			Assert.AreEqual(DateTime.MaxValue, args.Data);
		}
	}
}
