using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventArguments
{
	[TestClass]
	public class StateValueChangedEventArgsTest
	{
		[TestMethod]
		public void CreatingArgsWorksOK()
		{
			var args = new StateValueChangedEventArgs("A", 1, 2);

			Assert.AreEqual("A", args.Key);
			Assert.AreEqual(1, args.OldValue);
			Assert.AreEqual(2, args.NewValue);
		}
	}
}
