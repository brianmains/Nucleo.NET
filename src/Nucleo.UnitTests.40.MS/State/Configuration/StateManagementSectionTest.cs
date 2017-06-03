using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.State.Configuration
{
	[TestClass]
	public class StateManagementSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingPropertiesReturnsCorrectObjects()
		{
			var section = new StateManagementSection();
			section.StateProperties.Add(new StatePropertyElement
			{
				 Name = "Theme",
				 DefaultValue="Default"
			});
			section.StateProperties.Add(new StatePropertyElement
			{
				Name = "Language",
				DefaultValue = "en-us"
			});
			section.StateProperties.Add(new StatePropertyElement
			{
				Name = "Location",
				DefaultValue = "Pittsburgh, PA"
			});

			Assert.IsNotNull(section.StateProperties["Location"]);
			Assert.IsNotNull(section.StateProperties["Theme"]);
		}

		[TestMethod]
		public void GettingRegionsReturnsCorrectObjects()
		{
			//Arrange
			var section = new StateManagementSection();

			//Act
			section.StateRegions.Add(new StateRegionElement
			{
				Name = "Test"
			});
			section.StateRegions.Add(new StateRegionElement
			{
				Name = "Test2"
			});
			
			//Assert
			Assert.IsNotNull(section.StateRegions["Test"]);
			Assert.IsNotNull(section.StateRegions["Test2"]);
		}

		[TestMethod]
		public void GettingValuesProviderReturnsCorrectObjects()
		{
			var section = new StateManagementSection();
			section.ValueProviders.Providers.Add(new ProviderSettings
			{
				Name = "MyValuesProvider",
				Type = "Nucleo.FakeValuesProvider,Nucleo"
			});
			section.ValueProviders.Providers.Add(new ProviderSettings
			{
				Name = "MyValuesProvider2",
				Type = "Nucleo.TestValuesProvider,Nucleo"
			});

			Assert.AreEqual(2, section.ValueProviders.Providers.Count);
			Assert.IsNotNull(section.ValueProviders.Providers["MyValuesProvider"]);
			Assert.AreEqual("Nucleo.TestValuesProvider,Nucleo", section.ValueProviders.Providers["MyValuesProvider2"].Type);
		}

		#endregion
	}
}
