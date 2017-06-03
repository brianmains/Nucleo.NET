using System;
using System.Collections.Generic;

using Nucleo.Security;


namespace Nucleo.Services
{
	public interface IUserSecurityService : IService
	{
		#region " Methods "

		/// <summary>
		/// Gets the roles that belong to the user.
		/// </summary>
		/// <returns>The roles for the current user.</returns>
		RoleCollection GetRolesForUser();

		/// <summary>
		/// Gets the name of the user in the system.
		/// </summary>
		/// <returns>The name of the user.</returns>
		string GetUserName();

		/// <summary>
		/// Determines if the user is in the specified role.
		/// </summary>
		/// <param name="roleName">The name of the role.</param>
		/// <returns>Whether the user is in the role.</returns>
		bool IsInRole(string roleName);

		/// <summary>
		/// Gets whether the user is logged in.
		/// </summary>
		/// <returns>Whether the user is logged in.</returns>
		bool IsLoggedIn();

		#endregion
	}
}
