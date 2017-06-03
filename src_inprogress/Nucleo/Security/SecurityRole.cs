using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public class SecurityRole : BaseSecurityObject
	{
		private SecurityRuleCollection _rules = null;



		#region " Properties "

		public SecurityRuleCollection Rules
		{
			get
			{
				if (_rules == null)
					_rules = new SecurityRuleCollection();
				return _rules;
			}
		}

		#endregion


		#region " Constructors "

		internal SecurityRole(Guid id, string name, string description) : base(id, name, description) { }

		#endregion
	}
}
