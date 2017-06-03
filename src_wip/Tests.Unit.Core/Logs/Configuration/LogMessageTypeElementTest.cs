using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Logs.Configuration
{
	[TestClass]
	public class LogMessageTypeElementTest
	{
		#region " Tests "

		[TestMethod]
		public void AssigningValuesToElementConfigurationAssignsCorrectly()
		{
			var element = new LogMessageTypeElement();
			element.Name = "First";
			element.Value = 1;

			Assert.AreEqual("First", element.Name);
			Assert.AreEqual(1, element.Value);
		}

		[TestMethod]
		public void CreatesElementConfigurationCreatesCorrectly()
		{
			var element = new LogMessageTypeElement("Second", 2);
			Assert.AreEqual("Second", element.Name);
			Assert.AreEqual(2, element.Value);
		}

		#endregion
	}
}
