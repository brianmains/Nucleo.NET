using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Validation.Discovery
{
	[TestClass]
	public class DefaultValidationRuleDiscoveryStrategyTest
	{
		protected class TestClass : IValidationRuleTarget
		{
			public ValidationRuleCollection GetValidationRules(ValidationRuleType ruleType)
			{
				return new ValidationRuleCollection { Isolate.Fake.Instance<IValidationRule>() };
			}
		}


		[TestMethod]
		public void ValidatingNonValidatableEntityReturnsNull()
		{
			var strat = new DefaultValidationRuleDiscoveryStrategy();

			var rules = strat.FindValidationRules(new object(), ValidationRuleType.Create);

			Assert.IsNull(rules);
		}

		[TestMethod]
		public void ValidatingValidatableEntityReturnsResults()
		{
			var strat = new DefaultValidationRuleDiscoveryStrategy();

			var rules = strat.FindValidationRules(new TestClass(), ValidationRuleType.Create);

			Assert.AreEqual(1, rules.Count);
		}
	}
}
