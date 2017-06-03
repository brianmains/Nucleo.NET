using System;
using System.Text;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class ItemBindingEventArgsTest
	{
		[TestMethod]
		public void CreatingArgsAssignsOK()
		{
			var pnl = new UpdatePanel();

			var args = new ItemBindingEventArgs(pnl, ViewBindingDirection.ToUserInterface);

			Assert.AreEqual(pnl, args.Control);
			Assert.AreEqual(ViewBindingDirection.ToUserInterface, args.Direction);
		}

		[TestMethod]
		public void GettingAndSettingPropsAssignsOK()
		{
			var args = Isolate.Fake.Instance<ItemBindingEventArgs>();

			args.Cancel = true;
			args.PropertyName = "X";
			args.Value = 12;

			Assert.AreEqual(true, args.Cancel);
			Assert.AreEqual("X", args.PropertyName);
			Assert.AreEqual(12, args.Value);

			Isolate.CleanUp();
		}
	}
}
