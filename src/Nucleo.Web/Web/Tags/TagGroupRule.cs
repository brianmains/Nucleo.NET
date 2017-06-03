using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags
{
	public abstract class TagGroupRule
	{
		#region " Methods "

		public abstract bool IsForTag(TagElement element, int index);

		#endregion
	}
}
