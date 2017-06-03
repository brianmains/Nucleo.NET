using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectTypeTest
	{
		#region " Test Classes "

		[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
		protected class TestingAttribute : Attribute 
		{
			public string Text { get; set; }

			public TestingAttribute(string text)
			{
				this.Text = text;
			}
		}

		[
		Testing("A"), 
		Testing("B"), 
		Testing("C")
		]
		protected class BaseCls
		{

		}

		[
		Testing("D"), 
		Testing("E"), 
		Testing("F")
		]
		protected class DerivedCls : BaseCls
		{

		}

		#endregion




		#region " Tests "

		[TestMethod]
		public void ActionsWorkOK()
		{
			//Arranges
			var member = new ReflectMethod("GetName", new object(), true);

			//Act

			//Assert
			member.Action((m) =>
			{
				Assert.IsNotNull(m);
				Assert.AreEqual(member, m);
			});
		}

		[TestMethod]
		public void IteratingAttributesThroughInheritanceChainWorksOK()
		{
			//Arrange
			var test = new DerivedCls();

			//Act
			var attribs = Reflect.Public(test).Type().IterateAttributesThoughTypeInheritance<TestingAttribute>().ToList();
			var items = attribs.Select(i => i.Text).OrderBy(i => i).ToList();

			//Assert
			Assert.AreEqual("A", items[0]);
			Assert.AreEqual("B", items[1]);
			Assert.AreEqual("C", items[2]);
			Assert.AreEqual("D", items[3]);
			Assert.AreEqual("E", items[4]);
			Assert.AreEqual("F", items[5]);
		}

		#endregion
	}
}

