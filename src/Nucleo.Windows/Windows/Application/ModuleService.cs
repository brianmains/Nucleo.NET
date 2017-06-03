using System;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.EventArguments;


namespace Nucleo.Windows.Application
{
	public class ModuleService
	{
		private IModule _activeModule = null;
		private Dictionary<Type, IModule> _modules = null;



		#region " Events "

		/// <summary>
		/// Triggered whenever the active module has been changed.
		/// </summary>
		public event ValueChangedEventHandler<IModule> ActiveModuleChanged;

		/// <summary>
		/// Triggered whenever a specific module has been updated in the repository.
		/// </summary>
		public event DataEventHandler<Type> ModuleUpdated;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the module that is active within the application (currently has immediate focus).
		/// </summary>
		public IModule ActiveModule
		{
			get { return _activeModule; }
			set
			{
				if (_activeModule != value)
				{
					IModule oldValue = _activeModule;
					_activeModule = oldValue;

					this.OnActiveModuleChanged(new ValueChangedEventArgs<IModule>(oldValue, _activeModule));
				}
			}
		}

		/// <summary>
		/// A collection of modules.
		/// </summary>
		protected internal Dictionary<Type, IModule> Modules
		{
			get
			{
				if (_modules == null)
					_modules = new Dictionary<Type, IModule>();
				return _modules;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Constructs an instance of the designated type.
		/// </summary>
		/// <typeparam name="T">The type to construct.</typeparam>
		/// <returns>A new instance of the designated type.</returns>
		private T ConstructObject<T>()
		{
			ConstructorInfo ctor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, System.Type.EmptyTypes, null);
			if (ctor != null)
				return (T)ctor.Invoke(new object[] { });
			else
				return default(T);
		}

		/// <summary>
		/// Gets an instance of the module if it contains it; otherwise, a null is returned.
		/// </summary>
		/// <typeparam name="T">The module's type to retrieve it.</typeparam>
		/// <returns>An instance of the module, or null if not found.</returns>
		public T GetModule<T>()
			where T : IModule
		{
			if (!this.Modules.ContainsKey(typeof(T)))
				return default(T);

			return (T)this.Modules[typeof(T)];
		}

		/// <summary>
		/// Raises the active module changed event with the old/new module values.
		/// </summary>
		/// <param name="e">The old and new modules, detailing the change.</param>
		protected virtual void OnActiveModuleChanged(ValueChangedEventArgs<IModule> e)
		{
			if (ActiveModuleChanged != null)
				ActiveModuleChanged(this, e);
		}

		/// <summary>
		/// Raises the module updated event with the new type details.
		/// </summary>
		/// <param name="e">The details regarding the updated module.</param>
		protected virtual void OnModuleUpdated(DataEventArgs<Type> e)
		{
			if (ModuleUpdated != null)
				ModuleUpdated(this, e);
		}

		/// <summary>
		/// Before using a module in the way this application uses it, the module must be registered.  A module must inherit from <see cref="IModule" /> and have an empty constructor.  Registering automatically creates the module through reflection.
		/// </summary>
		/// <typeparam name="T">The type to register; this type should be unique, as it will be constructed.</typeparam>
		public void RegisterModule<T>()
			where T:IModule
		{
			this.ValidateModuleType<T>();
			if (this.Modules.ContainsKey(typeof(T)))
				throw new ArgumentException("The type provided already exists in the repository");

			IModule module = this.ConstructObject<T>() as IModule;
			if (module == null)
				throw new NullReferenceException("The module was not successfully constructed.");

			this.Modules.Add(typeof(T), module);
			module.Initialize();
		}

		/// <summary>
		/// A module registered in the system can be unregistered, when shutting down the application.  By passing in the type, the type is used to find the module, then unregister it.
		/// </summary>
		/// <typeparam name="T">The type to unregister from the service.</typeparam>
		public void UnregisterModule<T>()
			where T : IModule
		{
			this.ValidateModuleType<T>();
			this.ValidateTypeKeyExists<T>();

			IModule module = this.Modules[typeof(T)];
			this.Modules.Remove(typeof(T));
			module.Shutdown();
		}

		/// <summary>
		/// Because modules may change values within a module, it may be necessary to broadcast an update to other portions of the application.  This method updates the reference and broadcasts that message.
		/// </summary>
		/// <typeparam name="T">The module type to update.</typeparam>
		/// <param name="module">The updated version of the module.</param>
		public void UpdateModule<T>(T module)
			where T : IModule
		{
			this.ValidateTypeKeyExists<T>();
			if (module == null)
				throw new ArgumentNullException("module");

			if (!module.Equals(this.Modules[typeof(T)]))
			{
				this.Modules[typeof(T)] = module;
				this.OnModuleUpdated(new DataEventArgs<Type>(typeof(T)));
			}
		}

		/// <summary>
		/// Validates that the module type implements are the necessary requirements.
		/// </summary>
		/// <typeparam name="T">The type to validate.</typeparam>
		private void ValidateModuleType<T>()
		{
			if (typeof(T) is IModule)
				throw new InvalidCastException("The module type cannot be supported, because it doesn't implement the IModule interface");
		}

		/// <summary>
		/// Validates the module type key to determine that it is contained in the module collection.
		/// </summary>
		/// <typeparam name="T">The type to determine whether it exists.</typeparam>
		private void ValidateTypeKeyExists<T>()
		{
			if (!this.Modules.ContainsKey(typeof(T)))
				throw new ArgumentException("The type provided doesn't exist in the repository");
		}

		#endregion
	}
}
