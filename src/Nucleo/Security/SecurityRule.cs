using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public class SecurityRule : BaseSecurityObject
	{
		private bool _isSystemDefined;



		#region " Properties "

		public bool IsSystemDefined
		{
			get { return _isSystemDefined; }
		}

		#endregion



		#region " Constructors "

		internal SecurityRule(Guid id, string name, string description, bool isSystemDefined)
			: base(id, name, description)
		{
			_isSystemDefined = isSystemDefined;
		}

		#endregion
	}
}
