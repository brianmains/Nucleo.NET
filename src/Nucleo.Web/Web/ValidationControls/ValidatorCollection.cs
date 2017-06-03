using System;
using System.Linq;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents the collection of validators.
	/// </summary>
	public class ValidatorCollection : SimpleCollection<IValidatorControl>
	{
		#region " Methods "
		
		/// <summary>
		/// Finds the validation controls in a specific group.
		/// </summary>
		/// <param name="group">The name of the group.</param>
		/// <returns>The collection of validation controls.</returns>
		public IEnumerable<IValidatorControl> FindByGroup(string group)
		{
			if (group == null)
				group = string.Empty;

			return this.Where(i => i.DefaultGroupName == group);
		}

		#endregion
	}
}
