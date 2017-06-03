using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo
{
	public static class TypeLoaderExtensions
	{
		/// <summary>
		/// Creates the type with the given args.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="args">The constructor arguments.</param>
		public static object Create(this Type type, params object[] args)
		{
			return TypeLoader.Create(type, args);
		}
	}
}
