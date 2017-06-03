using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Lookups.Configuration
{
	[TestClass]
	public class LookupElementTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWOrksOK()
		{
			//Arrange
			var element = new LookupElement();

			//Act
			element.EffectiveDate = new DateTime(1900, 1, 1);
			element.EndDate = new DateTime(2007, 1, 1);
			element.Name = "Test";
			element.RepresentationCode = "TE";
			element.Value = "1";

			//Assert
			Assert.AreEqual(new DateTime(1900, 1, 1), element.EffectiveDate);
			Assert.AreEqual(new DateTime(2007, 1, 1), element.EndDate);
			Assert.AreEqual("Test", element.Name);
			Assert.AreEqual("TE", element.RepresentationCode);
			Assert.AreEqual("1", element.Value);
		}

		#endregion
	}
}
