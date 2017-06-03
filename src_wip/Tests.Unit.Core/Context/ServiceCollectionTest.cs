using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Exceptions;



namespace Nucleo.Context
{
	[TestClass]
	public class ServiceCollectionTest
	{
		#region " Test Classes "

		public interface IFakeNameService : IService
		{
			string GetGreeting(string name);
		}

		public class FakeNameService : IFakeNameService
		{
			#region " Methods "

			public string GetGreeting(string name)
			{
				return "Hello, " + name;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingNullReferenceThrowsException()
		{
			//Arrange
			var collectionFake = Isolate.Fake.Instance<ServiceCollection>(Members.CallOriginal);

			//Act
			var result = ExceptionTester.CheckException(true, (src) => { collectionFake.Add(null); });

			//Assert
			Assert.IsTrue(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByTypeReturnsCorrectReferences()
		{
			//Arrange
			var collectionFake = Isolate.Fake.Instance<ServiceCollection>(Members.CallOriginal);

			//Act
			collectionFake.Add(new FakeNameService());

			//Assert
			Assert.IsNotNull(collectionFake.GetByType<IFakeNameService>(), "IFakeNameService is null");
			Assert.IsNotNull(collectionFake.GetByType<FakeNameService>(), "FakeNameService is null");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingNullReferenceThrowsException()
		{
			//Arrange
			var collectionFake = Isolate.Fake.Instance<ServiceCollection>(Members.CallOriginal);

			//Act
			var result = ExceptionTester.CheckException(true, (src) => { collectionFake.Remove(null); });

			//Assert
			Assert.IsTrue(result);

			Isolate.CleanUp();
		}

		#endregion
	}
}
