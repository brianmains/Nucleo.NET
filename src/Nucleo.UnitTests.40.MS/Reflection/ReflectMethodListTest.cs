using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectMethodListTest
	{
		#region " Test Class "

		protected class TestClass
		{
			[Browsable(true)]
			public void A() { }

			[Browsable(true)]
			public void B() { }

			public void C() { }

			public void D() { }

			[Browsable(true)]
			public void E() { }

			[Browsable(true)]
			public void F() { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingMethodsWithAttributesWOrksOK()
		{
			//Arrange
			var obj = new TestClass();
			var list = new ReflectMethodList(obj, false);

			//Act
			var methods = list.WithAttribute(typeof(BrowsableAttribute));

			//Assert
			Assert.AreEqual(4, methods.Count());
			Assert.AreEqual("A", methods.First().Name);
			Assert.AreEqual("F", methods.Last().Name);
		}

		#endregion
	}
}
