using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Web.ValidationControls.Categories
{
	/// <summary>
	/// Represents the category for a validator.
	/// </summary>
	public interface IValidatorCategory
	{
		bool IsFailingCategory { get; }

		/// <summary>
		/// Gets the name of the category.
		/// </summary>
		string Name { get; }
	}
}
