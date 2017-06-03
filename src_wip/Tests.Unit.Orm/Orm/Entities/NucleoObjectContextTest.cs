using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class NucleoObjectContextTest
	{
		[TestMethod]
		public void SavingChangesSavesOK()
		{
			var uow = Isolate.Fake.Instance<NucleoObjectContext>();

			((IUnitOfWork)uow).SaveChanges();

			Isolate.Verify.WasCalledWithAnyArguments(() => uow.SaveChanges());
		}
	}
}
