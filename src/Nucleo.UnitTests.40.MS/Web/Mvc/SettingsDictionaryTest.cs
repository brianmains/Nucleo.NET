using System;
using System.Collections.Generic;
using Nucleo.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Mvc
{
	[TestClass]
	public class SettingsDictionaryTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsToDictionaryWorks()
		{
			//Arrange
			var dictionary = new SettingsDictionary();

			//Act
			dictionary.AddSetting("Test", 1);

			//Assert
			Assert.AreEqual(1, dictionary.GetSetting("Test"));
		}

		[TestMethod]
		public void GettingItemsGenericallyToDictionaryWorks()
		{
			//Arrange
			var items = new Dictionary<string, object>();
			items.Add("First", 1);
			items.Add("Second", 2);

			var dictionary = new SettingsDictionary(items);

			//Act
			var value = dictionary.GetSetting<int>("First");

			//Assert
			Assert.AreEqual(1, value);
		}

		[TestMethod]
		public void GettingItemsToDictionaryWorks()
		{
			//Arrange
			var items = new Dictionary<string, object>();
			items.Add("First", 1);
			items.Add("Second", 2);

			var dictionary = new SettingsDictionary(items);

			//Act
			var value = dictionary.GetSetting("First");

			//Assert
			Assert.IsNotNull(value);
		}

		[TestMethod]
		public void RemovingItemsToDictionaryWorks()
		{
			//Arrange
			var items = new Dictionary<string, object>();
			items.Add("First", 1);
			items.Add("Second", 2);

			var dictionary = new SettingsDictionary(items);

			//Act
			dictionary.RemoveSetting("First");

			//Assert
			Assert.IsNull(dictionary.GetSetting("First"));
			Assert.IsNotNull(dictionary.GetSetting("Second"));
		}

		#endregion
	}
}
