using System;
using System.Collections.Generic;

using Nucleo.State;


namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents the service that stores state managed values.
	/// </summary>
	public interface IStateManagementService : IService
	{
		#region " Methods "

		/// <summary>
		/// Gets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="property">The property to get the value for.</param>
		/// <returns>The value of the state property.</returns>
		object GetStateValue(StateUser user, StateProperty property);

		/// <summary>
		/// Gets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="statePropertyName">The property name to get the value for.</param>
		/// <returns>The value of the state property.</returns>
		object GetStateValue(StateUser user, string statePropertyName);

		/// <summary>
		/// Sets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="property">The property to get the value for.</param>
		/// <param name="value">The value to set.</param>
		void SetStateValue(StateUser user, StateProperty property, object value);

		/// <summary>
		/// Sets the state value.
		/// </summary>
		/// <param name="user">The information about the current user.</param>
		/// <param name="statePropertyName">The property name to get the value for.</param>
		/// <param name="value">The value to set.</param>
		void SetStateValue(StateUser user, string statePropertyName, object value);

		#endregion
	}
}
