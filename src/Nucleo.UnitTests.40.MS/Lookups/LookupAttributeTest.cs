using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupAttributeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingAttributeWorksOK()
		{
			//Arrange
			var attrib = default(LookupAttribute);

			//Act
			attrib = new LookupAttribute("Test");

			//Assert
			Assert.AreEqual("Test", attrib.LookupName);
		}

		#endregion
	}
}
