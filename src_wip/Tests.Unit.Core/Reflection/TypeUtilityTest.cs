using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace Nucleo.Reflection
{
	[TestClass]
	public class TypeUtilityTest
	{
		public enum TestEnumType { T1, T2 }


		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyEnumeratedTypeNameThrowsException()
		{
			TypeUtility.IsEnumeratedType(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void EmptyNumericTypeNameThrowsException()
		{
			TypeUtility.IsNumericType(string.Empty);
		}

		[TestMethod]
		public void IsEnumeratedTypeByNameReturnsTrue()
		{
			Assert.IsTrue(TypeUtility.IsEnumeratedType(typeof(TestEnumType).AssemblyQualifiedName));
		}

		[TestMethod]
		public void IsEnumeratedTypeByTypeReturnsTrue()
		{
			Assert.IsTrue(TypeUtility.IsEnumeratedType(typeof(TestEnumType)));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullEnumeratedTypeNameThrowsException()
		{
			TypeUtility.IsEnumeratedType(default(string));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullEnumeratedTypeThrowsException()
		{
			TypeUtility.IsEnumeratedType(default(Type));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullNumericTypeNameThrowsException()
		{

			//Assert
			TypeUtility.IsNumericType(default(string));
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
