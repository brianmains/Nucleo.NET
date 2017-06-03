using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.EventsManagement.Listeners
{
	[TestClass]
	public class EntityListenerCriteriaTest
	{
		#region " Test Classes "

		protected class TestClass { }

		protected class TestOppositeClass { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void AnyMatchMatchesOK()
		{
			//Arrange
			var cls = new TestClass();
			var any = new AnyListenerCriteria();

			//Act
			var listener = new EntityListenerCriteria(cls);
			var match = listener.IsMatch(any);

			//Assert
			Assert.IsTrue(match);
		}

		[TestMethod]
		public void CreatingListenerWorksOK()
		{
			//Arrange
			

			//Act
			var listener = new EntityListenerCriteria(typeof(object));

			//Assert
			Assert.AreEqual(typeof(object), listener.Entity);
		}

		[TestMethod]
		public void IsMatchForEntityTypesReturnsFalse()
		{
			//Arrange
			var listener = Isolate.Fake.Instance<EntityTypeListenerCriteria>();
			Isolate.WhenCalled(() => listener.EntityType).WillReturn(typeof(TestOppositeClass));
			var cls = new TestClass();

			//Act
			var obj = new EntityListenerCriteria(cls);
			var result = obj.IsMatch(listener);

			//Assert
			Assert.IsFalse(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void IsMatchForEntityTypesReturnsTrue()
		{
			//Arrange
			var listener = Isolate.Fake.Instance<EntityTypeListenerCriteria>();
			Isolate.WhenCalled(() => listener.EntityType).WillReturn(typeof(TestClass));
			var cls = new TestClass();

			//Act
			var obj = new EntityListenerCriteria(cls);
			var result = obj.IsMatch(listener);

			//Assert
			Assert.IsTrue(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void IsMatchForEntityWhenOneObjectExistsReturnsFalse()
		{
			//Arrange
			var listener = Isolate.Fake.Instance<EntityListenerCriteria>();
			Isolate.WhenCalled(() => listener.Entity).WillReturn(typeof(TestClass));

			//Act
			var obj = new EntityListenerCriteria(typeof(TestClass));
			var result = obj.IsMatch(listener);

			//Assert
			Assert.IsTrue(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void NullEntityThrowsException()
		{
			//Arrange
			
			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { new EntityListenerCriteria(null); });
		}

		#endregion
	}
}
