using System;


namespace Nucleo.EventsManagement.Listeners
{
	/// <summary>
	/// Represents listener criteria of any type.
	/// </summary>
	public class AnyListenerCriteria : IListenerCriteria
	{
		public bool IsMatch(IListenerCriteria criteria)
		{
			return true;
		}

		public override string ToString()
		{
			return "Any";
		}
	}
}
