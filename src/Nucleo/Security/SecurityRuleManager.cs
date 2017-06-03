using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public static class SecurityRuleManager
	{
		private static SecurityRuleManagementProvider _defaultProvider = null;
		private static SecurityRuleManagementProviderCollection _providers = null;
		private static bool _initialized = false;



		#region " Properties "

		public static SecurityRuleManagementProvider DefaultProvider
		{
			get
			{
				Initialize();
				return _defaultProvider;
			}
		}

		public static SecurityRuleManagementProviderCollection Providers
		{
			get
			{
				Initialize();
				return _providers;
			}
		}

		#endregion



		#region " Methods "

		public static SecurityRule CreateRule(string ruleName, string description, out SecurityObjectCreationStatusType status)
		{
			if (string.IsNullOrEmpty(ruleName))
				throw new ArgumentNullException("ruleName");
			if (SecurityFramework.Rules.Contains(ruleName))
			{
				status = SecurityObjectCreationStatusType.Duplicate;
				return null;
			}

			SecurityRule rule = DefaultProvider.CreateRule(ruleName, description, out status);
			if (rule == null)
				throw new NullReferenceException();
			SecurityFramework.Rules.Add(rule);
			return rule;
		}

		public static bool DeleteRule(SecurityRule rule)
		{
			if (rule == null)
				throw new ArgumentNullException("rule");

			if (SecurityFramework.Rules.Contains(rule))
			{
				SecurityFramework.Rules.Remove(rule);
				DefaultProvider.DeleteRuleAssociations(rule);
				return DefaultProvider.DeleteRule(rule);
			}

			return false;
		}

		internal static SecurityRuleCollection GetRules()
		{
			SecurityRuleCollection rules = new SecurityRuleCollection();
			rules.Add(new SecurityRule(Guid.NewGuid(), "Create Users", "This rule determines whether users can create users in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Lock Users", "This rule determines whether the current user can lock out other users in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Edit Users", "This rule determines whether users can edit users in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Delete Users", "This rule determines whether users can delete users in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Create Roles", "This rule determines whether users can create roles in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Delete Roles", "This rule determines whether users can delete roles in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Create Rules", "This rule determines whether users can create rules in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Delete Rules", "This rule determines whether users can delete rules in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Create Subsystems", "This rule determines whether users can create subsystems in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Delete Subsystems", "This rule determines whether users can delete subsystems in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Administer Application", "This rule determines whether the current user can administer the application in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Authorize Roles", "This rule determines whether the current user can authorize roles in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Authorize Rules", "This rule determines whether the current user can authorize rules in the system", true));
			rules.Add(new SecurityRule(Guid.NewGuid(), "Authorize Subsystems", "This rule determines whether the current user can authorize subsystems in the system", true));
			rules.AddRange(DefaultProvider.GetRules());

			return rules;
		}

		private static void Initialize()
		{
			if (_initialized)
				return;
		}

		#endregion
	}
}
