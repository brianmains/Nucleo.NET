using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectEventListTest
	{
		#region " Test Classes "

		protected class TestClass
		{
			[Browsable(true)]
			public event EventHandler A;

			[Browsable(true)]
			public event EventHandler B;

			public event EventHandler C;

			[Browsable(true)]
			public event EventHandler D;

			public event EventHandler E;
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingEventsWithAttributeWorksOK()
		{
			//Arrange
			var obj = new TestClass();
			var list = new ReflectEventList(obj, false);

			//Act
			var events = list.WithAttribute(typeof(BrowsableAttribute));

			//Assert
			Assert.AreEqual(3, events.Count());
			Assert.AreEqual("A", events.First().Name);
			Assert.AreEqual("D", events.Last().Name);
		}

		#endregion
	}
}
