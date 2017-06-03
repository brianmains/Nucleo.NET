using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	/// <summary>
	/// Represents a role within a security system.
	/// </summary>
	public class Role
	{
		private string _name = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the role.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the role with the name.
		/// </summary>
		/// <param name="name">The name of the role.</param>
		public Role(string name)
		{
			_name = name;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Checks for role equality.
		/// </summary>
		/// <param name="obj">The other role.</param>
		/// <returns>Whether the objects are equal.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Role))
				return false;

			return (string.Compare(this.Name, ((Role)obj).Name, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		/// <summary>
		/// Gets the name's hash code.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		#endregion
	}
}
