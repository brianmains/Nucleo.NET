using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq;
using TypeMock.ArrangeActAssert;

using Nucleo.Orm.DataClasses;


namespace Nucleo.Orm.DataClasses.Legacy
{
	[TestClass]
	public class TableUnitOfWorkTest
	{
		protected class TestClass
		{
			public int ID { get; set; }
			public string Name { get; set; }
		}


		[TestMethod]
		public void ContextIsRetrievedFromTable()
		{
			var ctx = Isolate.Fake.Instance<DataContext>();
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			Isolate.WhenCalled(() => table.Context).WillReturn(ctx);

			new TableUnitOfWork<TestClass>(table);

			Assert.AreEqual(ctx.GetType().Name, table.Context.GetType().Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWithTableWorksOK()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();

			new TableUnitOfWork<TestClass>(table);
		}
	}
}
