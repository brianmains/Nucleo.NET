using System;
using Nucleo.Collections;
using Nucleo.Providers;


namespace Nucleo.Security
{
	public abstract class SecurityRuleManagementProvider : ProviderBase
	{
		protected SecurityRule CreateRuleObject(Guid id, string name, string description)
		{
			return new SecurityRule(id, name, description, false);
		}

		public abstract SecurityRule CreateRule(string ruleName, string description, out SecurityObjectCreationStatusType status);
		public abstract bool DeleteRule(SecurityRule rule);
		public abstract bool DeleteRuleAssociations(SecurityRule rule);
		protected internal abstract SecurityRuleCollection GetRules();

	}


	public class SecurityRuleManagementProviderCollection : ProviderCollection<SecurityRuleManagementProvider> { }
}
