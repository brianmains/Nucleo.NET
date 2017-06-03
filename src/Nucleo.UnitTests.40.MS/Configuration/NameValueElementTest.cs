using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Configuration
{
	[TestClass]
	public class NameValueElementTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingObjectWorks()
		{
			NameValueElement element = new NameValueElement();
			element.Name = "Test";
			element.Value = "Value";

			Assert.AreEqual("Test", element.Name);
			Assert.AreEqual("Value", element.Value);
		}

		#endregion
	}
}
