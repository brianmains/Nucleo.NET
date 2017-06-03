using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectMethodTest
	{
		#region " Test Class "

		protected class TestClass
		{
			public int Key
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

			public string GetName()
			{
				return this.Name;
			}

			protected void SetKey(int key)
			{
				this.Key = key;
			}

			public void SetName(string name)
			{
				this.Name = name;
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void ActionsWorkOK()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };
			var member = new ReflectMethod("GetName", obj, true);

			//Act

			//Assert
			member.Action((m) =>
			{
				Assert.IsNotNull(m);
				Assert.AreEqual(member, m);
			});
		}

		[TestMethod]
		public void ExecutingGenericParameterlessMethodThatDoesntExistThrowsException()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("GetName", obj, true);

			//Assert
			ExceptionTester.CheckException(true, (src) => { string value = member.Invoke<string>(); });
		}

		[TestMethod]
		public void ExecutingGenericParameterlessMethodWorksOK()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("GetName", obj, false);
			var value = member.Invoke<string>();

			//Assert
			Assert.AreEqual("First", value);
		}

		[TestMethod]
		public void ExecutingGenericParameterMethodThatDoesntExistThrowsException()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("SetName", obj, true);

			//Assert
			ExceptionTester.CheckException(true, (src) => { member.Invoke<string>("Second"); });
		}

		[TestMethod]
		public void ExecutingGenericParameterMethodWorksOK()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("SetName", obj, false);
			member.Invoke<string>("Third");

			//Assert
			Assert.AreEqual("Third", obj.GetName());
		}

		[TestMethod]
		public void ExecutingParameterlessMethodThatDoesntExistThrowsException()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };
			
			//Act
			var member = new ReflectMethod("GetName", obj, true);

			//Assert
			ExceptionTester.CheckException(true, (src) => { object value = member.Invoke(); });
		}

		[TestMethod]
		public void ExecutingParameterlessMethodWorksOK()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("GetName", obj, false);
			var value = member.Invoke();

			//Assert
			Assert.AreEqual("First", value);
		}

		[TestMethod]
		public void ExecutingParameterMethodThatDoesntExistThrowsException()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("SetName", obj, true);

			//Assert
			ExceptionTester.CheckException(true, (src) => { object value = member.Invoke("Fourth"); });
		}

		[TestMethod]
		public void ExecutingParameterMethodWorksOK()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("SetName", obj, false);
			member.Invoke("Fifth");

			//Assert
			Assert.AreEqual("Fifth", obj.GetName());
		}

		[TestMethod]
		public void ExecutingTypeParameterMethodWorksOK()
		{
			//Arrange
			var obj = new TestClass { Key = 1, Name = "First" };

			//Act
			var member = new ReflectMethod("SetName", obj, false);
			member.Invoke(new object[] { "Sixth" }, new Type[] { typeof(string) });

			//Assert
			Assert.AreEqual("Sixth", obj.GetName());
		}

		#endregion
	}
}
