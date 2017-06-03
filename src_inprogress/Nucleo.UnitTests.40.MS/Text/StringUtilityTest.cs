using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Text
{
	[TestClass]
	public class StringUtilityTest
	{
		[TestMethod]
		public void TestFormatValue()
		{
			Assert.AreEqual(string.Empty, StringUtility.FormatValue(" "));
			Assert.AreEqual("test", StringUtility.FormatValue("  test  "));
			Assert.AreEqual(string.Empty, StringUtility.FormatValue(null));

			Assert.AreEqual("test", StringUtility.FormatValue("  TeSt  ", StringUtility.TextCasing.Lower));
			Assert.AreEqual("TEST", StringUtility.FormatValue("  TeSt  ", StringUtility.TextCasing.Upper));
			Assert.AreEqual("TeSt", StringUtility.FormatValue("  TeSt  ", StringUtility.TextCasing.None));
		}

		[TestMethod]
		public void TestHasValue()
		{
			Assert.IsTrue(StringUtility.HasValue("f"));
			Assert.IsTrue(StringUtility.HasValue("x"));
			Assert.IsTrue(StringUtility.HasValue("1"));
			Assert.IsTrue(StringUtility.HasValue("p"));
			Assert.IsTrue(StringUtility.HasValue("9"));
			Assert.IsTrue(StringUtility.HasValue("$"));
			Assert.IsTrue(StringUtility.HasValue("  ", false));
			Assert.IsFalse(StringUtility.HasValue(""));
			Assert.IsFalse(StringUtility.HasValue(string.Empty));
			Assert.IsFalse(StringUtility.HasValue(null));
			Assert.IsFalse(StringUtility.HasValue("  ", true));
			Assert.IsFalse(StringUtility.HasValue("  "));
		}

		[TestMethod]
		public void TestThrowWhenNoValue()
		{
			try
			{
				StringUtility.ThrowOnNoValue("");
				Assert.Fail();
			}
			catch (ArgumentNullException ex) { }

			try
			{
				StringUtility.ThrowOnNoValue("   ");
				Assert.Fail();
			}
			catch (ArgumentNullException ex) { }

			try
			{
				StringUtility.ThrowOnNoValue(null);
				Assert.Fail();
			}
			catch (ArgumentNullException ex) { }

			try
			{
				StringUtility.ThrowOnNoValue("   ", true);
				Assert.Fail();
			}
			catch (ArgumentNullException ex) { }
		}
	}
}
