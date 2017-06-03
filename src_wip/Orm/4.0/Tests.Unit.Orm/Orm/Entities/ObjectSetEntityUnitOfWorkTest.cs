using System;
using System.Linq;
using System.Data;
using System.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;




namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class ObjectSetEntityUnitOfWorkTest
	{
		#region " Test Classes "

		public class TestEntity { }

		public class TestInvalidEntity { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingNewObjectReturnsActualInstance()
		{
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);

			var entity = uow.CreateNew();

			Assert.IsNotNull(entity);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByKeyReturnsNull()
		{
			object entity = new TestEntity();

			var key = Isolate.Fake.Instance<EntityKey>();
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);

			Isolate.WhenCalled(() => os.Context.TryGetObjectByKey(key, out entity)).WillReturn(false);

			var output = uow.Get(key);

			Assert.IsNull(output);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByInvalidKeyReturnsNull()
		{
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);

			Assert.IsNull(uow.Get(new object()));
		}

		[TestMethod]
		public void GettingByKeyReturnsObject()
		{
			object entity = new TestEntity();

			var key = Isolate.Fake.Instance<EntityKey>();
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);

			Isolate.WhenCalled(() => os.Context.TryGetObjectByKey(key, out entity)).WillReturn(true);

			var output = uow.Get(key);

			Assert.AreEqual(entity, output);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(InvalidCastException))
		]
		public void GettingByKeyWithInvalidTypeThrowsException()
		{
			object entity = new TestInvalidEntity();

			var key = Isolate.Fake.Instance<EntityKey>();
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);

			Isolate.WhenCalled(() => os.Context.TryGetObjectByKey(key, out entity)).WillReturn(true);

			var output = uow.Get(key);
			Assert.Fail("The entity of an incorrect type must throw an exception, but it didn't.");

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GettingByNullEntityKeyThrowsException()
		{
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);

			uow.Get(null);
		}

		[TestMethod]
		public void QueuingDeleteRemovedFromObjectSet()
		{
			//Arrange
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var uow = new ObjectSetEntityUnitOfWork<TestEntity>(os);
			var entity = new TestEntity();

			//Act
			uow.QueueDelete(entity);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => os.DeleteObject(null));

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingDeleteWithNullObjectThrowsException()
		{
			var uow = Isolate.Fake.Instance<ObjectSetEntityUnitOfWork<TestEntity>>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.QueueDelete(null);
		}

		[TestMethod]
		public void QueuingInsertAddsToObjectSet()
		{
			//Arrange
			var fake = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			Isolate.WhenCalled(() => fake.AddObject(null)).IgnoreCall();
			var set = new ObjectSetEntityUnitOfWork<TestEntity>(fake);
			var entity = new TestEntity();

			//Act
			set.QueueInsert(entity);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => fake.AddObject(null));

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingInsertWithNullObjectThrowsException()
		{
			var uow = Isolate.Fake.Instance<ObjectSetEntityUnitOfWork<TestEntity>>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.QueueInsert(null);
		}

		[TestMethod]
		public void QueuingUpdateDoesNothing()
		{
			//Arrange
			var fake = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			Isolate.WhenCalled(() => fake.AddObject(null)).IgnoreCall();
			Isolate.WhenCalled(() => fake.DeleteObject(null)).IgnoreCall();
			var set = new ObjectSetEntityUnitOfWork<TestEntity>(fake);
			var entity = new TestEntity();

			//Act
			set.QueueUpdate(entity);

			//Assert
			Isolate.Verify.WasNotCalled(() => fake.AddObject(null));
			Isolate.Verify.WasNotCalled(() => fake.DeleteObject(null));

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingUpdateWithNullObjectThrowsException()
		{
			var uow = Isolate.Fake.Instance<ObjectSetEntityUnitOfWork<TestEntity>>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.QueueUpdate(null);
		}

		[TestMethod]
		public void SavingChangesCommitsToContext()
		{
			//Arrange
			var fake = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			Isolate.WhenCalled(() => fake.Context.SaveChanges()).WillReturn(1);
			var set = new ObjectSetEntityUnitOfWork<TestEntity>(fake);

			//Act
			set.SaveChanges();

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => fake.Context.SaveChanges());

			Isolate.CleanUp();
		}

		#endregion
	}
}
