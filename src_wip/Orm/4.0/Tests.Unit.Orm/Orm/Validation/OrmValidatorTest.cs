using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Orm.Validation.Discovery;


namespace Nucleo.Orm.Validation
{
	[TestClass]
	public class OrmValidatorTest
	{
		protected class TestClass { }



		#region " Tests "

		[TestMethod]
		public void SettingDiscoveryStrategyStaticAssignsOK()
		{
			var strategy = Isolate.Fake.Instance<IValidationRuleDiscoveryStrategy>();

			Isolate.Fake.StaticMethods(typeof(OrmValidator));
			Isolate.WhenCalled(() => OrmValidator.DiscoveryStrategy = null).CallOriginal();

			OrmValidator.DiscoveryStrategy = strategy;

			Assert.AreEqual(strategy.GetType().Name, OrmValidator.DiscoveryStrategy.GetType().Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingSameDiscoveryStrategyStaticDoesntOverwrite()
		{
			var strategy = Isolate.Fake.Instance<IValidationRuleDiscoveryStrategy>();
			Isolate.Fake.StaticMethods(typeof(OrmValidator), Members.CallOriginal);

			OrmValidator.DiscoveryStrategy = strategy;
			OrmValidator.DiscoveryStrategy = strategy;

			Assert.AreEqual(strategy.GetType().Name, OrmValidator.DiscoveryStrategy.GetType().Name);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ValidatingEmptyRulesReturnsEmptyValidationResult()
		{
			var strategy = Isolate.Fake.Instance<IValidationRuleDiscoveryStrategy>();
			Isolate.WhenCalled(() => strategy.FindValidationRules(null, ValidationRuleType.Create))
				.WillReturn(new ValidationRuleCollection());

			Isolate.Fake.StaticMethods(typeof(OrmValidator), Members.CallOriginal);
			Isolate.WhenCalled(() => OrmValidator.DiscoveryStrategy).WillReturn(strategy);

			var results = OrmValidator.Validate(new TestClass(), ValidationRuleType.Create);

			Assert.AreEqual(true, results.IsValid);
			Assert.AreEqual(0, results.GetMessages().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ValidatingNoRulesReturnsEmptyValidationResult()
		{
			var strategy = Isolate.Fake.Instance<IValidationRuleDiscoveryStrategy>();
			Isolate.WhenCalled(() => strategy.FindValidationRules(null, ValidationRuleType.Create)).WillReturn(null);

			Isolate.Fake.StaticMethods(typeof(OrmValidator), Members.CallOriginal);
			Isolate.WhenCalled(() => OrmValidator.DiscoveryStrategy).WillReturn(strategy);

			var results = OrmValidator.Validate(new TestClass(), ValidationRuleType.Create);

			Assert.AreEqual(true, results.IsValid);
			Assert.AreEqual(0, results.GetMessages().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ValidatingWithRulesReturnsSuccessResult()
		{
			var strategy = Isolate.Fake.Instance<IValidationRuleDiscoveryStrategy>();
			Isolate.WhenCalled(() => strategy.FindValidationRules(null, ValidationRuleType.Create))
				.WillReturn(new ValidationRuleCollection
				{
						new StaticValidationRule(false, "Passed with warnings"),
						new EmptyValidationRule()
				});

			Isolate.Fake.StaticMethods(typeof(OrmValidator), Members.CallOriginal);
			Isolate.WhenCalled(() => OrmValidator.DiscoveryStrategy).WillReturn(strategy);
			
			var results = OrmValidator.Validate(new TestClass(), ValidationRuleType.Create);

			Assert.AreEqual(true, results.IsValid);
			Assert.AreEqual(1, results.GetMessages().Count);

			Isolate.CleanUp();
		}

		#endregion
	}
}
