using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class JsonSerializableObjectTest
	{
		#region " Test Classes "

		protected class JsonTestClass : JsonSerializableObject
		{
			public string Name
			{
				get { return base.GetValue<string>("name"); }
				set { base.AddOrUpdateValue("name", value); }
			}

			public string Value
			{
				get { return base.GetValue<string>("value"); }
				set { base.AddOrUpdateValue("value", value); }
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingJsonDataWorksOK()
		{
			//Arrange
			var testClass = new JsonTestClass { Name = "First", Value = "1" };

			//Act
			string json = testClass.ToJson();

			//Assert
			StringAssert.Contains(json, "\"name\":");
			StringAssert.Contains(json, "\"value\":");
		}

		[TestMethod]
		public void SettingJsonDataWorksOK()
		{
			//Arrange
			string json = "{ name: 'First', value: '1' }";

			//Act
			var testClass = new JsonTestClass();
			testClass.FromJson(json);

			//Assert
			Assert.AreEqual("First", testClass.Name);
			Assert.AreEqual("1", testClass.Value);
		}

		#endregion
	}
}