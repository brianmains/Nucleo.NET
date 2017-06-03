using System;
using System.Security.Principal;


namespace Nucleo.Security
{
	public class SecurityUser : IIdentity
	{
		private SecurityPassword _password = null;
		private SecurityRoleCollection _roles = null;
		private SecurityRuleCollection _rules = null;
		private SecuritySubsystemCollection _subsystems = null;

		private string _email;
		private string _fullName;
		private Guid _id;
		private bool _isAuthenticated;
		private bool _isLockedOut;
		private string _name;
		private string _phoneNumber;



		#region " Properties "

		public string AuthenticationType
		{
			get { return "Nucleo Security Layer"; }
		}

		public string Email
		{
			get { return _email; }
		}

		public string FullName
		{
			get { return _fullName; }
		}

		internal Guid ID
		{
			get { return _id; }
		}

		public bool IsAuthenticated
		{
			get { return _isAuthenticated; }
		}

		public bool IsLockedOut
		{
			get { return _isLockedOut; }
			internal set { _isLockedOut = value; }
		}

		public string Name
		{
			get { return _name; }
		}

		public SecurityPassword Password
		{
			get { return _password; }
		}

		public string PhoneNumber
		{
			get { return _phoneNumber; }
		}

		public SecurityRoleCollection Roles
		{
			get
			{
				if (_roles == null)
					_roles = new SecurityRoleCollection();
				return _roles;
			}
		}

		public SecurityRuleCollection Rules
		{
			get
			{
				if (_rules == null)
					_rules = new SecurityRuleCollection();
				return _rules;
			}
		}

		public SecuritySubsystemCollection Subsystems
		{
			get
			{
				if (_subsystems == null)
					_subsystems = new SecuritySubsystemCollection();
				return _subsystems;
			}
		}

		#endregion



		#region " Constructors "

		internal SecurityUser(Guid id, string name, string fullName, string email, string phoneNumber, SecurityPassword password)
		{
			_name = name;
			_fullName = fullName;
			_email = email;
			_phoneNumber = phoneNumber;
			_password = password;
		}

		#endregion
	}
}
