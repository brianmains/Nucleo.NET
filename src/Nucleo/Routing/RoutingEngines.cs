using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Routing
{
	/// <summary>
	/// Represents teh collection of routing engines for routing between objects.
	/// </summary>
	public class RoutingEngines
	{
		private RoutingEngineCollection _engines = null;


		#region " Properties "

		/// <summary>
		/// Gets the engines.
		/// </summary>
		public RoutingEngineCollection Engines
		{
			get
			{
				if (_engines == null)
					_engines = new RoutingEngineCollection();

				return _engines;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the given engine using the routing source.
		/// </summary>
		/// <param name="routingSource">The routing source object.</param>
		/// <returns>The routing engine.</returns>
		public IRoutingEngine GetEngine(object routingSource)
		{
			return this.Engines.FirstOrDefault(i => i.IsForSource(routingSource));
		}

		/// <summary>
		/// Navigates using the given routing source.
		/// </summary>
		/// <param name="routingSource">The routing source object.</param>
		public void Navigate(object routingSource)
		{
			var engine = this.GetEngine(routingSource);
			if (engine == null)
				return;

			engine.Navigate(routingSource);
		}
		
		#endregion
	}
}
