using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Nucleo.Reflection
{
	[TestClass]
	public class DotNotationParserTest
	{

		#region " Classes "

		public class Child
		{
			private Subchild _child = new Subchild();

			public Subchild Child1
			{
				get { return _child; }
			}

			public Subchild Child2
			{
				get { return null; }
			}
		}

		public class Parent
		{
			private Child _child = new Child();

			public Child Child
			{
				get { return _child; }
			}
		}

		public class Subchild
		{
			public string Name { get { return "Name"; } }
			public string Text { get { return "Text"; } }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void TestParsingComplexObjects()
		{
			Parent parent = new Parent();
			Assert.AreEqual("Name", DotNotationParser.GetPropertyValue("Child.Child1.Name", parent));
			Assert.AreEqual("Text", DotNotationParser.GetPropertyValue("Child.Child1.Text", parent));
			Assert.IsNull(DotNotationParser.GetPropertyValue("Child.Child2.Text", parent));
			Assert.IsInstanceOfType(DotNotationParser.GetPropertyValue("Child.Child1", parent), typeof(Subchild));
		}

		#endregion
	}
}
