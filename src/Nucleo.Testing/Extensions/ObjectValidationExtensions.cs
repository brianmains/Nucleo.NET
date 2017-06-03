using System;
using System.Reflection;


namespace System
{
	public static class ObjectValidationExtensions
	{
		#region " Methods "

		/// <summary>
		/// Checks to see if the object is an instance of a given type.
		/// </summary>
		/// <typeparam name="T">The type to check.</typeparam>
		/// <param name="value">The value to compare.</param>
		/// <returns>Whether the object is of the given type.</returns>
		public static bool IsInstanceOf<T>(this object value)
		{
			if (value is T)
				return true;
			if (value != null && value.GetType().IsAssignableFrom(typeof(T)))
				return true;

			return false;
		}

		public static bool ThrowsException<T>(this T value, Action<T> fn)
			where T: class
		{
			try
			{
				fn(value);
				return false;
			}
			catch
			{
				return true;
			}
		}

		public static bool ThrowsNoException<T>(this T value, Action<T> fn)
			where T : class
		{
			try
			{
				fn(value);
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion
	}
}
