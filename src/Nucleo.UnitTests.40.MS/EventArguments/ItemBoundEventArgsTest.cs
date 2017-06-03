using System;
using System.Text;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class ItemBoundEventArgsTest
	{
		[TestMethod]
		public void CreatingArgsAssignsOK()
		{
			var pnl = new UpdatePanel();

			var args = new ItemBoundEventArgs(pnl, ViewBindingDirection.ToUserInterface);

			Assert.AreEqual(pnl, args.Control);
			Assert.AreEqual(ViewBindingDirection.ToUserInterface, args.Direction);
		}

		[TestMethod]
		public void GettingAndSettingPropsAssignsOK()
		{
			var args = Isolate.Fake.Instance<ItemBoundEventArgs>();

			args.PropertyName = "X";
			args.Value = 12;

			Assert.AreEqual("X", args.PropertyName);
			Assert.AreEqual(12, args.Value);

			Isolate.CleanUp();
		}
	}
}
