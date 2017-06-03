using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Validation.Discovery
{
	public interface IValidationRuleTarget
	{
		ValidationRuleCollection GetValidationRules(ValidationRuleType ruleType);
	}
}
