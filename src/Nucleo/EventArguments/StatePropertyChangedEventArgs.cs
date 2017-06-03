using System;
using System.Collections.Generic;

using Nucleo.State;


namespace Nucleo.EventArguments
{
	public class StatePropertyChangedEventArgs
	{
		private StateProperty _property = null;
		private object _value = null;



		#region " Properties "

		public StateProperty Property
		{
			get { return _property; }
		}

		public object Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		public StatePropertyChangedEventArgs(StateProperty property, object value)
		{
			_property = property;
			_value = value;
		}

		#endregion
	}


	public delegate void StatePropertyChangedEventHandler(object sender, StatePropertyChangedEventArgs e);
}
