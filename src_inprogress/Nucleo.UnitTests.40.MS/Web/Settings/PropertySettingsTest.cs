using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Reflection;


namespace Nucleo.Web.Settings
{
	[TestClass]
	public class PropertySettingsTest : PropertySettings
	{
		#region " Constructors "

		public PropertySettingsTest() { }

		public PropertySettingsTest(IDictionary<string, object> settings)
			: base(settings) { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingValuesWorksOK()
		{
			//Arrange
			var settings = new PropertySettingsTest();
			
			//Act
			settings.AddOrUpdateValue("Name", "MyName");
			settings.AddOrUpdateValue("Address", "1 S Lane");
			settings.AddOrUpdateValue("City", "Pittsburgh");
			settings.AddOrUpdateValue("State", "PA");

			//Assert
			Assert.AreEqual("MyName", settings.Settings["Name"]);
			Assert.AreEqual("1 S Lane", settings.Settings["Address"]);
			Assert.AreEqual("Pittsburgh", settings.Settings["City"]);
			Assert.AreEqual("PA", settings.Settings["State"]);
		}

		[TestMethod]
		public void GettingGenericValuesWorksOK()
		{
			//Arrange
			var list = new Dictionary<string, object>();
			list.Add("1", 1);
			list.Add("2", 2);
			list.Add("3", 3);

			var settings = new PropertySettingsTest(list);

			//Act
			var one = settings.GetValue<int>("1");
			var three = settings.GetValue<int>("3");

			//Assert
			Assert.AreEqual(1, one);
			Assert.AreEqual(3, three);
		}

		[TestMethod]
		public void GettingValuesWorksOK()
		{
			//Arrange
			var list = new Dictionary<string, object>();
			list.Add("1", 1);
			list.Add("2", 2);
			list.Add("3", 3);

			var settings = new PropertySettingsTest(list);

			//Act
			var one = settings.GetValue("1");
			var three = settings.GetValue("3");

			//Assert
			Assert.AreEqual(1, one);
			Assert.AreEqual(3, three);
		}

		[TestMethod]
		public void UpdatingValuesWorksOK()
		{
			//Arrange
			var settings = new PropertySettingsTest();

			//Act
			settings.AddOrUpdateValue("Name", "MyName");
			settings.AddOrUpdateValue("Name", "NewName");

			//Assert
			Assert.AreEqual("NewName", settings.Settings["Name"]);
		}

		#endregion
	}
}
