using System;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	/// <summary>
	/// Represents a generic type registry.
	/// </summary>
	public class TypeRegistry
	{
		private Type _permittedType = null;
		private IDictionary<Type, object> _registry = null;



		#region " Properties "

		/// <summary>
		/// Gets the list of registered items.
		/// </summary>
		public int Count
		{
			get { return _registry.Count; }
		}

		/// <summary>
		/// Gets or sets the type that is permitted for registration.
		/// </summary>
		public Type PermittedType
		{
			get { return _permittedType; }
			set { _permittedType = value; }
		}

		private IDictionary<Type, object> Registry
		{
			get
			{
				if (_registry == null)
					_registry = new Dictionary<Type, object>();
				return _registry;
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the registry.
		/// </summary>
		public TypeRegistry() { }

		/// <summary>
		/// Creates the registry with the list of items.
		/// </summary>
		/// <param name="items">The list of items.</param>
		public TypeRegistry(IDictionary<Type, object> items)
		{
			_registry = items;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Copies from a source type registry.
		/// </summary>
		/// <param name="registry">The type registry to copy from.</param>
		public void CopyFrom(TypeRegistry registry)
		{
			foreach (Type key in registry.Registry.Keys)
			{
				if (this.Registry.ContainsKey(key))
					this.Registry[key] = registry.Registry[key];
				else
					this.Registry.Add(key, registry.Registry[key]);
			}
		}

		/// <summary>
		/// Gets the registration for a given type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The registered object.</returns>
		public object GetRegistration(Type type)
		{
			if (this.Registry.ContainsKey(type))
				return this.Registry[type];
			else
				return null;
		}

		/// <summary>
		/// Gets the registration for a given type.
		/// </summary>
		/// <typeparam name="TItem">The type.</typeparam>
		/// <returns>The registered object.</returns>
		public TItem GetRegistration<TItem>()
		{
			if (this.Registry.ContainsKey(typeof(TItem)))
				return (TItem)this.Registry[typeof(TItem)];
			else
				return default(TItem);
		}

		/// <summary>
		/// Registers an item of a given type.
		/// </summary>
		/// <typeparam name="TItem">The type to register.</typeparam>
		/// <param name="item">The item to register.</param>
		/// <returns>Whether it registered OK.</returns>
		public bool Register<TItem>(TItem item)
		{
			return this.Register(typeof(TItem), item);
		}

		/// <summary>
		/// Registers an item of a given type, and its associated item.
		/// </summary>
		/// <param name="type">The type of the object to register.</param>
		/// <param name="item">The item to register.</param>
		/// <returns>Whether it registered OK.</returns>
		public bool Register(Type type, object item)
		{
			if (!this.Registry.ContainsKey(type))
			{
				if (this._permittedType != null)
				{
					if (!_permittedType.IsAssignableFrom(type))
						return false;
				}

				this.Registry.Add(type, item);
				return true;
			}
			else
				return false;
		}

		#endregion
	}
}
