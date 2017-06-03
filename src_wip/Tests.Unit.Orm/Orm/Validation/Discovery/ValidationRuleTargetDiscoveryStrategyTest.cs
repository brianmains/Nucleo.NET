using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Orm.Validation.Discovery
{
	[TestClass]
	public class ValidationRuleTargetDiscoveryStrategyTest
	{
		protected class TestRule1 : IValidationRule
		{
			public void Validate(ValidationResults results) { }
		}

		protected class TestRule2 : IValidationRule
		{
			public void Validate(ValidationResults results) { }
		}

		protected class TestClass : IValidationRuleTarget
		{

			public ValidationRuleCollection GetValidationRules(ValidationRuleType ruleType)
			{
				return new ValidationRuleCollection
				{
					new TestRule1(),
					new TestRule2()
				};
			}
		}



		[TestMethod]
		public void FindingInsertValidationRulesForEntityWorksOK()
		{
			var cls = new TestClass();
			var strategy = new DefaultValidationRuleDiscoveryStrategy();

			var rules = strategy.FindValidationRules(cls, ValidationRuleType.Create);

			Assert.AreEqual(2, rules.Count);
		}
	}
}
