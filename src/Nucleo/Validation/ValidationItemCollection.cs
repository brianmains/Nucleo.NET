using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Validation
{
	public class ValidationItemCollection : SimpleCollection<ValidationItem>
	{
		#region " Methods "

		public void AddRange(IEnumerable<ValidationItem> items)
		{
			foreach (ValidationItem item in items)
				this.Add(item);
		}

		/// <summary>
		/// Checks the list of items for errors.
		/// </summary>
		/// <returns>Whether there are any errors in the list.</returns>
		public bool ContainsError()
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (this[index].ValidationResult is ErrorValidationType)
					return true;
			}

			return false;
		}

		public ValidationItem GetByName(string name)
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (string.Compare(this[index].Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
					return this[index];
			}

			return null;
		}

		public ValidationItemCollection GetErrors()
		{
			ValidationItemCollection items = new ValidationItemCollection();

			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (this[index].ValidationResult is ErrorValidationType)
					items.Add(this[index]);
			}

			return items;
		}

		public ValidationItem GetFirstError()
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (this[index].ValidationResult is ErrorValidationType)
					return this[index];
			}

			return null;
		}

		#endregion
	}
}
