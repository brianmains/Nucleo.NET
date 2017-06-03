using System;


namespace Nucleo
{
	/// <summary>
	/// Creates the type name for types.
	/// </summary>
	public static class TypeNameGenerator
	{
		#region " Methods "

		/// <summary>
		/// Gets the local type name, consisting of "type, assembly".
		/// </summary>
		/// <param name="type">The type to get the string for.</param>
		/// <returns>The type string.</returns>
		public static string GetLocalTypeName(Type type)
		{
			return type.FullName + "," + type.Assembly.FullName;
		}

		/// <summary>
		/// Gets the local type name, consisting of "type, assembly".
		/// </summary>
		/// <typeparam name="T">The type to get the string for.</typeparam>
		/// <returns>The type string.</returns>
		public static string GetLocalTypeName<T>()
		{
			return GetLocalTypeName(typeof(T));
		}

		#endregion
	}
}
