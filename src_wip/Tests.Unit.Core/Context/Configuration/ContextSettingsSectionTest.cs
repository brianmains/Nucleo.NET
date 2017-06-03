using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Configuration;


namespace Nucleo.Context.Configuration
{
	[TestClass]
	public class ContextSettingsSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void ReadingAndWritingPropertiesAssignsCorrectly()
		{
			//Arrange
			var section = new ContextSettingsSection();

			//Act
			section.ServiceRegistryType = "Test";

			//Assert
			Assert.AreEqual("Test", section.ServiceRegistryType, "Registry Type doesn't match");
		}

		[TestMethod]
		public void ReadingAndWritingServicesWorksCorrectly()
		{
			//Arrange
			var section = new ContextSettingsSection();

			//Act
			section.Services.Add(new TypeRegistrationElement { ContractTypeName = "First", MappedTypeName = "FirstType" });
			section.Services.Add(new TypeRegistrationElement { ContractTypeName = "Second", MappedTypeName = "SecondType" });

			//Assert
			Assert.AreEqual(2, section.Services.Count);
		}
 
		#endregion
	}
}
