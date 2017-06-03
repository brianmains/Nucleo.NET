using System;
using Nucleo.Collections;
using Nucleo.Providers;


namespace Nucleo.Security
{
	public abstract class SecurityRoleManagementProvider : ProviderBase
	{
		protected SecurityRole CreateRoleObject(Guid id, string name, string description)
		{
			return new SecurityRole(id, name, description);
		}

		public abstract bool ChangeRulePermission(SecurityRole role, SecurityRule rule, AuthorizationType authorization);
		public abstract SecurityRole CreateRole(string roleName, string description, out SecurityObjectCreationStatusType status);
		public abstract bool DeleteRole(SecurityRole role);
		public abstract bool DeleteRoleAssociations(SecurityRole role);
		protected internal abstract SecurityRoleCollection GetRoles();
	}


	public class SecurityRoleManagementProviderCollection : ProviderCollection<SecurityRoleManagementProvider> { }
}
