using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.State.Configuration
{
	[TestClass]
	public class StatePropertyElementTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertyValuesAssignsCorrectValues()
		{
			StatePropertyElement element = new StatePropertyElement();
			element.Name = "Test";
			element.DefaultValue = "1";

			Assert.AreEqual("Test", element.Name);
			Assert.AreEqual("1", element.DefaultValue);
		}

		#endregion
	}
}
