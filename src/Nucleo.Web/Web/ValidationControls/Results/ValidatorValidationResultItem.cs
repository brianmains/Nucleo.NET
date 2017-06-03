using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ValidationControls.Categories;


namespace Nucleo.Web.ValidationControls.Results
{
	/// <summary>
	/// Represents an item logged within the current validation results.
	/// </summary>
	public class ValidatorValidationResultItem
	{
		private IValidatorCategory _category = null;
		private string _message = null;



		#region " Properties "

		/// <summary>
		/// Gets the category for the validator.
		/// </summary>
		public IValidatorCategory Category
		{
			get { return _category; }
		}

		/// <summary>
		/// Gets the message to display, which may or may not be an error message.
		/// </summary>
		public string Message
		{
			get { return _message; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the validator results with all of the necessary properties.
		/// </summary>
		/// <param name="category">The cateogry to group by.</param>
		/// <param name="message">The message.</param>
		public ValidatorValidationResultItem(IValidatorCategory category, string message)
		{
			_category = category;
			_message = message;
		}

		#endregion
	}
}
