using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.Collections;


namespace Nucleo.Web.ValidationControls
{
	public class ValidationResultsCollection : SimpleCollection<ValidationResults>
	{
		/// <summary>
		/// Finds the validation controls in a specific group.
		/// </summary>
		/// <param name="group">The name of the group.</param>
		/// <returns>The collection of validation controls.</returns>
		public IEnumerable<ValidationResults> FindByGroup(string group)
		{
			if (group == null)
				group = string.Empty;

			return this.Where(i => (i.DefaultGroupName ?? string.Empty) == group);
		}
	}
}
