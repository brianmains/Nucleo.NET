using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.EventArguments;


namespace Nucleo.State
{
	/// <summary>
	/// Represents the current execution state.
	/// </summary>
	public interface ICurrentExecutionState
	{
		#region " Events "

		/// <summary>
		/// Fires when one of the internal values changes.
		/// </summary>
		event StateValueChangedEventHandler ValueChanged;

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets value for a the key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>The returned value.</returns>
		StateValue Get(object key);

		/// <summary>
		/// Gets all of the keys/values collection from state.
		/// </summary>
		/// <returns>The collection of state values.</returns>
		StateValueCollection GetAll();

		/// <summary>
		/// Checks whether the key has an assigned value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>Checks whether the key has a registered value.</returns>
		bool HasValue(object key);

		/// <summary>
		/// Sets the value for a given state key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		void Set(StateValue value);

		#endregion
	}
}
