using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventArguments
{
	[TestClass]
	public class ViewBindingEventArgsTest
	{
		[TestMethod]
		public void CreatingArgsAssignsOK()
		{
			var args = new ViewBindingEventArgs(ViewBindingDirection.ToUserInterface);

			Assert.AreEqual(ViewBindingDirection.ToUserInterface, args.Direction);
		}
	}
}
