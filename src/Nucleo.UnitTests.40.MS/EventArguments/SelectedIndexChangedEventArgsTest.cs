using System;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class SelectedIndexChangedEventArgsTest
	{
		[TestMethod]
		public void TestUsingObject()
		{
			SelectedIndexChangedEventArgs args = new SelectedIndexChangedEventArgs(0, new TableRow());
			Assert.IsNotNull(args);
			Assert.IsNotNull(args.Row);
			Assert.AreEqual(0, args.Index);
			Assert.IsNotNull(args.GetRowAs<TableRow>());

			args = new SelectedIndexChangedEventArgs(2, null);
			Assert.IsNotNull(args);
			Assert.IsNull(args.Row);
			Assert.AreEqual(2, args.Index);
		}
	}
}
