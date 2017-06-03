using System;

using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	/// <summary>
	/// Represents the options used to discover presenters.
	/// </summary>
	public class PresenterDiscoveryOptions
	{
		/// <summary>
		/// Gets or sets the view used to discover presenters.
		/// </summary>
		public IView View
		{
			get;
			set;
		}
	}
}
