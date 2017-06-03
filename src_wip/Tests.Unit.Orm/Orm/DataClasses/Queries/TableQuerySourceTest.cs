using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Orm.DataClasses;


namespace Nucleo.Orm.DataClasses.Queries
{
	[TestClass]
	public class TableQuerySourceTest
	{
		protected class TestClass { }



		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullTableThrowsException()
		{
			new TableQuerySource<TestClass>(null);
		}

		[TestMethod]
		public void CreatingWithTableWorksOK()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();

			new TableQuerySource<TestClass>(table);
		}

		[TestMethod]
		public void GettingContainerFromContextWorksOK()
		{
			var table = Isolate.Fake.Instance<Table<TestClass>>();
			var context = Isolate.Fake.Instance<NucleoDataContext>();
			Isolate.WhenCalled(() => table.Context).WillReturn(context);

			var source = new TableQuerySource<TestClass>(table);

			Assert.AreEqual(context, source.Container);

			Isolate.CleanUp();
		}
	}
}
