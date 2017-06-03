using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Validation
{
	[TestClass]
	public class EmptyValidationRuleTest
	{
		[TestMethod]
		public void ValidatingDoesNotLogToResult()
		{
			var rule = new EmptyValidationRule();
			var results = Isolate.Fake.Instance<ValidationResults>();

			rule.Validate(results);

			Isolate.Verify.WasNotCalled(() => results.AddMessage(null));
			Isolate.CleanUp();
		}
	}
}
