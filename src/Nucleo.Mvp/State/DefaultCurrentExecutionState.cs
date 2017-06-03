using System;
using System.Collections.Generic;

using Nucleo.EventArguments;
using Nucleo.Collections;


namespace Nucleo.State
{
	/// <summary>
	/// The current execution state that uses an inline dictionary.
	/// </summary>
	public class DefaultCurrentExecutionState : ICurrentExecutionState
	{
		private Dictionary<object, object> _items = null;


		#region " Events "

		/// <summary>
		/// Fires when one of the internal values changes.
		/// </summary>
		public event StateValueChangedEventHandler ValueChanged;

		#endregion



		#region " Properties "

		private  Dictionary<object, object> Items
		{
			get
			{
				if (_items == null)
					_items = new Dictionary<object, object>();

				return _items;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets value for a the key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>The returned value.</returns>
		public StateValue Get(object key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			if (Items.ContainsKey(key))
				return new StateValue { Key = key, Value = Items[key] };
			else
				return null;
		}

		/// <summary>
		/// Gets all of the keys/values collection from state.
		/// </summary>
		/// <returns>The collection of state values.</returns>
		public StateValueCollection GetAll()
		{
			StateValueCollection list = new StateValueCollection();
			foreach (object key in this.Items.Keys)
				list.Add(new StateValue { Key = key, Value = this.Items[key] });

			return list;
		}

		/// <summary>
		/// Checks whether the key has an assigned value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>Checks whether the key has a registered value.</returns>
		public bool HasValue(object key)
		{
			return Items.ContainsKey(key);
		}

		/// <summary>
		/// Fires the <see cref="ValueChanged"/> event.
		/// </summary>
		/// <param name="e">The event args about the state value change.</param>
		protected virtual void OnValueChanged(StateValueChangedEventArgs e)
		{
			if (ValueChanged != null)
				ValueChanged(this, e);
		}

		/// <summary>
		/// Sets the value for a given state key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void Set(StateValue value)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			if (value.Key == null)
				throw new ArgumentNullException("value.Key");

			if (!Items.ContainsKey(value.Key))
			{
				Items.Add(value.Key, value.Value);
			}
			else
			{
				object oldValue = Items[value.Key];
				if (!Object.Equals(oldValue, value.Value))
				{
					Items[value.Key] = value.Value;
					this.OnValueChanged(new StateValueChangedEventArgs(value.Key, oldValue, value.Value));
				}
			}
		}

		#endregion
	}
}
