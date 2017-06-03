using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm.Validation.Discovery;


namespace Nucleo.Orm.Validation
{
	public static class OrmValidator
	{
		private static IValidationRuleDiscoveryStrategy _discoveryStrategy = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the validation rule discovery strategy to use.
		/// </summary>
		public static IValidationRuleDiscoveryStrategy DiscoveryStrategy
		{
			get { return _discoveryStrategy; }
			set 
			{
				if (_discoveryStrategy == value)
					return;

				lock (typeof(OrmValidator))
				{
					if (_discoveryStrategy == value)
						return;

					_discoveryStrategy = value;
				}
			}
		}

		#endregion




		#region " Methods "

		/// <summary>
		/// Validates an entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="ruleType"></param>
		/// <returns></returns>
		public static ValidationResults Validate(object entity, ValidationRuleType ruleType)
		{
			var strategy = DiscoveryStrategy ?? new DefaultValidationRuleDiscoveryStrategy();

			var rules = strategy.FindValidationRules(entity, ruleType);
			var results = new ValidationResults(entity, ruleType);

			if (rules == null || rules.Count == 0)
				return results;

			foreach (var rule in rules)
				rule.Validate(results);

			return results;
		}

		#endregion
	}
}
