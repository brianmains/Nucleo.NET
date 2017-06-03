using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

namespace Nucleo.Orm.Validation
{
	[TestClass]
	public class StaticValidationRuleTest
	{
		[TestMethod]
		public void SettingUpWorksOK()
		{
			var rule = new StaticValidationRule(true, "ABC");
			var results = Isolate.Fake.Instance<ValidationResults>();

			rule.Validate(results);

			Isolate.Verify.WasCalledWithAnyArguments(() => results.AddMessage(null));			
			Isolate.CleanUp();
		}
	}
}
