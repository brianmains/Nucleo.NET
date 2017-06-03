using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Dependencies
{
	/// <summary>
	/// Represents an easy to use dictionary resolver that uses a dictionary of services to serve requests.
	/// </summary>
	public class DictionaryBasedDependencyResolver : IDependencyResolver
	{
		private Dictionary<Type, object> _services = null;



		#region " Constructors "

		/// <summary>
		/// Creates the resolver using a dictionary.
		/// </summary>
		/// <param name="services">The services mapping.</param>
		public DictionaryBasedDependencyResolver(Dictionary<Type, object> services)
		{
			if (services == null)
				throw new ArgumentNullException("services");

			_services = services;
		}

		#endregion



		/// <summary>
		/// Gets a dependency by the specified type.  Uses the explicit type to lookup in the registry.
		/// </summary>
		/// <param name="type">The type to lookup.</param>
		/// <returns>The service in an untyped form.</returns>
		public object GetDependency(Type type)
		{
			if (!_services.ContainsKey(type))
				return null;

			return _services[type];
		}

		/// <summary>
		/// Gets a dependency by the specified type.  Uses the generic type to lookup in the registry.
		/// </summary>
		/// <typeparam name="T">The type to lookup.</typeparam>
		/// <returns>The type.</returns>
		public T GetDependency<T>()
		{
			if (!_services.ContainsKey(typeof(T)))
				return default(T);

			return (T)_services[typeof(T)];
		}
	}
}
