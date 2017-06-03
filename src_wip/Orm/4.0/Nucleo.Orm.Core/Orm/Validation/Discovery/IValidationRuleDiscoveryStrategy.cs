using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Validation.Discovery
{
	public interface IValidationRuleDiscoveryStrategy
	{
		/// <summary>
		/// Finds the validation rules associated with the unit of work and the given entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="ruleType"></param>
		/// <returns></returns>
		ValidationRuleCollection FindValidationRules(object entity, ValidationRuleType ruleType);
	}
}
