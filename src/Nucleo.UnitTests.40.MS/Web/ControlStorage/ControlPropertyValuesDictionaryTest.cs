using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ControlStorage
{
	[TestClass]
	public class ControlPropertyValuesDictionaryTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingKeyValuePersistenceToDictionaryAssignsOK()
		{
			//Arrange
			var dict = new ControlPropertyValuesDictionary();

			//Act
			dict.AddOrUpdate("Key", 123, new ControlPropertyOptions { Storage = ControlPropertyStorage.Persist });
			var value = dict.Get("Key");

			//Assert
			Assert.AreEqual("Key", value.Key);
			Assert.AreEqual(123, value.Value);
			Assert.AreEqual(ControlPropertyStorage.Persist, value.Options.Storage);
		}

		[TestMethod]
		public void AddingKeyValueToDictionaryAssignsOK()
		{
			//Arrange
			var dict = new ControlPropertyValuesDictionary();

			//Act
			dict.AddOrUpdate("Key", 123);
			var value = dict.Get("Key");

			//Assert
			Assert.AreEqual("Key", value.Key);
			Assert.AreEqual(123, value.Value);
		}

		#endregion
	}
}
