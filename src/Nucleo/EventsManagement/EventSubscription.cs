using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the key of an event that will take place.
	/// </summary>
	public class EventSubscription : IEventSubscription
	{
		private string _name = null;
		private Type _sourceType = null;


		#region " Properties "

		/// <summary>
		/// Gets the name of the event.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the source type of the event.
		/// </summary>
		public Type SourceType
		{
			get { return _sourceType; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event subscription.
		/// </summary>
		/// <param name="sourceType">The source of the event subscription.</param>
		/// <param name="name">The name of the event.</param>
		public EventSubscription(Type sourceType, string name)
		{
			_sourceType = sourceType;
			_name = name;
		}

		#endregion
	}
}
