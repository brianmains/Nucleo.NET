using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Routing
{
	/// <summary>
	/// Represents the routing engine.
	/// </summary>
	public interface IRoutingEngine
	{
		/// <summary>
		/// Determines whether the routing engine can support 
		/// </summary>
		/// <param name="routingSource">The source of the routing.</param>
		/// <returns>Whether the source matches.</returns>
		bool IsForSource(object routingSource);

		/// <summary>
		/// Navigates to the routing source.
		/// </summary>
		/// <param name="routingSource">The source of the routing.</param>
		void Navigate(object routingSource);
	}
}
