using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class ObjectPropertyChangedEventArgsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEventArgsAssignsValuesCorrectly()
		{
			var obj = new EventArgs();

			var e = new ObjectPropertyChangedEventArgs(obj, "Test", 1, 2);
			Assert.AreEqual(obj, e.Instance);
			Assert.AreEqual("Test", e.PropertyName);
			Assert.AreEqual(1, e.OldValue);
			Assert.AreEqual(2, e.NewValue);
		}

		#endregion
	}
}
