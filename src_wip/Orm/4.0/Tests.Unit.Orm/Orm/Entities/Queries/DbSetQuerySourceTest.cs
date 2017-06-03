using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Entities.Queries
{
	[TestClass]
	public class DbSetQuerySourceTest
	{
		protected class TestClass { }



		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullDbContextThrowsException()
		{
			var set = Isolate.Fake.Instance<DbSet<TestClass>>();

			new DbSetQuerySource<TestClass>(null, set);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullDbSetThrowsException()
		{
			var context = Isolate.Fake.Instance<DbContext>();

			new DbSetQuerySource<TestClass>(context, null);
		}

		[TestMethod]
		public void CreatingWorksOK()
		{
			var context = Isolate.Fake.Instance<DbContext>();
			var set = Isolate.Fake.Instance<DbSet<TestClass>>();

			new DbSetQuerySource<TestClass>(context, set);
		}
	}
}
