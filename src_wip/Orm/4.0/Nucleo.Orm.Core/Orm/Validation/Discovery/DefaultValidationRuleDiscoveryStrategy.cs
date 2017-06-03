using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Validation.Discovery
{
	public class DefaultValidationRuleDiscoveryStrategy : IValidationRuleDiscoveryStrategy
	{
		public ValidationRuleCollection FindValidationRules(object entity, ValidationRuleType ruleType)
		{
			if (entity is IValidationRuleTarget)
				return ((IValidationRuleTarget)entity).GetValidationRules(ruleType);

			return null;
		}
	}
}
