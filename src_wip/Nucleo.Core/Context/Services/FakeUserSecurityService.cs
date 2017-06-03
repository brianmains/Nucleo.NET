using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Security;


namespace Nucleo.Context.Services
{
	public class FakeUserSecurityService : IUserSecurityService
	{
		public IUser CurrentUser { get; set; }



		#region " Methods "

		public RoleCollection GetRolesForUser()
		{
			return this.CurrentUser.GetRoles();
		}

		public string GetUserName()
		{
			return this.CurrentUser.Name;
		}

		public bool IsInRole(string roleName)
		{
			return this.CurrentUser.IsInRole(roleName);
		}

		public bool IsLoggedIn()
		{
			return this.CurrentUser.IsAuthenticated;
		}

		#endregion
	}
}
