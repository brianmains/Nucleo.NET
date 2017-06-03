using System;


namespace Nucleo
{
	/// <summary>
	/// Represents a utility to convert text values to boolean.
	/// </summary>
	public static class BooleanUtility
	{
		/// <summary>
		/// Converts a text value to a boolean value.
		/// </summary>
		/// <param name="text">The text to convert.</param>
		/// <returns>The boolean value.</returns>
		public static bool ConvertToBoolean(string text)
		{
			return ConvertToBoolean(text, false);
		}

		/// <summary>
		/// Converts a text value to a boolean value.
		/// </summary>
		/// <param name="text">The text to convert.</param>
		/// <param name="defaultValue">The value that could be used as a default.</param>
		/// <returns>The boolean value.</returns>
		public static bool ConvertToBoolean(string text, bool defaultValue)
		{
			bool? value = ConvertToNullableBoolean(text);
			if (value.HasValue)
				return value.Value;
			else
				return defaultValue;
		}

		/// <summary>
		/// Converts a text value to a boolean value or null.
		/// </summary>
		/// <param name="text">The text to convert.</param>
		/// <returns>The boolean value or null.</returns>
		public static bool? ConvertToNullableBoolean(string text)
		{
			if (string.IsNullOrEmpty(text))
				return null;

			switch (text.ToLower())
			{
				case "yes":
					return true;
				case "y":
					return true;
				case "t":
					return true;
				case "true":
					return true;
				case "1":
					return true;
				case "-1":
					return true;
				case "no":
					return false;
				case "n":
					return false;
				case "false":
					return false;
				case "f":
					return false;
				case "0":
					return false;
				case "-0":
					return false;
				default:
					return null;
			}
		}
	}
}