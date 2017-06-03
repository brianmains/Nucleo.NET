using System;


namespace Nucleo.Orm.Validation
{
	/// <summary>
	/// Represents a validation rule to validate data by.
	/// </summary>
	public interface IValidationRule
	{
		#region " Methods "

		/// <summary>
		/// Validates the business rule, adding any messages that occurred during validation to the validation result.
		/// </summary>
		/// <param name="results">The results of the validation.</param>
		void Validate(ValidationResults results);

		#endregion
	}
}
