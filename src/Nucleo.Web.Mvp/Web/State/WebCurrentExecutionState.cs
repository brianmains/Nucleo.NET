using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.EventArguments;
using Nucleo.State;


namespace Nucleo.Web.State
{
	/// <summary>
	/// The current execution state for the web environment.
	/// </summary>
	public class WebCurrentExecutionState : ICurrentExecutionState
	{
		private HttpContextBase _context = null;



		#region " Events "

		/// <summary>
		/// Fires when one of the internal values changes.
		/// </summary>
		public event StateValueChangedEventHandler ValueChanged;

		#endregion



		#region " Properties "

		private Dictionary<object, object> Items
		{
			get
			{
				var dict = _context.Items[typeof(WebCurrentExecutionState)] as Dictionary<object, object>;
				if (dict == null)
				{
					dict = new Dictionary<object,object>();
					_context.Items.Add(typeof(WebCurrentExecutionState), dict);
				}

				return dict;
			}
		}

		#endregion



		#region " Constructors "

		public WebCurrentExecutionState()
		{
			_context = new HttpContextWrapper(HttpContext.Current);	
		}

		public WebCurrentExecutionState(HttpContextBase context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			_context = context;
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
			var items = this.Items;

			if (items.ContainsKey(key))
				return new StateValue { Key = key, Value = items[key] };
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
			var items = this.Items;

			foreach (object key in items.Keys)
				list.Add(new StateValue { Key = key, Value = items[key] });

			return list;
		}

		/// <summary>
		/// Checks whether the key has an assigned value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>Checks whether the key has a registered value.</returns>
		public bool HasValue(object key)
		{
			return this.Items.ContainsKey(key);
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

			var items = this.Items;

			if (!items.ContainsKey(value.Key))
				items.Add(value.Key, value.Value);
			else
			{
				object oldValue = items[value.Key];
				if (!Object.Equals(oldValue, value.Value))
				{
					items[value.Key] = value.Value;
					this.OnValueChanged(new StateValueChangedEventArgs(value.Key, oldValue, value.Value));
				}
			}
		}

		#endregion
	}
}
