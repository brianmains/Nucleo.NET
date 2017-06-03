using System;
using System.Web.UI;

using Nucleo.Web.Core;
using Nucleo.Web.ValidationControls.Results;


namespace Nucleo.Web.ValidationControls.Rules
{
	/// <summary>
	/// Represents the base class for validation rules.
	/// </summary>
	public abstract class BaseValidationRule : BaseControl, IValidationRule
	{
		private string _message = null;
		private BaseValidator _validator = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		/// <summary>
		/// Gets the name of the validation rule.
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Gets the validator that the rule applies for.
		/// </summary>
		public BaseValidator Validator
		{
			get { return _validator; }
			internal set { _validator = value; }
		}

		#endregion




		#region " Methods "

		public override void RenderUI(BaseControlWriter writer)
		{
			
		}

		/// <summary>
		/// Validates the rule against the data, determining if its in a correct state.
		/// </summary>
		/// <param name="options">The options to validate.</param>
		/// <returns>Whether the rule validated successfully.</returns>
		public abstract ValidatorValidationResultItem Validate(ValidationRuleOptions options);

		#endregion
	}
}
