using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Lookups.Configuration
{
	[TestClass]
	public class LookupRepositoriesSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void WorkingWithMappingsIsOK()
		{
			//Arrange
			var section = new LookupRepositoriesSection();

			//Act
			section.Mappings.Add(new Nucleo.Configuration.NameTypeElement("test", "type"));

			//Assert
			Assert.AreEqual(1, section.Mappings.Count);
		}

		#endregion
	}
}
