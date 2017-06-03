using System;
using System.Drawing;

namespace Nucleo.Drawing
{
	public static class ColorHelper
	{
		/// <summary>
		/// Gets the name of the color; if an empty color, an empty string returns.
		/// </summary>
		/// <param name="color">The color to evaluate.</param>
		/// <returns>The name of the color.</returns>
		public static string GetColorName(Color color)
		{
			if (IsEmptyColor(color))
				return string.Empty;

			return ColorTranslator.ToHtml(color);
		}

		/// <summary>
		/// Determines if the color is an empty color (empty or transparent).
		/// </summary>
		/// <param name="color">The color to evaluate.</param>
		/// <returns>Whether the color is an empty color.</returns>
		public static bool IsEmptyColor(Color color)
		{
			return (color.IsEmpty || color == Color.Transparent);
		}

		/// <summary>
		/// Gets the color from its name.
		/// </summary>
		/// <param name="colorName">The name of the color.</param>
		/// <returns>Returns the color object, or empty if it doesn't exist.</returns>
		public static Color ToColor(string colorName)
		{
			if (string.IsNullOrEmpty(colorName))
				return Color.Empty;

			return Color.FromName(colorName);
		}
	}
}
