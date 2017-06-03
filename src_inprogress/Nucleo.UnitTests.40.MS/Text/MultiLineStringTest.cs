using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Text
{
	[TestClass]
	public class MultiLineStringTest
	{
		[TestMethod]
		public void TestLoadingData()
		{
			string testText = @"  This is some example text  

  to work with 
  as a simulation .  ";

			MultiLineString testString = new MultiLineString(testText, false);
			Assert.AreEqual(3, testString.LineCount);
			Assert.AreEqual("This is some example text", testString[0]);
			Assert.AreEqual("to work with", testString[1]);
			Assert.AreEqual("as a simulation .", testString[2]);


			testString = new MultiLineString(testText, true);
			Assert.AreEqual(4, testString.LineCount);
			Assert.AreEqual("This is some example text", testString[0]);
			Assert.AreEqual(string.Empty, testString[1]);
			Assert.AreEqual("to work with", testString[2]);
			Assert.AreEqual("as a simulation .", testString[3]);

			testString.AddLine("  another line  ");
			Assert.AreEqual(5, testString.LineCount);
			Assert.AreEqual("another line", testString[4]);

			testString.RemoveLine(1);
			Assert.AreEqual(4, testString.LineCount);
			Assert.AreEqual("to work with", testString[1]);
		}
	}
}