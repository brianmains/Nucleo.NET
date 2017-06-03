using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls.Rules
{
	public interface IValidationRule
	{
		#region " Properties "

		string Message { get; set; }

		#endregion



		#region " Methods "

		ValidatorValidationResultItem Validate(ValidationRuleOptions options);

		#endregion
	}
}
