using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Core;
using Nucleo.Views;


namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents the factory for creating a presenter instance from a view.
	/// </summary>
	public static class PresenterFactory
	{
		#region " Methods "

		/// <summary>
		/// Creates the presenter from the view, using the specified discovery strategy/creator.
		/// </summary>
		/// <param name="view">The view to create a presenter for.</param>
		/// <returns>The presenter instance, or null if not found.</returns>
		/// <exception cref="NotFoundException">Thrown when a specified resource type could not be loaded because the type isn't found in any assembly.</exception>
		public static IPresenter Create(IView view)
		{
			var mgr = PresentationManager.Create(new PresenterOptions 
			{ 
				Creator = FrameworkSettings.Creator,
				DiscoveryStrategy = FrameworkSettings.DiscoveryStrategy,
				ContextCache = FrameworkSettings.ContextCache,
				Resolver = FrameworkSettings.Resolver
			});

			return mgr.Load(view);
		}

		#endregion
	}
}
