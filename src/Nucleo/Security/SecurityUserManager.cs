using System;
using Nucleo.Registration;


namespace Nucleo.Security
{
	public static class SecurityUserManager
	{
		private static SecurityUserManagementProvider _defaultProvider = null;
		private static SecurityUserManagementProviderCollection _providers = null;
		private static bool _initialized = false;



		#region " Properties "

		public static SecurityUserManagementProvider DefaultProvider
		{
			get
			{
				Initialize();
				return _defaultProvider;
			}
		}

		public static SecurityUserManagementProviderCollection Providers
		{
			get
			{
				Initialize();
				return _providers;
			}
		}

		#endregion



		#region " Methods "

		public static bool ChangeRolePermission(SecurityUser user, SecurityRole role, AuthorizationType authorization)
		{
			return DefaultProvider.ChangeRolePermission(user, role, authorization);
		}

		public static bool ChangeRulePermission(SecurityUser user, SecurityRule rule, AuthorizationType authorization)
		{
			return DefaultProvider.ChangeRulePermission(user, rule, authorization);
		}

		public static bool ChangeSubsystemPermission(SecurityUser user, SecuritySubsystem subsystem, AuthorizationType authorization)
		{
			return DefaultProvider.ChangeSubsystemPermission(user, subsystem, authorization);
		}

		public static bool ContainsUser(string userName)
		{
			return DefaultProvider.ContainsUser(userName);
		}

		public static SecurityUser CreateUser(string userName, string fullName, string email, out SecurityObjectCreationStatusType status)
		{
			return CreateUser(userName, null, fullName, email, null, out status);
		}

		public static SecurityUser CreateUser(string userName, string fullName, string email, string phoneNumber, out SecurityObjectCreationStatusType status)
		{
			return CreateUser(userName, null, fullName, email, phoneNumber, out status);
		}

		public static SecurityUser CreateUser(string userName, SecurityPassword password, string fullName, string email, out SecurityObjectCreationStatusType status)
		{
			return CreateUser(userName, password, fullName, email, null, out status);
		}

		public static SecurityUser CreateUser(string userName, SecurityPassword password, string fullName, string email, string phoneNumber, out SecurityObjectCreationStatusType status)
		{
			if (string.IsNullOrEmpty(userName))
				throw new ArgumentNullException("userName");
			if (password.Status != PasswordStatusType.Ok)
			{
				status = SecurityObjectCreationStatusType.Error;
				return null;
			}
			else
				return DefaultProvider.CreateUser(userName, fullName, email, phoneNumber, password, out status);
		}

		public static bool DeleteUser(SecurityUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			DefaultProvider.DeleteUserAssociations(user);
			return DefaultProvider.DeleteUser(user);
		}

		public static SecurityUser GetUser(string userName)
		{
			return DefaultProvider.GetUser(userName);
		}

		public static int GetUserCount()
		{
			return DefaultProvider.GetUserCount();
		}

		private static void Initialize()
		{
			if (_initialized)
				return;


		}

		public static void LockoutUser(SecurityUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			DefaultProvider.LockoutUser(user);
			user.IsLockedOut = true;
		}

		public static void SaveChangesForUser(SecurityUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			DefaultProvider.SaveUserChanges(user);
		}

		public static void UnlockUser(SecurityUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			DefaultProvider.UnlockUser(user);
			user.IsLockedOut = false;
		}

		#endregion
	}
}
