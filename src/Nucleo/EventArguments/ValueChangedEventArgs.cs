using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventArguments
{
	public class ValueChangedEventArgs
	{
		private object _newValue = null;
		private object _oldValue = null;



		#region " Properties "

		public object NewValue
		{
			get { return _newValue; }
		}

		public object OldValue
		{
			get { return _oldValue; }
		}

		#endregion



		#region " Constructors "

		public ValueChangedEventArgs(object oldValue, object newValue)
		{
			_oldValue = oldValue;
			_newValue = newValue;
		}

		#endregion
	}
	
	public class ValueChangedEventArgs<T>
	{
		private T _newValue = default(T);
		private T _oldValue = default(T);



		#region " Properties "

		public T NewValue
		{
			get { return _newValue; }
		}

		public T OldValue
		{
			get { return _oldValue; }
		}

		#endregion



		#region " Constructors "

		public ValueChangedEventArgs(T oldValue, T newValue)
		{
			_oldValue = oldValue;
			_newValue = newValue;
		}

		#endregion
	}


	public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);
	public delegate void ValueChangedEventHandler<T>(object sender, ValueChangedEventArgs<T> e);
}
