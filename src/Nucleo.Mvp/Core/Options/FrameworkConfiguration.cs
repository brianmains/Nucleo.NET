using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Dependencies;
using Nucleo.Presentation.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;


namespace Nucleo.Core.Options
{
	/// <summary>
	/// Used to return the core services for the framework in a DTO-like fashion.
	/// </summary>
	public class FrameworkConfiguration
	{
		#region " Methods "

		public IPresenterContextCache Cache { get; set; }

		public IPresenterCreator Creator { get; set; }

		public IPresentationDiscoveryStrategy DiscoveryStrategy { get; set; }

		public IDependencyResolver Resolver { get; set; }

		#endregion
	}
}
