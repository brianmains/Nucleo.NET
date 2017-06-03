using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public class DirectValue : IValue
	{
		private object _value = null;



		#region " Properties "

		public object Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		public DirectValue(object value)
		{
			_value = value;
		}

		#endregion



		#region " Methods "

		public object GetValue()
		{
			return this.Value;
		}

		#endregion
	}
}
