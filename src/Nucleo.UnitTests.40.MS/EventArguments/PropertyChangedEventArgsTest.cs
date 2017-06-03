using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class PropertyChangedEventArgsTest
	{
		[TestMethod]
		public void TestCreatingObject()
		{
			PropertyChangedEventArgs args = new PropertyChangedEventArgs("Visible", false, true);
			Assert.AreEqual("Visible", args.PropertyName);
			Assert.AreEqual(false, args.OldValue);
			Assert.AreEqual(true, args.NewValue);

			args = new PropertyChangedEventArgs(null, null, null);
			Assert.IsNull(args.PropertyName);
			Assert.IsNull(args.OldValue);
			Assert.IsNull(args.NewValue);
		}
	}
}
