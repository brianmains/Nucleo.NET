using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo
{
	[TestClass]
	public class LazyValueTest
	{
		[TestMethod]
		public void AccessingValueCallsDelegate()
		{
			var value = new LazyValue<object>(() => { return new object(); });

			var output = value.Value;

			Assert.IsNotNull(output);
			Assert.IsTrue(value.IsValueCreated);
		}

		[TestMethod]
		public void NoCreatingReturnsFalse()
		{
			var value = new LazyValue<object>(() => { return new object(); });

			Assert.IsFalse(value.IsValueCreated);
		}

		[TestMethod]
		public void PassingValueInConstructorAssignsOK()
		{
			var value = new LazyValue<object>(new object());

			Assert.IsTrue(value.IsValueCreated);
			Assert.IsNotNull(value.Value);
		}
	}
}
