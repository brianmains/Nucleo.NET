using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Reflection
{
	[TestClass]
	public class TypeUtilityTest
	{
		[TestMethod]
		public void EmptyNumericTypeNameThrowsException()
		{

			//Assert
			ExceptionTester.CheckException(true, (src) => { TypeUtility.IsNumericType(default(string)); });
			ExceptionTester.CheckException(true, (src) => { TypeUtility.IsNumericType(string.Empty); });
		}

		[TestMethod]
		public void IsEnumeratedTypeReturnsTrue()
		{
			Assert.IsTrue(TypeUtility.IsEnumeratedType(typeof(CalendarPeriod)));
			Assert.IsTrue(TypeUtility.IsEnumeratedType(typeof(System.Web.UI.WebControls.DayNameFormat)));
			Assert.IsTrue(TypeUtility.IsEnumeratedType("Nucleo.CalendarPeriod"));
		}

		[TestMethod]
		public void TestIsNumericTypeReturnsCorrectValue()
		{
			Assert.IsTrue(TypeUtility.IsNumericType("short"));
			Assert.IsTrue(TypeUtility.IsNumericType("int"));
			Assert.IsTrue(TypeUtility.IsNumericType("long"));
			Assert.IsTrue(TypeUtility.IsNumericType("System.Int32"));
			Assert.IsTrue(TypeUtility.IsNumericType("System.Int64"));
			Assert.IsTrue(TypeUtility.IsNumericType("float"));
			Assert.IsTrue(TypeUtility.IsNumericType("double"));
			Assert.IsTrue(TypeUtility.IsNumericType("decimal"));
			Assert.IsFalse(TypeUtility.IsNumericType("System.String"));

			Assert.IsTrue(TypeUtility.IsNumericType(typeof(int)));
			Assert.IsTrue(TypeUtility.IsNumericType(typeof(double)));
			Assert.IsTrue(TypeUtility.IsNumericType(typeof(float)));
			Assert.IsTrue(TypeUtility.IsNumericType(typeof(Int32)));
			Assert.IsTrue(TypeUtility.IsNumericType(typeof(decimal)));
			Assert.IsFalse(TypeUtility.IsNumericType(typeof(string)));
		}

		[TestMethod]
		public void TestIsValueTypeReturnsCorrectValue()
		{
			Assert.IsTrue(TypeUtility.IsValueType(typeof(int)));
			Assert.IsTrue(TypeUtility.IsValueType(typeof(double)));
			Assert.IsFalse(TypeUtility.IsValueType(typeof(string)));

			Assert.IsTrue(TypeUtility.IsValueType("System.Int32"));
			Assert.IsFalse(TypeUtility.IsValueType("System.String"));
		}
	}
}
