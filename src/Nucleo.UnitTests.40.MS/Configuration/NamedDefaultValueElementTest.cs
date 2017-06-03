using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Configuration
{
	[TestClass]
	public class NamedDefaultValueElementTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingObjectWorks()
		{
			NamedDefaultValueElement element = new NamedDefaultValueElement();
			element.Name = "Value";
			element.Value = "Value";
			element.DefaultValue = "Default";

			Assert.AreEqual("Value", element.Name);
			Assert.AreEqual("Value", element.Value);
			Assert.AreEqual("Default", element.DefaultValue);
		}

		#endregion
	}
}
