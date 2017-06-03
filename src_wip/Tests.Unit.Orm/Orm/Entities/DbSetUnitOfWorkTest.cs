using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class DbSetUnitOfWorkTest
	{
		protected class TestClass { }


		[TestMethod]
		public void CreatingWithDbSetWorksOK()
		{
			var context = Isolate.Fake.Instance<DbContext>();
			var set = Isolate.Fake.Instance<DbSet<TestClass>>();

			new DbSetEntityUnitOfWork<TestClass>(context, set);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void CreatingWithNullContextThrowsException()
		{
			var set = Isolate.Fake.Instance<DbSet<TestClass>>();

			new DbSetEntityUnitOfWork<TestClass>(null, set);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException)),
		Isolated
		]
		public void CreatingWithNullSetThrowsException()
		{
			var context = Isolate.Fake.Instance<DbContext>();

			new DbSetEntityUnitOfWork<TestClass>(context, null);
		}
	}
}
