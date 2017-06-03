using System;
using Nucleo.Collections;


namespace Nucleo.Windows.Actions
{
	public class EventActionCollection : SimpleCollection<EventAction>
	{
		/// <summary>
		/// Adds a range of event actions to the current list.
		/// </summary>
		/// <param name="collection">The collection to append.</param>
		public void AddRange(EventActionCollection collection)
		{
			foreach (EventAction action in collection)
				this.Add(action);
		}
	}
}
