using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Exceptions;


namespace Nucleo.TestingTools
{
	[TestClass]
	public class ExceptionTesterTest
	{
		#region " Tests "

		[
		TestMethod,
		ExpectedException(typeof(AssertionFailedException))
		]
		public void TestThatExceptionThrownReturnsFailure()
		{
			ExceptionTester.CheckException(false, (src) => { throw new ArgumentException(); });
		}

		[TestMethod]
		public void TestThatExceptionThrownReturnsSuccess()
		{
			var result = ExceptionTester.CheckException(true, (src) => { throw new ArgumentException(); });
			Assert.IsTrue(result);
		}

		[
		TestMethod,
		ExpectedException(typeof(AssertionFailedException))
		]
		public void TestThatValidResponseThatShouldThrowExceptionDoesThrowsException()
		{
			var result = ExceptionTester.CheckException(true, (src) => { var x = 1; });
		}

		[TestMethod]
		public void TestThatValidResponseReturnsSuccess()
		{
			var result = ExceptionTester.CheckException(false, (src) => { var x = 1; });
			Assert.IsTrue(result);
		}

		#endregion
	}
}
