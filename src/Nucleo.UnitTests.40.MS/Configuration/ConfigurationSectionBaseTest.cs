using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;


namespace Nucleo.Configuration
{
	[TestClass]
	public class ConfigurationSectionBaseTest : ConfigurationSectionBase
	{
		#region " Test Classes "

		protected class SimpleClass { }

		protected class ComplexClass
		{
			public string Name
			{
				get;
				set;
			}

			public ComplexClass(string name)
			{
				
			}
		}

		#endregion



		#region " Properties "

		public string SimpleType
		{
			get { return "Nucleo.Configuration.ConfigurationSectionBaseTest+SimpleClass," + typeof(ConfigurationSectionBaseTest).Assembly.FullName; }
		}

		public string ComplexType
		{
			get { return "Nucleo.Configuration.ConfigurationSectionBaseTest+ComplexClass," + typeof(ConfigurationSectionBaseTest).Assembly.FullName; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingTypeWithNullNameThrowsException()
		{
			//Arrange
			var test = new ConfigurationSectionBaseTest();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { test.Create<SimpleClass>(null); });
			ExceptionTester.CheckException(true, (src) => { test.Create<SimpleClass>(string.Empty); });
		}

		[TestMethod]
		public void CreatingTypeWorksOK()
		{
			//Arrange
			var test = new ConfigurationSectionBaseTest();

			//Act
			var obj = test.Create<SimpleClass>("SimpleType");

			//Assert
			Assert.IsNotNull(obj, "Object was null");
		}

		#endregion
	}
}
