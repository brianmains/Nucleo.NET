using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Orm.Identification;


namespace Nucleo.Orm
{
	[TestClass]
	public class InMemoryUnitOfWorkTest
	{
		protected class TestClass 
		{
			[PrimaryRecordIdentifier]
			public int Key { get; set; }

			public string Name { get; set; }
		}



		[TestMethod]
		public void CreatingNewObjectByInterfaceWorksOK()
		{
			var uow = (new InMemoryUnitOfWork<TestClass>()) as IEntityUnitOfWork<TestClass>;

			var entity = uow.CreateNew();

			Assert.IsNotNull(entity);
		}

		[TestMethod]
		public void CreatingNewObjectWorksOK()
		{
			var uow = new InMemoryUnitOfWork<TestClass>();

			var entity = uow.CreateNew();

			Assert.IsNotNull(entity);
		}

        [
        TestMethod,
        ExpectedException(typeof(ArgumentNullException))
        ]
        public void CtorWithNullDataThrowsException()
        {
            new InMemoryUnitOfWork<TestClass>(default(IEnumerable<TestClass>));
        }

        [
        TestMethod,
        ExpectedException(typeof(ArgumentNullException))
        ]
        public void CtorWithNullData2ThrowsException()
        {
            new InMemoryUnitOfWork<TestClass>(default(IEnumerable<TestClass>), i => i.Key);
        }

        [
        TestMethod,
        ExpectedException(typeof(ArgumentNullException))
        ]
        public void CtorWithNullPointerThrowsException()
        {
            new InMemoryUnitOfWork<TestClass>(default(Func<TestClass, object>));
        }

        [
        TestMethod,
        ExpectedException(typeof(ArgumentNullException))
        ]
        public void CtorWithNullPointer2ThrowsException()
        {
            new InMemoryUnitOfWork<TestClass>(new TestClass[] { }, default(Func<TestClass, object>));
        }

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GetByNullIDLookupThrowsException()
		{
			new InMemoryUnitOfWork<TestClass>().Get(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void GetByNullIDLookupUsingInterfaceThrowsException()
		{
			((IEntityUnitOfWork<TestClass>)new InMemoryUnitOfWork<TestClass>()).Get(null);
		}

        [TestMethod]
        public void GettingObjectByKeySelectorGetsCorrectObject()
        {
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                }, i => i.Key);

            var entity = uow.Get(2);

            Assert.IsNotNull(entity);
            Assert.AreEqual("Second", entity.Name);
        }

		[TestMethod]
		public void GettingObjectByIDReturnsCorrectObject()
		{
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });
			
			var entity = uow.Get(2);

			Assert.IsNotNull(entity);
			Assert.AreEqual("Second", entity.Name);
		}

		[TestMethod]
		public void QueuingDeleteAddsToChangeList()
		{
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });

			uow.QueueDelete(uow.Get(1));

			Assert.AreEqual(3, uow.ItemCount);
            Assert.AreEqual(1, uow.ChangeCount);
		}

		[
		TestMethod,
		ExpectedException(typeof(InvalidCastException))
		]
		public void QueueingInvalidDeleteThrowsException()
		{
			((IEntityUnitOfWork)new InMemoryUnitOfWork<TestClass>()).QueueDelete(new object());
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueueingNullDeleteThrowsException()
		{
			new InMemoryUnitOfWork<TestClass>().QueueDelete(null);
		}

        [TestMethod]
        public void QueuingInsertAddsToChangeList()
        {
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });

            uow.QueueInsert(new TestClass { Key = 4, Name = "Fourth" });

            Assert.AreEqual(3, uow.ItemCount);
            Assert.AreEqual(1, uow.ChangeCount);
        }

		[
		TestMethod,
		ExpectedException(typeof(InvalidCastException))
		]
		public void QueueingInvalidInsertThrowsException()
		{
			((IEntityUnitOfWork)new InMemoryUnitOfWork<TestClass>()).QueueInsert(new object());
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueueingNullInsertThrowsException()
		{
			new InMemoryUnitOfWork<TestClass>().QueueInsert(null);
		}

        [TestMethod]
        public void QueuingUpdateAddsToChangeList()
        {
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });

            var item = uow.Get(1);
            item.Name = "1";

            uow.QueueUpdate(item);

            Assert.AreEqual(3, uow.ItemCount);
            Assert.AreEqual(1, uow.ChangeCount);
        }

		[
		TestMethod,
		ExpectedException(typeof(InvalidCastException))
		]
		public void QueueingInvalidUpdateThrowsException()
		{
			((IEntityUnitOfWork)new InMemoryUnitOfWork<TestClass>()).QueueUpdate(new object());
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void QueueingNullUpdateThrowsException()
		{
			new InMemoryUnitOfWork<TestClass>().QueueUpdate(null);
		}

        [TestMethod]
        public void SavingDeletePushesChange()
        {
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });

            uow.QueueDelete(uow.Get(1));
            uow.SaveChanges();

            Assert.AreEqual(2, uow.ItemCount);
            Assert.AreEqual(0, uow.ChangeCount);
        }

        [TestMethod]
        public void SavingInsertPushesChange()
        {
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });

            uow.QueueInsert(new TestClass { Key = 4, Name = "Fourth" });
            uow.SaveChanges();

            Assert.AreEqual(4, uow.ItemCount);
            Assert.AreEqual(0, uow.ChangeCount);
        }

		[TestMethod]
		public void SavingNoChangesWhenNothingPushedDoesNothing()
		{
			var uow = new InMemoryUnitOfWork<TestClass>();

			uow.SaveChanges();
		}

        [TestMethod]
        public void SavingUpdatePushesChange()
        {
            var uow = new InMemoryUnitOfWork<TestClass>(
                new TestClass[]
                {
                    new TestClass { Key = 1, Name = "First" },
			        new TestClass { Key = 2, Name = "Second" },
			        new TestClass { Key = 3, Name = "Third" }
                });

            var item = uow.Get(1);
            item.Name = "New First";
            uow.QueueUpdate(item);

            uow.SaveChanges();

            Assert.AreEqual(3, uow.ItemCount);
            Assert.AreEqual(0, uow.ChangeCount);
            Assert.AreEqual("New First", uow.Get(1).Name);
        }
	}
}
