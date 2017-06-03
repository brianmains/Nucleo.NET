using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.ObjectModel
{
	[TestClass]
	public class AttributedObjectTest
	{
		#region " Test Classes "

		protected class TestClass : AttributedObject
		{
			public string Key
			{
				get { return base.GetValue<string>("Key"); }
				set { base.AddOrUpdateValue("Key", value); }
			}

			public string Name
			{
				get { return base.GetValue<string>("Name"); }
				set { base.AddOrUpdateValue("Name", value); }
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var obj = new TestClass();

			//Act
			obj.Key = "1";
			obj.Name = "First";

			var values = obj.ToValuesList();

			//Assert
			Assert.AreEqual("1", values["Key"]);
			Assert.AreEqual("First", values["Name"]);
		}

		#endregion
	}
}
