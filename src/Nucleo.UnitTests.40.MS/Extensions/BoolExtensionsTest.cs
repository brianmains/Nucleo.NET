using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class BoolExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void ConvertingBooleanToYesNoWorksOK()
		{
			//Arrange

			//Act
			string trueValue = true.ToYesNo();
			string falseValue = false.ToYesNo();

			//Assert
			Assert.AreEqual("Yes", trueValue, "True value isn't Yes");
			Assert.AreEqual("No", falseValue, "False value isn't No");
		}

		[TestMethod]
		public void ConvertingBooleanToYesNoNullWithDefaultWorksOK()
		{
			//Arrange

			//Act
			string trueValue = ((bool?)true).ToYesNo("Test");
			string falseValue = ((bool?)false).ToYesNo("Test");
			string nullValue = ((bool?)null).ToYesNo("Test");

			//Assert
			Assert.AreEqual("Yes", trueValue, "True value isn't Yes");
			Assert.AreEqual("No", falseValue, "False value isn't No");
			Assert.AreEqual("Test", nullValue, "Null value isn't unknown");
		}

		[TestMethod]
		public void ConvertingBooleanToYesNoNullWorksOK()
		{
			//Arrange

			//Act
			string trueValue = ((bool?)true).ToYesNo();
			string falseValue = ((bool?)false).ToYesNo();
			string nullValue = ((bool?)null).ToYesNo();

			//Assert
			Assert.AreEqual("Yes", trueValue, "True value isn't Yes");
			Assert.AreEqual("No", falseValue, "False value isn't No");
			Assert.AreEqual("Unknown", nullValue, "Null value isn't unknown");
		}

		#endregion
	}
}
