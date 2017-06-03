using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Dependencies
{
	/// <summary>
	/// Represents the resolver of dependencies.
	/// </summary>
	public interface IDependencyResolver
	{
		/// <summary>
		/// Gets the dependency mapped to the type.
		/// </summary>
		/// <param name="type">The type to resolve dependencies for.</param>
		/// <returns>The object tied to that dependency.</returns>
		object GetDependency(Type type);

		// <summary>
		/// Gets the dependency mapped to the type.
		/// </summary>
		/// <typeparam name="T">The type to resolve dependencies for.</typeparam>
		/// <returns>The object tied to that dependency.</returns>
		T GetDependency<T>();
	}
}
