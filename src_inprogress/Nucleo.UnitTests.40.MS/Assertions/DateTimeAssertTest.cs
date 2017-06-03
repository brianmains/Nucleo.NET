using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using Nucleo.TestingTools;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DateTimeAssertTest
	{
		[Test]
		public void TestEqualityMatching()
		{
			DateTime testDate = new DateTime(2007, 5, 1);
			DateTimeAssert.AreEqual(testDate, new DateTime(2007, 5, 1, 13, 0, 0), false, "Didn't match");
			DateTimeAssert.AreNotEqual(testDate, new DateTime(2007, 5, 1, 13, 0, 0), true, "Aren't equal");
			DateTimeAssert.IsInRange(testDate, new DateTime(2007, 5, 1), new DateTime(2007, 5, 31), "Isn't within range");

			testDate = new DateTime(2007, 5, 31, 11, 59, 59);
			DateTimeAssert.IsInRange(testDate, new DateTime(2007, 5, 1), new DateTime(2007, 5, 31), "Isn't within range");

			testDate = new DateTime(2007, 5, 15);
			DateTimeAssert.IsInRange(testDate, new DateTime(2007, 5, 1), new DateTime(2007, 5, 31), "Isn't within range");
		}

		[Test]
		public void TestEqualityMatchingFailures()
		{
			DateTime testDate = new DateTime(2007, 5, 1);

			try
			{
				DateTimeAssert.AreEqual(testDate, new DateTime(2007, 5, 1, 13, 0, 0), true, "Aren't equal");
				Assert.Fail();
			}
			catch (AssertionException aex) { }
		}
	}
}