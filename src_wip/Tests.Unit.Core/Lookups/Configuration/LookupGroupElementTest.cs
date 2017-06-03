using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Lookups.Configuration
{
	[TestClass]
	public class LookupGroupElementTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingValuesWorksOK()
		{
			//Arrange
			var group = new LookupGroupElement();

			//Act
			group.Values.Add(new LookupElement());

			//Assert
			Assert.AreEqual(1, group.Values.Count);
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var group = new LookupGroupElement();

			//Act
			group.LookupName = "Test";

			//Assert
			Assert.AreEqual("Test", group.LookupName);
		}

		#endregion
	}
}
