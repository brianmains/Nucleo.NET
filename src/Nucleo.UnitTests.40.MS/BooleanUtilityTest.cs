using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo
{
	[TestClass]
	public class BooleanUtilityTest
	{
		#region " Tests "

		[TestMethod]
		public void ConvertingFToBooleanWorksCorrectly()
		{
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("f"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("F"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("f", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("F", true));
		}

		[TestMethod]
		public void ConvertingFalseToBooleanWorksCorrectly()
		{
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("False"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("false"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("FaLsE"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("fAlSe"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("False", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("false", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("FaLsE", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("fAlSe", true));
		}

		[TestMethod]
		public void ConvertingNToBooleanWorksCorrectly()
		{
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("n"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("N"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("n", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("N", true));
		}

		[TestMethod]
		public void ConvertingNoToBooleanWorksCorrectly()
		{
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("No"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("NO"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("nO"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("no"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("No", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("NO", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("nO", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("no", true));
		}

		[TestMethod]
		public void ConvertingOneToBooleanWorksCorrectly()
		{
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("1"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("1", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("-1"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("-1", false));
		}

		[TestMethod]
		public void ConvertingTToBooleanWorksCorrectly()
		{
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("T"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("t"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("T", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("t", false));
		}

		[TestMethod]
		public void ConvertingTrueToBooleanWorksCorrectly()
		{
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("True"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("TRUE"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("TruE"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("tRUe"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("tRue"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("True", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("TRUE", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("TruE", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("tRUe", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("tRue", false));
		}

		[TestMethod]
		public void ConvertingYToBooleanWorksCorrectly()
		{
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("Y"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("y"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("Y", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("y", false));
		}

		[TestMethod]
		public void ConvertingYesToBooleanWorksCorrectly()
		{
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("Yes"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("YeS"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("YES"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("yes"));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("Yes", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("YeS", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("YES", false));
			Assert.AreEqual(true, BooleanUtility.ConvertToBoolean("yes", false));
		}

		[TestMethod]
		public void ConvertingZeroToBooleanWorksCorrectly()
		{
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("0"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("0", true));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("-0"));
			Assert.AreEqual(false, BooleanUtility.ConvertToBoolean("-0", true));
		}

		[TestMethod]
		public void NullValuesToBooleanEvaluateNull()
		{
			Assert.AreEqual(null, BooleanUtility.ConvertToNullableBoolean(null));
			Assert.AreEqual(null, BooleanUtility.ConvertToNullableBoolean(string.Empty));
		}

		#endregion
	}
}
