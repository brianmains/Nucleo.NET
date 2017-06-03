using Nucleo.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Presentation.Context.Caching
{
	public interface IPresenterContextCache
	{
		/// <summary>
		/// Gets whether the cache can store cached items.
		/// </summary>
		bool CanCache { get; }

		/// <summary>
		/// Loads the current context, or null if not currently cached.
		/// </summary>
		/// <returns>The presenter context instance, or null if not cached.</returns>
		PresenterContext GetCurrentContext();

		bool UpdateCurrentContext(PresenterContext context);
	}
}
