using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.DataClasses
{
	[TestClass]
	public class TableEntityUnitOfWorkTest
	{
		protected class TestClass { }



		[TestMethod]
		public void CreatingANewEntityCreatesOK()
		{
			var uow = Isolate.Fake.Instance<TableEntityUnitOfWork<TestClass>>(Members.CallOriginal, ConstructorWillBe.Ignored);

			Assert.IsNotNull(uow.CreateNew());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingUnitOfWorkAssignsOK()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			var uow = new TableEntityUnitOfWork<TestClass>(table);

			Assert.AreEqual(table, uow.Table);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuingDeleteCallsOnSubmit()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			var uow = new TableEntityUnitOfWork<TestClass>(table);
			var cls = new TestClass();

			uow.QueueDelete(cls);

			Isolate.Verify.WasCalledWithAnyArguments(() => table.DeleteOnSubmit(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuingInsertCallsOnSubmit()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			var uow = new TableEntityUnitOfWork<TestClass>(table);
			var cls = new TestClass();

			uow.QueueInsert(cls);

			Isolate.Verify.WasCalledWithAnyArguments(() => table.InsertOnSubmit(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuingUpdateWhenAttachedDoesNotAttach()
		{
			var cls = new TestClass();
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			Isolate.WhenCalled(() => table.GetOriginalEntityState(null)).WillReturn(cls);

			var uow = new TableEntityUnitOfWork<TestClass>(table);
			
			uow.QueueUpdate(cls);

			Isolate.Verify.WasNotCalled(() => table.Attach(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuingUpdateWhenNotAttachedAttachesItem()
		{
			var cls = new TestClass();
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			Isolate.WhenCalled(() => table.GetOriginalEntityState(null)).WillReturn(null);

			var uow = new TableEntityUnitOfWork<TestClass>(table);

			uow.QueueUpdate(cls);

			Isolate.Verify.WasCalledWithAnyArguments(() => table.Attach(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SavingChangesCallsOnContext()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			var uow = new TableEntityUnitOfWork<TestClass>(table);

			uow.SaveChanges();

			Isolate.Verify.WasCalledWithAnyArguments(() => table.Context.SubmitChanges());

			Isolate.CleanUp();
		}
	}
}
