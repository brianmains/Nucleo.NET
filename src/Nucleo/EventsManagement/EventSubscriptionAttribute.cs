using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents an event subscription definition using attributes.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public abstract class EventSubscriptionAttribute : Attribute, IEventSubscription
	{
		#region " Properties "

		/// <summary>
		/// Gets the name of the event.
		/// </summary>
		public abstract string Name { get; }

		public abstract Type SourceType { get; }

		#endregion
	}
}
