using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class ObjectSetUnitOfWorkTest
	{
		#region " Test Classes "

		public class TestEntity { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void AttachingAnEntityWorksOK()
		{
			//Arrange
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var entity = new TestEntity();

			//Act
			var uow = new ObjectSetUnitOfWork<TestEntity>(os);
			uow.Attach(entity);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => os.Attach(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void DetachingAnEntityWorksOK()
		{
			//Arrange
			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			var entity = new TestEntity();

			//Act
			var uow = new ObjectSetUnitOfWork<TestEntity>(os);
			uow.Detach(entity);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => os.Detach(null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingEntitySetNameWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			Isolate.WhenCalled(() => ctx.DefaultContainerName).WillReturn("CTX");

			var os = Isolate.Fake.Instance<ObjectSet<TestEntity>>();
			Isolate.WhenCalled(() => os.Context).WillReturn(ctx);
			Isolate.WhenCalled(() => os.EntitySet.Name).WillReturn("TestEntities");

			//Act
			var uow = new ObjectSetUnitOfWork<TestEntity>(os);
			var name = uow.EntitySetName;

			//Assert
			Assert.AreEqual("CTX.TestEntities", name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingEntitySetWithNullCoreResultThrowsException()
		{

			ExceptionTester.CheckException(true, (s) => { new ObjectSetUnitOfWork<TestEntity>(null); });
		}

		[TestMethod]
		public void CreatingEntitySetWorksOK()
		{
			//Arrange
			var fake = Isolate.Fake.Instance<ObjectSet<TestEntity>>();

			//Act
			var set = new ObjectSetUnitOfWork<TestEntity>(fake);	

			//Assert


			Isolate.CleanUp();
		}

		#endregion
	}
}
