using System;


namespace Nucleo.EventsManagement.Listeners
{
	/// <summary>
	/// Represents a criteria listener.
	/// </summary>
	public interface IListenerCriteria
	{
		bool IsMatch(IListenerCriteria criteria);
	}
}
