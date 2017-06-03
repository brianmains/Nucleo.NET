using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Security
{
	/// <summary>
	/// Represents a user that's authenticated in the system.
	/// </summary>
	public class AuthenticatedUser : IUser
	{
		private RoleCollection _roles;



		/// <summary>
		/// Gets whether the user is authenticated.
		/// </summary>
		public bool IsAuthenticated
		{
			get { return true; }
		}

		/// <summary>
		/// Gets the name of the user.
		/// </summary>
		public string Name { get; private set; }



		/// <summary>
		/// Creates the authenticated user with a given name and user roles.
		/// </summary>
		/// <param name="userName">The name of the user.</param>
		/// <param name="roles">The roles collection.</param>
		public AuthenticatedUser(string userName, RoleCollection roles)
		{
			Guard.NotNullOrEmpty(userName);

			this.Name = userName;
			_roles = roles ?? new RoleCollection();
		}


		/// <summary>
		/// Gets the collection of roles.
		/// </summary>
		/// <returns>The collection of roles.</returns>
		public RoleCollection GetRoles()
		{
			return _roles;
		}

		/// <summary>
		/// Gets whether the user is in a given role.
		/// </summary>
		/// <param name="roleName">The name of the role.</param>
		/// <returns>Whether the user is in the given role.</returns>
		public bool IsInRole(string roleName)
		{
			Guard.NotNullOrEmpty(roleName);

			return (GetRoles().FirstOrDefault(i => string.Compare(i.Name, roleName, StringComparison.OrdinalIgnoreCase) == 0) != null);
		}
	}
}
