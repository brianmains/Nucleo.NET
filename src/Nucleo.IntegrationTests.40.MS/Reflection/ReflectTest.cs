using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectTest
	{
		#region " Test Classes "

		protected class TestClass
		{
			protected int Key
			{
				get;
				set;
			}

			public string Name
			{
				get;
				set;
			}

			protected int GetKey()
			{
				return this.Key;
			}

			public int GetKeyValue()
			{
				return this.Key;
			}

			public string GetName()
			{
				return this.Name;
			}

			public void SetKey(int key)
			{
				this.Key = key;
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ReflectingOnNonPublicMethodsReturnsValue()
		{
			//Arrange
			var obj = new TestClass();
			obj.SetKey(45);

			//Act
			var value = Reflect.NonPublic(obj).Method("GetKey").Invoke();

			//Assert
			Assert.AreEqual(45, value);
		}

		[TestMethod]
		public void ReflectingOnNonPublicPropertiesReturnsValue()
		{
			//Arrange
			var obj = new TestClass();
			obj.SetKey(15);

			//Act
			var value = Reflect.NonPublic(obj).Property("Key").GetValue();

			//Assert
			Assert.AreEqual(15, value);
		}

		[TestMethod]
		public void ReflectingOnPublicMethodsReturnsValue()
		{
			//Arrange
			var obj = new TestClass();
			obj.Name = "Other";

			//Act
			var value = Reflect.Public(obj).Method("GetName").Invoke();

			//Assert
			Assert.AreEqual("Other", value);
		}

		[TestMethod]
		public void ReflectingOnPublicMethodsThatDontReturnValueWorksOK()
		{
			//Arrange
			var obj = new TestClass();

			//Act
			var value = Reflect.Public(obj).Method("SetKey").Invoke(25);

			//Assert
			Assert.AreEqual(null, value);
			Assert.AreEqual(25, obj.GetKeyValue());
		}

		[TestMethod]
		public void ReflectingOnPublicPropertiesReturnsValue()
		{
			//Arrange
			var obj = new TestClass();
			obj.Name = "Test";

			//Act
			var value = Reflect.Public(obj).Property("Name").GetValue();

			//Assert
			Assert.AreEqual("Test", value);
		}

		#endregion
	}
}
