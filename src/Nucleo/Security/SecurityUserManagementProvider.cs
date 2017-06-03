using System;
using Nucleo.Collections;
using Nucleo.Providers;

namespace Nucleo.Security
{
	public abstract class SecurityUserManagementProvider : ProviderBase
	{
		protected SecurityUser CreateUserObject(Guid id, string name, string fullName, string email,
			string phoneNumber, SecurityPassword password)
		{
			return new SecurityUser(id, name, fullName, email, phoneNumber, password);
		}

		public abstract bool ChangeRolePermission(SecurityUser user, SecurityRole role, AuthorizationType authorization);
		public abstract bool ChangeRulePermission(SecurityUser user, SecurityRule rule, AuthorizationType authorization);
		public abstract bool ChangeSubsystemPermission(SecurityUser user, SecuritySubsystem subsystem, AuthorizationType authorization);
		public abstract bool ContainsUser(string userName);
		public abstract SecurityUser CreateUser(string userName, string fullName, string email, string phoneNumber, SecurityPassword password, out SecurityObjectCreationStatusType status);
		public abstract bool DeleteUser(SecurityUser user);
		public abstract bool DeleteUserAssociations(SecurityUser user);
		public abstract SecurityUser GetUser(string userName);
		public abstract int GetUserCount();
		public abstract bool LockoutUser(SecurityUser user);
		public abstract void SaveUserChanges(SecurityUser user);
		public abstract bool UnlockUser(SecurityUser user);
	}


	public class SecurityUserManagementProviderCollection : ProviderCollection<SecurityUserManagementProvider> { }
}
