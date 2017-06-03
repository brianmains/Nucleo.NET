using System;
using System.Collections.Generic;

using Nucleo.Security;


namespace Nucleo.Context.Services
{
	public class InMemoryUserSecurityService : IUserSecurityService
	{
		private bool _authenticated = false;
		private RoleCollection _roles = null;
		private string _userName = null;



		#region " Constructors "

		public InMemoryUserSecurityService(string userName, bool authenticated, RoleCollection roles)
		{
			_userName = userName;
			_authenticated = authenticated;
			_roles = roles;
		}

		#endregion



		#region " Methods "

		public RoleCollection GetRolesForUser()
		{
			return _roles;
		}

		public string GetUserName()
		{
			return _userName;
		}

		public bool IsInRole(string roleName)
		{
			return (_roles != null && _roles.Contains(new Role(roleName)));
		}

		public bool IsLoggedIn()
		{
			return _authenticated;
		}

		#endregion
	}
}
