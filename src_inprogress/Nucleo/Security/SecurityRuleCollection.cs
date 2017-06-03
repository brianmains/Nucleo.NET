using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Security
{
	public class SecurityRuleCollection : BaseSecurityObjectCollection<SecurityRule>
	{
		public SecurityRule[] GetNonSystemDefinedRules()
		{
			return this.GetRange(14, this.Count - 1);
		}

		public SecurityRule[] GetSystemDefinedRules()
		{
			return this.GetRange(0, 13);
		}
	}
}
