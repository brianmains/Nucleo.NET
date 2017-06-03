using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectPropertyTest
	{
		#region " Test Class "

		protected class TestClass
		{
			private int _key = 0;
			private string _name = null;

			[Required]
			protected int Key
			{
				get { return _key; }
				set { _key = value; }
			}

			[Required]
			public string Name
			{
				get { return _name; }
				set { _name = value; }
			}

			public int GetKey()
			{
				return this.Key;
			}

			public void SetKey(int key)
			{
				this.Key = key;
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ActionsWorkOK()
		{
			//Arrange
			var testClass = new TestClass();
			var prop = new ReflectProperty("Key", testClass, true);

			//Act

			//Assert
			prop.Action((p) =>
			{
				Assert.IsNotNull(p);
				Assert.AreEqual(prop, p);
			});
		}

		[TestMethod]
		public void GettingAttributesForNonPublicPropertyWorksOK()
		{
			//Arrange
			var testClass = new TestClass();
			var prop = new ReflectProperty("Key", testClass, true);

			//Act
			var attrib = prop.GetAttribute(typeof(RequiredAttribute), true);

			//Assert
			Assert.IsNotNull(attrib);
			Assert.IsInstanceOfType(attrib, typeof(RequiredAttribute));
		}

		[TestMethod]
		public void SettingUpPrivateReflectionGettingWorksOK()
		{
			//Arrange
			var testClass = new TestClass();
			testClass.SetKey(12);

			var prop = new ReflectProperty("Key", testClass, true);

			//Act
			var value = prop.GetValue();

			//Assert
			Assert.AreEqual(12, value);
		}

		[TestMethod]
		public void SettingUpPrivateReflectionSettingWorksOK()
		{
			//Arrange
			var testClass = new TestClass();
			testClass.SetKey(15);

			var prop = new ReflectProperty("Key", testClass, true);

			//Act
			prop.SetValue<int>(25);

			//Assert
			Assert.AreEqual(25, testClass.GetKey());
		}

		[TestMethod]
		public void SettingUpPublicReflectionGettingWorksOK()
		{
			//Arrange
			var testClass = new TestClass { Name = "Test Class" };
			var prop = new ReflectProperty("Name", testClass, false);

			//Act
			var value = prop.GetValue();

			//Assert
			Assert.AreEqual("Test Class", value);
		}

		[TestMethod]
		public void SettingUpPublicReflectionSettingWorksOK()
		{
			//Arrange
			var testClass = new TestClass { Name = "Test Class" };
			var prop = new ReflectProperty("Name", testClass, false);

			//Act
			prop.SetValue("ABC");

			//Assert
			Assert.AreEqual("ABC", testClass.Name);
		}

		#endregion
	}
}
