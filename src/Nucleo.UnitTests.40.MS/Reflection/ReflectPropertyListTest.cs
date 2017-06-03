using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectPropertyListTest
	{
		#region " Test Class "

		protected class TestClass
		{
			public int A { get; set; }

			[Browsable(true)]
			public string B { get; set; }

			[Browsable(true)]
			public DateTime C { get; set; }

			public long D { get; set; }

			[Browsable(true)]
			public object E { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingAllValuesWorksOK()
		{
			//Arrange
			var obj = new TestClass
			{
				A = 123,
				B = "B123",
				C = new DateTime(2000, 1, 23),
				D = 1234,
				E = 12345
			};
			var list = new ReflectPropertyList(obj, false);

			//Act
			var propValues = list.GetAllValues();

			//Assert
			Assert.AreEqual("A", propValues[0].Name);
			Assert.AreEqual(123, propValues[0].Value);
			Assert.AreEqual("B123", propValues[1].Value);
			Assert.AreEqual(new DateTime(2000, 1, 23).ToShortDateString(), ((DateTime)propValues[2].Value).ToShortDateString(), false, "Doesn't match");
			Assert.AreEqual(1234L, propValues[3].Value);
			Assert.AreEqual(12345, propValues[4].Value);
		}

		[TestMethod]
		public void GettingPropertiesWithAttributeWorksOK()
		{
			//Arrange
			var obj = new TestClass();
			var list = new ReflectPropertyList(obj, false);

			//Act
			var props = list.WithAttribute(typeof(BrowsableAttribute));

			//Assert
			Assert.AreEqual(3, props.Count());
			Assert.AreEqual("B", props.First().Name);
			Assert.AreEqual("E", props.Last().Name);
		}

		#endregion
	}
}
