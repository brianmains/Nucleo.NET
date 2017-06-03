using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Extensions
{
	[TestClass]
	public class ObjectValidationExtensionsTest
	{
		#region " Test Classes "

		public class TestA { }

		public class TestB { }

		#endregion



		#region " Methods "

		[TestMethod]
		public void ValidatingPrimitiveInstanceTypesWorksOK()
		{
			//Arrange
			int i = 12;
			string t = "TXT";

			//Act
			var intResult = ObjectValidationExtensions.IsInstanceOf<string>(i);
			var stringResult = ObjectValidationExtensions.IsInstanceOf<string>(t);

			//Assert
			Assert.IsFalse(intResult);
			Assert.IsTrue(stringResult);
		}

		[TestMethod]
		public void ValidatingReferenceInstanceTypesWorksOK()
		{
			//Arrange
			var a = new TestA();
			var b = new TestB();

			//Act
			var intResult = ObjectValidationExtensions.IsInstanceOf<string>(a);
			var stringResult = ObjectValidationExtensions.IsInstanceOf<string>(a);
			var aResult = ObjectValidationExtensions.IsInstanceOf<TestA>(a);
			var notAResult = ObjectValidationExtensions.IsInstanceOf<TestA>(b);
			var bResult = ObjectValidationExtensions.IsInstanceOf<TestB>(b);

			//Assert
			Assert.IsFalse(intResult);
			Assert.IsFalse(stringResult);
			Assert.IsTrue(aResult);
			Assert.IsFalse(notAResult);
			Assert.IsTrue(bResult);
		}

		#endregion
	}
}
