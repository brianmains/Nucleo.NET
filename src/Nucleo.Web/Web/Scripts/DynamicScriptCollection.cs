using System;

using Nucleo.Collections;


namespace Nucleo.Web.Scripts
{
	/// <summary>
	/// Represents a collection of dynamic scripts.
	/// </summary>
	public class DynamicScriptCollection : SimpleCollection<DynamicScript>
	{
		#region " Methods "

		/// <summary>
		/// Gets a script by its name.
		/// </summary>
		/// <param name="name">The name of the script.</param>
		/// <returns>The script.</returns>
		public DynamicScript GetByName(string name)
		{
			foreach (DynamicScript script in this)
			{
				if (string.Compare(script.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
					return script;
			}

			return null;
		}

		#endregion
	}
}
