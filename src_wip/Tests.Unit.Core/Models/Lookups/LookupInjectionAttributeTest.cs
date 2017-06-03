using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Models.Lookups
{
	[TestClass]
	public class LookupInjectionAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingAttributeWorksOK()
		{
			//Arrange
			

			//Act
			var attrib = new LookupInjectionAttribute("Test");

			//Assert
			Assert.AreEqual("Test", attrib.LookupName);
		}

		#endregion
	}
}
