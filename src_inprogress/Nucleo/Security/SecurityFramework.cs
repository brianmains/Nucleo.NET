using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public static class SecurityFramework
	{
		private static SecurityRoleCollection _roles = null;
		private static SecurityRuleCollection _rules = null;
		private static SecuritySubsystemCollection _subsystems = null;
		private static object _lock = new object();



		#region " Properties "

		public static SecurityRoleCollection Roles
		{
			get
			{
				if (_roles == null)
				{
					lock (_roles)
					{
						if (_roles == null)
							_roles = SecurityRoleManager.GetRoles();
					}
				}

				return _roles;
			}
		}

		public static SecurityRuleCollection Rules
		{
			get
			{
				if (_rules == null)
				{
					lock (_rules)
					{
						if (_rules == null)
							_rules = SecurityRuleManager.GetRules();
					}
				}

				return _rules;
			}
		}

		public static SecuritySubsystemCollection Subsystems
		{
			get
			{
				if (_subsystems == null)
				{
					lock (_subsystems)
					{
						if (_subsystems == null)
							_subsystems = SecuritySubsystemManager.GetSubsystems();
					}
				}

				return _subsystems;
			}
		}

		#endregion 
	}
}
