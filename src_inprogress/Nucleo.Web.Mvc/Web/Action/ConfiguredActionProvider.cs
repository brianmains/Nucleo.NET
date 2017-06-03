using System;


namespace Nucleo.Web.Action
{
	/// <summary>
	/// Represents a provider that serves up actions for routing, which makes it more configurable and changeable on the fly.
	/// </summary>
	public abstract class ConfiguredActionProvider
	{
		#region " Methods "

		/// <summary>
		/// Gets the route information based on the route name.
		/// </summary>
		/// <param name="routeName">The name of the route.</param>
		/// <returns>The route information.</returns>
		public abstract Route GetRoute(string routeName);

		/// <summary>
		/// Initializes the provider.
		/// </summary>
		public abstract void Initialize();

		#endregion
	}
}
