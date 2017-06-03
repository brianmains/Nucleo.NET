using System;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents an event.
	/// </summary>
	public interface IEvent
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		string Name { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Raises the event.
		/// </summary>
		void Raise(object source);

		#endregion
	}
}
