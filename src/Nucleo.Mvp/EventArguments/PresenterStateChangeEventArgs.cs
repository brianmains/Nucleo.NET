using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.EventArguments
{
	public class PresenterStateChangeEventArgs : EventArgs
	{
		private string _name = null;
		private object _value = null;




		#region " Properties "

		public string Name 
		{
			get { return _name; }
		}

		public object Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		public PresenterStateChangeEventArgs(string name, object value)
		{
			_name = name;
			_value = value;
		}

		#endregion
	}

	public delegate void PresenterStateEventHandler(object sender, PresenterStateChangeEventArgs e);
}
