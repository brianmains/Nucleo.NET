using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Modules.Discovery;
using Nucleo.Modules.Initialization;


namespace Nucleo.Modules
{
	/// <summary>
	/// Represents the factory for working with modules.
	/// </summary>
	public static class ModuleFactory
	{
		private static IModuleDiscoveryStrategy _discovery = null;
		private static IModuleInitializer _initializer = null;
		private static ModuleCollection _modules = new ModuleCollection();



		/// <summary>
		/// Gets or sets the discovery strategy of a module.
		/// </summary>
		public static IModuleDiscoveryStrategy Discovery
		{
			get { return _discovery; }
			set
			{
				if (_discovery == value)
					return;

				lock (typeof(IModuleDiscoveryStrategy))
				{
					if (_discovery == value)
						return;

					_discovery = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the initializer for the module.
		/// </summary>
		public static IModuleInitializer Initializer
		{
			get { return _initializer; }
			set
			{
				if (_initializer == value)
					return;

				lock (typeof(IModuleInitializer))
				{
					if (_initializer == value)
						return;

					_initializer = value;
				}
			}
		}

		/// <summary>
		/// Gets the collection of modules.
		/// </summary>
		public static ModuleCollection Modules
		{
			get 
			{
				if (_modules == null)
					_modules = new ModuleCollection();
				return _modules; 
			}
			private set
			{
				if (_modules == value)
					return;

				lock (typeof(ModuleCollection))
				{
					if (_modules == value)
						return;

					_modules = value;
				}
			}
		}



		/// <summary>
		/// Initializes the module framework and loads the modules into the framework.
		/// </summary>
		/// <param name="source"></param>
		public static void Initialize(IModuleDiscoverySource source)
		{
			var discovery = Discovery;
			if (discovery == null)
				return;

			var initializer = Initializer;

			var modules = discovery.Find(new ModuleDiscoveryOptions
			{
				Source = source
			});

			foreach (var module in modules)
			{
				if (initializer != null)
					initializer.Initialize(module);

				module.Initialize();
			}

			Modules = modules;
		}
	}
}
