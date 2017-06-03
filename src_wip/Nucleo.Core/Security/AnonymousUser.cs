using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Security
{
	public class AnonymousUser : IUser
	{
		public bool IsAuthenticated
		{
			get { return false; }
		}

		public string Name
		{
			get { return ""; }
		}



		public RoleCollection GetRoles()
		{
			return new RoleCollection();
		}

		public bool IsInRole(string roleName)
		{
			Guard.NotNullOrEmpty(roleName);

			return false;
		}
	}
}
