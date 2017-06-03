using System;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class ObjectEntitySetTest
	{
		protected class TestClass { }



		[TestMethod]
		public void CreatingEntitySetCreatesOK()
		{
			var ctx = Isolate.Fake.Instance<ObjectSet<TestClass>>();
			var result = new ObjectEntitySet(ctx);

			Assert.AreEqual(ctx, result.ObjectSet);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingEntitySetThrowsWhenCtorParamNull()
		{
			new ObjectEntitySet(null);
		}
	}
}
