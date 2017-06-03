using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Dependencies;
using Nucleo.Core.Options;
using Nucleo.Presentation.Context.Caching;
using Nucleo.Presentation.Creation;
using Nucleo.Presentation.Discovery;
using Nucleo.Presentation.Initialization;
using Nucleo.Views;
using Nucleo.Views.Initialization;
using Nucleo.Models.Cache;


namespace Nucleo.Core
{
	public static class FrameworkSettings
	{
		private static IPresenterContextCache _contextCache = null;
		private static IPresenterCreator _creator = null;
		private static IPresentationDiscoveryStrategy _discoveryStrategy = null;
		private static IDependencyResolver _resolver = null;
		private static IModelCache _modelCache = null;
		private static IPresenterInitializer _presentationInitializer = null;
		private static IViewInitializer _viewInitializer = null;
		private static bool _initialized = false;



		#region " Properties "

		/// <summary>
		/// Gets or sets the current cache for the presenter context.
		/// </summary>
		public static IPresenterContextCache ContextCache
		{
			get
			{
				Initialize();
				return _contextCache;
			}
			set
			{
				if (_contextCache == value)
					return;

				lock (typeof(IPresenterContextCache))
				{
					if (_contextCache == value)
						return;

					_contextCache = value;
					_initialized = true;
				}
			}
		}

		/// <summary>
		/// Gets or sets the creator of presenters.
		/// </summary>
		public static IPresenterCreator Creator
		{
			get
			{
				Initialize();
				return _creator;
			}
			set
			{
				if (_creator == value)
					return;

				lock (typeof(IPresenterCreator))
				{
					if (_creator == value)
						return;

					_creator = value;
					_initialized = true;
				}
			}
		}

		/// <summary>
		/// Gets or sets the discovery strategy.
		/// </summary>
		public static IPresentationDiscoveryStrategy DiscoveryStrategy
		{
			get
			{
				Initialize();
				return _discoveryStrategy;
			}
			set
			{
				if (_discoveryStrategy == value)
					return;

				lock (typeof(IPresentationDiscoveryStrategy))
				{
					if (_discoveryStrategy == value)
						return;

					_discoveryStrategy = value;
					_initialized = true;
				}
			}
		}

		/// <summary>
		/// Gets or sets the cache for the model; does not initially get initialized.
		/// </summary>
		public static IModelCache ModelCache
		{
			get
			{
				Initialize();
				return _modelCache;
			}
			set
			{
				if (_modelCache == value)
					return;

				lock (typeof(IModelCache))
				{
					if (_modelCache == value)
						return;

					_modelCache = value;
					_initialized = true;
				}
			}
		}

		public static IPresenterInitializer PresenterInitializer
		{
			get { return _presentationInitializer; }
			set
			{
				if (_presentationInitializer == value)
					return;

				lock (typeof(IPresenterInitializer))
				{
					if (_presentationInitializer == value)
						return;

					_presentationInitializer = value;
					_initialized = true;
				}
			}
		}

		/// <summary>
		/// Gets or sets the resolver.
		/// </summary>
		public static IDependencyResolver Resolver
		{
			get { return _resolver; }
			set
			{
				if (_resolver == value)
					return;

				lock (typeof(IDependencyResolver))
				{
					if (_resolver == value)
						return;

					_resolver = value;
					_initialized = true;
				}
			}
		}

		public static IViewInitializer ViewInitializer
		{
			get { return _viewInitializer; }
			set
			{
				if (_viewInitializer == value)
					return;

				lock (typeof(IViewInitializer))
				{
					if (_viewInitializer == value)
						return;

					_viewInitializer = value;
					_initialized = true;
				}
			}
		}

		#endregion



		#region " Methods "

		private static void Initialize()
		{
			if (_initialized)
				return;

			lock (typeof(FrameworkSettings))
			{
				_contextCache = null;
				_creator = new DefaultPresenterCreator();
				_discoveryStrategy = new DefaultPresentationDiscoveryStrategy();
				_resolver = null;

				_initialized = true;
			}
		}

		#endregion
	}
}
