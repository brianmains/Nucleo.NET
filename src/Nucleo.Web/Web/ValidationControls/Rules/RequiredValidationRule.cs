using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

using Nucleo.Web.ValidationControls.Categories;
using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls.Rules
{
	/// <summary>
	/// Represents that the rule is required.
	/// </summary>
	public class RequiredValidationRule : BaseValidationRule, IClientValidationRule
	{
		#region " Properties "

		/// <summary>
		/// Gets the name of the validation rule.
		/// </summary>
		public override string Name
		{
			get { return "Required"; }
		}

		#endregion



		#region " Methods "

		public string GetRegistrationScript()
		{
			return "n$.ValidationRules.Required({ message: '" + this.Message + "' });";
		}

		/// <summary>
		/// Validates the values requested to see if they are required.
		/// </summary>
		/// <param name="options">The options used to validate.</param>
		/// <returns>The validation results, of whether its valid.</returns>
		public override ValidatorValidationResultItem Validate(ValidationRuleOptions options)
		{
			for (int i = 0, len = options.Values.Length; i < len; i++)
			{
				object value = options.Values[i];
				if (value is bool)
					continue;

				if (value == null || DBNull.Value.Equals(value))
					return new ValidatorValidationResultItem(new ErrorValidatorCategory(), this.Message);
				if (value is string && string.Empty == (string)value)
					return new ValidatorValidationResultItem(new ErrorValidatorCategory(), this.Message);
			}

			return null;
		}

		#endregion
	}
}
