using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Exceptions;


namespace Nucleo
{
	/// <summary>
	/// Represents a guard class that guards against incorrect input.
	/// </summary>
	public static class Guard
	{
		#region " Methods "

		/// <summary>
		/// Ensures value is not null; otherwise, an exception is thrown.
		/// </summary>
		/// <param name="value">The value that's checked.</param>
		public static void NotNull(object value)
		{
			if (value == null)
				throw new ArgumentNullException("A value is required; value was null.");
		}

		/// <summary>
		/// Ensures value is not null, and returns a boolean with the result.
		/// </summary>
		/// <param name="value">The value that's checked.</param>
		public static bool NotNullSafe(object value)
		{
			if (value == null)
				return false;

			return true;
		}

		/// <summary>
		/// Ensures value is not null or empty; otherwise, an exception is thrown.
		/// </summary>
		/// <param name="value">The value that's checked.</param>
		public static void NotNullOrEmpty(string value)
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("A string is required; value was null or empty.");
		}

		/// <summary>
		/// Ensures value is not null or empty, and returns a boolean with the result.
		/// </summary>
		/// <param name="value">The value that's checked.</param>
		public static bool NotNullOrEmptySafe(string value)
		{
			if (string.IsNullOrEmpty(value))
				return false;

			return true;
		}

		#endregion
	}
}
