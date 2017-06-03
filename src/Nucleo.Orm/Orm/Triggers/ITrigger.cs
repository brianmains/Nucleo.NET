using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Triggers
{
	/// <summary>
	/// Represents a trigger that acts on a change of an object.
	/// </summary>
	public interface ITrigger
	{
		#region " Methods "

		/// <summary>
		/// Fires the trigger, modifying attributes of the specific object.
		/// </summary>
		/// <param name="obj">The object to fire the trigger for.</param>
		/// <param name="action">The type of action firing.</param>
		/// <returns>Whether the trigger processed the results successfully.</returns>
		bool Fire(object obj, TriggerAction action);

		/// <summary>
		/// Checks whether the trigger is meant to target a specific object.
		/// </summary>
		/// <param name="obj">The object to target.</param>
		/// <returns>Whether the trigger is for the object.</returns>
		bool IsForObject(object obj, TriggerAction action);

		#endregion
	}
}
