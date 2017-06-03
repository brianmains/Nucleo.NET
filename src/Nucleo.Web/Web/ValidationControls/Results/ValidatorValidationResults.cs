using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ValidationControls.Categories;


namespace Nucleo.Web.ValidationControls.Results
{
	/// <summary>
	/// Represents the results of a single validator's validation.
	/// </summary>
	public class ValidatorValidationResults
	{
		private bool _failed = false;
		private ValidatorValidationResultItemCollection _items = null;
		



		#region " Properties "

		/// <summary>
		/// Gets whether the results are valid.
		/// </summary>
		public bool Failed
		{
			get { return _failed; }
		}

		private ValidatorValidationResultItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new ValidatorValidationResultItemCollection();

				return _items;
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the validator results with all of the necessary properties.
		/// </summary>
		public ValidatorValidationResults()
		{
			_failed = false;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a result to the colleciton of results.
		/// </summary>
		/// <param name="item">The result item to add.</param>
		public void AddItem(ValidatorValidationResultItem item)
		{
			this.Items.Add(item);

			if (item.Category != null && item.Category.IsFailingCategory)
				_failed = true;
		}

		/// <summary>
		/// Gets the collection of items created during the validation process.
		/// </summary>
		/// <returns>The validation items.</returns>
		public ValidatorValidationResultItemCollection GetItems()
		{
			return this.Items;
		}

		#endregion
	}
}
