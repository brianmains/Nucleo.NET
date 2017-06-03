using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public class IgnoreValue : IValue
	{
		#region " Methods "

		public object GetValue()
		{
			return null;
		}

		#endregion
	}
}
