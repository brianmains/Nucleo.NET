using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class DbContextHelperTest
	{
		protected class TestContext : DbContext
		{
			public TestContext(string cn)
				: base(cn) { }
		}


		[TestMethod]
		public void CreatingReturnsDbContext()
		{
			var ctx = Isolate.Fake.Instance<TestContext>();
			Isolate.Swap.NextInstance<TestContext>().With(ctx);

			var context = DbContextHelper.Create<TestContext>("ABC Connection", false);

			Assert.IsNotNull(context);
		}
	}
}
