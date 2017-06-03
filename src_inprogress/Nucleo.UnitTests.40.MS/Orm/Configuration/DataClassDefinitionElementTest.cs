using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	[TestClass]
	public class DataClassDefinitionElementTest
	{
		#region " Test Classes "

		protected class TestElement : DataClassDefinitionElement 
		{
			public string GetUniqueKey() { return this.UniqueKey; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingAndSettingWorksOK()
		{
			//Arrange
			var element = new DataClassDefinitionElement();

			//Act
			element.DataClassName = "Test";
			element.Triggers.Add(new NameTypeElement());

			//Assert
			Assert.AreEqual("Test", element.DataClassName);
			Assert.AreEqual(1, element.Triggers.Count);
		}

		[TestMethod]
		public void GettingUniqueKeyReturnsCorrectField()
		{
			//Arrange
			var el = new TestElement
			{
				DataClassName = "XYZ"
			};

			//Act
			var key = el.GetUniqueKey();

			//Assert
			Assert.AreEqual("XYZ", key);
		}

		#endregion
	}
}
