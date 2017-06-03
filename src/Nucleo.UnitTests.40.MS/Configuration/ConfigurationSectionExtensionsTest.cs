using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Configuration
{
	[TestClass]
	public class ConfigurationSectionExtensionsTest
	{
		#region " Test Classes "

		public class TestConfigurationSection : ConfigurationSection
		{
			[ConfigurationProperty("maxCount")]
			public int MaxCount
			{
				get { return (int)this["maxCount"]; }
				set { this["maxCount"] = value; }
			}

			[ConfigurationProperty("objectType")]
			public string ObjectType
			{
				get { return (string)this["objectType"]; }
				set { this["objectType"] = value; }
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void LoadingPropertyTypeWithFunctionSuccessfullyWorksOK()
		{
			//Arrange
			var section = new TestConfigurationSection();

			//Act
			section.ObjectType = "Nucleo.Configuration.ConfigurationSectionExtensionsTest," + typeof(ConfigurationSectionBaseTest).Assembly.FullName;
			var obj = section.Create<TestConfigurationSection, ConfigurationSectionExtensionsTest>(i => i.ObjectType);

			//Assert
			Assert.IsNotNull(obj, "Object is null");
		}

		[TestMethod]
		public void LoadingPropertyTypeSuccessfullyWorksOK()
		{
			//Arrange
			var section = new TestConfigurationSection();

			//Act
			section.ObjectType = "Nucleo.Configuration.ConfigurationSectionExtensionsTest," + typeof(ConfigurationSectionBaseTest).Assembly.FullName;
			var obj = section.Create<ConfigurationSectionExtensionsTest>("ObjectType");

			//Assert
			Assert.IsNotNull(obj, "Object is null");
		}

		#endregion
	}
}
