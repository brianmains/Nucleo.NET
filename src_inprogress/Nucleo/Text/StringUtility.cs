using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Text
{
	public static class StringUtility
	{
		#region " Enumerations "

		public enum TextCasing
		{
			None,
			Lower,
			Upper
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Formats the value appropriately.
		/// </summary>
		/// <param name="text">The text to format.</param>
		/// <returns>The formatted string.</returns>
		public static string FormatValue(string text)
		{
			return FormatValue(text, TextCasing.None);
		}

		/// <summary>
		/// Formats the value appropriately.
		/// </summary>
		/// <param name="text">The text to format.</param>
		/// <param name="lowerCase">Whether to </param>
		/// <returns>The formatted string.</returns>
		public static string FormatValue(string text, TextCasing casing)
		{
			if (text == null)
				return string.Empty;

			if (casing == TextCasing.Lower)
				return text.Trim().ToLower();
			else if (casing == TextCasing.Upper)
				return text.Trim().ToUpper();
			else
				return text.Trim();
		}

		/// <summary>
		/// Determines whether the string has a value.  Trims the text.
		/// </summary>
		/// <param name="text">The text to compare.</param>
		/// <returns>Whether the string has an actual value.</returns>
		public static bool HasValue(string text)
		{
			return HasValue(text, true);
		}

		/// <summary>
		/// Determines whether the string has a value.
		/// </summary>
		/// <param name="text">The text to compare.</param>
		/// <param name="trimText">Whether to trim the text before formatting.</param>
		/// <returns>Whether the string has an actual value.</returns>
		public static bool HasValue(string text, bool trimText)
		{
			if (text == null)
				return false;

			string textToCompare = text;
			if (trimText)
				textToCompare = text.Trim();

			return !string.IsNullOrEmpty(textToCompare);
		}

		public static void ThrowOnNoValue(string text)
		{
			ThrowOnNoValue(text, true);
		}

		public static void ThrowOnNoValue(string text, bool trimText)
		{
			bool throwing = false;

			if (text == null)
				throwing = true;

			if (!throwing)
			{
				string textToCompare = text;
				if (trimText)
					textToCompare = text.Trim();

				if (string.IsNullOrEmpty(textToCompare))
					throwing = true;
			}

			if (throwing)
				throw new ArgumentNullException();
		}

		#endregion
	}
}
