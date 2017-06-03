using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public class SecuritySubsystem : BaseSecurityObject
	{
		#region " Constructors "

		internal SecuritySubsystem(Guid id, string name, string description)
			:base(id, name, description)  { }

		#endregion
	}
}
