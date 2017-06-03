using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Logs.Configuration
{
	[TestClass]
	public class LogVerbosityTypeElementTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningValuesToElementConfigurationAssignsCorrectly()
		{
			var element = new LogVerbosityTypeElement();
			element.Name = "First";
			element.Level = 1;

			Assert.AreEqual("First", element.Name);
			Assert.AreEqual(1, element.Level);
		}

		[TestMethod]
		public void CreatesElementConfigurationCreatesCorrectly()
		{
			var element = new LogVerbosityTypeElement("Second", 2);
			Assert.AreEqual("Second", element.Name);
			Assert.AreEqual(2, element.Level);
		}

		#endregion
	}
}
