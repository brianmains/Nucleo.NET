using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents the identifier for the module.
	/// </summary>
	public class ModuleIdentifier
	{
		private string _name = null;



		#region " Properties "

		/// <summary>
		/// Checks for equality of module identifiers.
		/// </summary>
		/// <param name="x">The left identifier.</param>
		/// <param name="y">The right identifier.</param>
		/// <returns>Whether the module identifiers are equal.</returns>
		public static bool operator ==(ModuleIdentifier x, ModuleIdentifier y)
		{
			if (x.Equals(null) || y.Equals(null))
				return (x.Equals(y));
			else
				return string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase) == 0;
		}

		/// <summary>
		/// Checks for inequality of module identifiers.
		/// </summary>
		/// <param name="x">The left identifier.</param>
		/// <param name="y">The right identifier.</param>
		/// <returns>Whether the module identifiers are equal.</returns>
		public static bool operator !=(ModuleIdentifier x, ModuleIdentifier y)
		{
			if (x.Equals(null) || y.Equals(null))
				return !(x.Equals(y));
			else
				return string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase) != 0;
		}

		/// <summary>
		/// Gets the identifier name representation.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the module identifier with its name.
		/// </summary>
		/// <param name="name">The name of the identifier.</param>
		public ModuleIdentifier(string name)
		{
			_name = name;
		}

		#endregion
	}
}
