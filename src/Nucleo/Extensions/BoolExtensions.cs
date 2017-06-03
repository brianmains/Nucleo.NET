using System;


namespace System
{
	/// <summary>
	/// Additional extensions for the boolean type.
	/// </summary>
	public static class BoolExtensions
	{
		/// <summary>
		/// Gets a Yes/No value based on the boolean value.
		/// </summary>
		/// <param name="boolean">The value to convert.</param>
		/// <returns>A string format of the boolean.</returns>
#if NET20
		public static string ToYesNo(bool boolean)
#else
		public static string ToYesNo(this bool boolean)
#endif
		{
			return boolean ? "Yes" : "No";
		}

		/// <summary>
		/// Gets a Yes/No or null value based on the boolean value.
		/// </summary>
		/// <param name="boolean">The value to convert.</param>
		/// <returns>A string format of the boolean.</returns>
#if NET20
		public static string ToYesNo(bool? boolean)
#else
		public static string ToYesNo(this bool? boolean)
#endif
		{
			return ToYesNo(boolean, "Unknown");
		}

		/// <summary>
		/// Gets a Yes/No or null text value based on the boolean value.
		/// </summary>
		/// <param name="boolean">The value to convert.</param>
		/// <param name="nullText">The text to display when the value is null.</param>
		/// <returns>A string format of the boolean.</returns>
#if NET20
		public static string ToYesNo(bool? boolean, string nullText)
#else
		public static string ToYesNo(this bool? boolean, string nullText)
#endif
		{
			if (boolean.HasValue)
				return ToYesNo(boolean.Value);
			else
				return nullText;
		}
	}
}
