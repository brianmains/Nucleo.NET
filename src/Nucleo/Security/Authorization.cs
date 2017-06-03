using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public class Authorization
	{
		private string _name = null;
		private RoleCollection _roles = null;
		private UserCollection _users = null;



		#region " Properties "

		public string Name
		{
			get { return _name; }
		}

		private RoleCollection Roles
		{
			get
			{
				if (_roles == null)
					_roles = new RoleCollection();
				return _roles;
			}
		}

		private UserCollection Users
		{
			get
			{
				if (_users == null)
					_users = new UserCollection();
				return _users;
			}
		}

		#endregion



		#region " Constructors "

		public Authorization(string name)
		{
			_name = name;
		}

		public Authorization(string name, UserCollection users, RoleCollection roles)
			: this(name)
		{
			_users = users;
			_roles = roles;
		}

		#endregion



		#region " Methods "

		public RoleCollection GetRoles()
		{
			return _roles;
		}

		public UserCollection GetUsers()
		{
			return _users;
		}

		#endregion
	}
}
