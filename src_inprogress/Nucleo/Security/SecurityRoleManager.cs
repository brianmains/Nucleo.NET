using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public static class SecurityRoleManager
	{
		private static SecurityRoleManagementProvider _defaultProvider = null;
		private static SecurityRoleManagementProviderCollection _providers = null;
		private static bool _initialized = false;



		#region " Properties "

		public static SecurityRoleManagementProvider DefaultProvider
		{
			get
			{
				Initialize();
				return _defaultProvider;
			}
		}

		public static SecurityRoleManagementProviderCollection Providers
		{
			get
			{
				Initialize();
				return _providers;
			}
		}

		#endregion



		#region " Methods "

		public static SecurityRole CreateRole(string roleName, string description, out SecurityObjectCreationStatusType status)
		{
			if (string.IsNullOrEmpty(roleName))
				throw new ArgumentNullException("roleName");
			if (SecurityFramework.Roles.Contains(roleName))
			{
				status = SecurityObjectCreationStatusType.Duplicate;
				return null;
			}

		
			SecurityRole role = DefaultProvider.CreateRole(roleName, description, out status);
			if (role == null)
				throw new NullReferenceException();
			SecurityFramework.Roles.Add(role);
			return role;
		}

		public static bool DeleteRole(SecurityRole role)
		{
			if (role == null)
				throw new ArgumentNullException("role");

			if (SecurityFramework.Roles.Contains(role))
			{
				SecurityFramework.Roles.Remove(role);
				DefaultProvider.DeleteRoleAssociations(role);
				return DefaultProvider.DeleteRole(role);
			}

			return false;
		}

		internal static SecurityRoleCollection GetRoles()
		{
			return DefaultProvider.GetRoles();
		}

		private static void Initialize()
		{
			if (_initialized)
				return;


		}

		#endregion
	}
}
