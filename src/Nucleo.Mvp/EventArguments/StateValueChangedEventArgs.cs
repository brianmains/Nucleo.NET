using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents a value being changed within the state component.
	/// </summary>
	public class StateValueChangedEventArgs : ValueChangedEventArgs
	{
		/// <summary>
		/// Gets the key.
		/// </summary>
		public object Key
		{
			get;
			private set;
		}

		/// <summary>
		/// Creates the event args with a given key, and the old/new value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="oldValue">The old value.</param>
		/// <param name="newValue">The new value.</param>
		public StateValueChangedEventArgs(object key, object oldValue, object newValue)
			: base(oldValue, newValue)
		{
			this.Key = key;
		}
	}

	public delegate void StateValueChangedEventHandler(object sender, StateValueChangedEventArgs e);
}
