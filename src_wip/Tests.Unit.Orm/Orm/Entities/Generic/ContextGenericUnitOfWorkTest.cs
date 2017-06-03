using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Orm.Generic;
using System.Data;


namespace Nucleo.Orm.Entities.Generic
{
	[TestClass]
	public class ContextGenericUnitOfWorkTest
	{
		protected class TestClass { }

		protected class TestClass2 { }

		protected class TestClass3 { }

		protected class TestClassOut { }



		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void ConstructingWithNullThrowsException()
		{
			new ContextGenericUnitOfWork(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void CreatingNewEntityWithNullInfoThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.CreateNew(null);
		}

		[TestMethod]
		public void CreatingNewEntityWorksOK()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.CreateNew(new EntityKeyInformation { EntityType = typeof(TestClass) });

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void GettingEntityWithNullInfoThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Get(null);
		}

		[TestMethod]
		public void GettingInvalidEntityWithKeyReturnsNull()
		{
			object val;
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			Isolate.WhenCalled(() => ctx.TryGetObjectByKey(null, out val)).WillReturn(false);

			var entityKey = Isolate.Fake.Instance<EntityKey>();
			Isolate.Swap.NextInstance<EntityKey>().With(entityKey);

			var memberKey = Isolate.Fake.Instance<EntityKeyMember>();
			Isolate.Swap.NextInstance<EntityKeyMember>().With(memberKey);

			var uow = new ContextGenericUnitOfWork(ctx);
			var obj = uow.Get(new EntityKeyInformation());

			Assert.IsNull(obj);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingValidEntityWithKeyReturnsObject()
		{
			object val = null;
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			Isolate.WhenCalled(() => ctx.TryGetObjectByKey(null, out val)).WillReturn(true);

			var entityKey = Isolate.Fake.Instance<EntityKey>();
			Isolate.Swap.NextInstance<EntityKey>().With(entityKey);

			var memberKey = Isolate.Fake.Instance<EntityKeyMember>();
			Isolate.Swap.NextInstance<EntityKeyMember>().With(memberKey);

			var uow = new ContextGenericUnitOfWork(ctx);
			var obj = uow.Get(new EntityKeyInformation());

			Assert.AreEqual(val, obj);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueryingGenericIQueryableWithNullLambdaThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Query<NucleoObjectContext, TestClass>(default(Func<NucleoObjectContext, IQueryable<TestClass>>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueryingWithNullExpression1ThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Query<TestClass>(default(Func<ObjectSet<TestClass>, IQueryable<TestClass>>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueryingWithNullExpression2ThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Query<TestClass, TestClassOut>(default(Func<ObjectSet<TestClass>, IQueryable<TestClassOut>>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueryingWithNullExpression3ThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Query<TestClass, TestClass2, TestClassOut>(default(Func<ObjectSet<TestClass>, ObjectSet<TestClass2>, IQueryable<TestClassOut>>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueryingWithNullExpression4ThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Query<TestClass, TestClass2, TestClass3, TestClassOut>(default(Func<ObjectSet<TestClass>, ObjectSet<TestClass2>, ObjectSet<TestClass3>, IQueryable<TestClassOut>>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueryingIQueryableWithNullLambdaThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.Query<NucleoObjectContext>(default(Func<NucleoObjectContext, IQueryable>));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingDeleteWithNullEntityThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);
			var info = Isolate.Fake.Instance<EntityKeyInformation>();

			uow.QueueDelete(info, null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingDeleteWithNullInfoThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.QueueDelete(null, new object());
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingInsertWithNullEntityThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);
			var info = Isolate.Fake.Instance<EntityKeyInformation>();

			uow.QueueInsert(info, null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingInsertWithNullInfoThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.QueueInsert(null, new object());
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingUpdateWithNullEntityThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);
			var info = Isolate.Fake.Instance<EntityKeyInformation>();

			uow.QueueUpdate(info, null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueuingUpdateWithNullInfoThrowsException()
		{
			var uow = Isolate.Fake.Instance<ContextGenericUnitOfWork>(Members.CallOriginal, ConstructorWillBe.Ignored);

			uow.QueueUpdate(null, new object());
		}

		[TestMethod]
		public void SavingChangesSavesToContext()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var uow = new ContextGenericUnitOfWork(ctx);

			uow.SaveChanges();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.SaveChanges());

			Isolate.CleanUp();
		}
	}
}
