using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Collections
{
	[TestClass]
	public class TypeRegistryTest
	{
		#region " Test Classes "

		protected class TestClass : ITestClass { }

		protected interface ITestClass : IBaseClass { }

		protected interface IBaseClass { }

		protected class TestClass2 { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CopyingKeysWorksOK()
		{
			//Arrange
			var reg1 = new TypeRegistry(new Dictionary<Type, object>
				{
					{ typeof(ITestClass), new TestClass() },
					{ typeof(TestClass2), new TestClass2() }
				});
			var reg2 = new TypeRegistry();

			//Act
			reg2.CopyFrom(reg1);

			//Assert
			Assert.AreEqual(2, reg2.Count);
		}

		[TestMethod]
		public void GettingRegisteredItemByExplicitTypeWorksOK()
		{
			//Arrange
			var test = new TestClass();
			var dict = new Dictionary<Type, object>();
			dict.Add(typeof(ITestClass), test);

			var reg = new TypeRegistry(dict);

			//Act
			var output = reg.GetRegistration(typeof(ITestClass));

			//Assert
			Assert.AreEqual(test, output);
		}

		[TestMethod]
		public void GettingRegisteredItemWorksOK()
		{
			//Arrange
			var test = new TestClass();
			var dict = new Dictionary<Type, object>();
			dict.Add(typeof(ITestClass), test);

			var reg = new TypeRegistry(dict);

			//Act
			var output = reg.GetRegistration<ITestClass>();

			//Assert
			Assert.AreEqual(test, output);
		}

		[TestMethod]
		public void RegisteringTypesWithGenericWorksOK()
		{
			//Arrange
			var reg = new TypeRegistry();

			//Act
			var result = reg.Register<ITestClass>(new TestClass());

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void RegisteringTypesWorksOK()
		{
			//Arrange
			var reg = new TypeRegistry();

			//Act
			var result = reg.Register(typeof(ITestClass), new TestClass());

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void ValidatingTypeAllowsTypeToPass()
		{
			//Arrange
			var reg = new TypeRegistry { PermittedType = typeof(IBaseClass) };

			//Act
			var result = reg.Register<ITestClass>(new TestClass());

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void ValidatingTypeFailsForIncorrectType()
		{
			//Arrange
			var reg = new TypeRegistry { PermittedType = typeof(IBaseClass) };

			//Act
			var result = reg.Register<TestClass2>(new TestClass2());

			//Assert
			Assert.IsFalse(result);
		}

		#endregion
	}
}
