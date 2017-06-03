using System;
using System.Collections.Generic;

using Nucleo.State;


namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents the state management service that uses the underlying <see cref="StateManager">StateManager framework</see>.
	/// </summary>
	/// <seealso cref="StateManager"/>
	public class StateManagementService : IStateManagementService
	{
		#region " Methods "

		/// <summary>
		/// Gets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="property">The property to get the value for.</param>
		/// <returns>The value of the state property.</returns>
		public object GetStateValue(StateUser user, StateProperty property)
		{
			StateManager manager = StateManager.GetInstance();
			return manager.GetStateValue(user, property);
		}

		/// <summary>
		/// Gets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="statePropertyName">The property name to get the value for.</param>
		/// <returns>The value of the state property.</returns>
		public object GetStateValue(StateUser user, string statePropertyName)
		{
			StateManager manager = StateManager.GetInstance();
			return manager.GetStateValue(user, statePropertyName);
		}

		/// <summary>
		/// Sets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="property">The property to get the value for.</param>
		/// <param name="value">The value to set.</param>
		public void SetStateValue(StateUser user, StateProperty property, object value)
		{
			StateManager manager = StateManager.GetInstance();
			manager.SetStateValue(user, property, value);
		}

		/// <summary>
		/// Sets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="statePropertyName">The property name to get the value for.</param>
		/// <param name="value">The value to set.</param>
		public void SetStateValue(StateUser user, string statePropertyName, object value)
		{
			StateManager manager = StateManager.GetInstance();
			manager.SetStateValue(user, statePropertyName, value);
		}

		#endregion
	}
}
