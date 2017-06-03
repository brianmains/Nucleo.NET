using Nucleo.Presentation;
using Nucleo.Presentation.Context.Caching;
using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Dependencies;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;

namespace Nucleo.Presentation
{
	/// <summary>
	/// Represents the current options for the presenter.
	/// </summary>
	public class PresenterOptions
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the cache for the presenter context.
		/// </summary>
		public IPresenterContextCache ContextCache
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the creator that controls who creates the presentation options.
		/// </summary>
		public IPresenterCreator Creator
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the discovery strategy to use.
		/// </summary>
		public IPresentationDiscoveryStrategy DiscoveryStrategy
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the resolver that can serve up injected references.
		/// </summary>
		public IDependencyResolver Resolver
		{
			get;
			set;
		}

		#endregion
	}
}
