using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Security
{
	public interface IUser
	{
		bool IsAuthenticated { get; }

		string Name { get; }


		RoleCollection GetRoles();

		bool IsInRole(string roleName);
	}
}
