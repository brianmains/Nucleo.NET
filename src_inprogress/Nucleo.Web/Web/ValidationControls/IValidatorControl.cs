using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents a validator control's interface.
	/// </summary>
	public interface IValidatorControl
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the grouping information to group the validator into.
		/// </summary>
		string DefaultGroupName { get; set; }

		/// <summary>
		/// Gets or sets the text to display when it needs to identify something happened for a field.
		/// </summary>
		string Message { get; set; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Validates all of the validation rules and determines whether the validator data is OK.
		/// </summary>
		/// <returns>A summary of the validation.</returns>
		void Validate(ValidatorValidationResults results);

		#endregion
	}
}
