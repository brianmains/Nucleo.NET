using System;
using Nucleo.Drawing;


namespace System.Drawing
{
	public static class ColorExtensions
	{
		/// <summary>
		/// Gets the name of the color; if an empty color, an empty string returns.
		/// </summary>
		/// <param name="color">The color to evaluate.</param>
		/// <returns>The name of the color.</returns>
#if NET20
		public static string GetColorName(Color color)
#else
		public static string GetColorName(this Color color)
#endif
		{
			return ColorHelper.GetColorName(color);
		}

		/// <summary>
		/// Determines if the color is an empty color (empty or transparent).
		/// </summary>
		/// <param name="color">The color to evaluate.</param>
		/// <returns>Whether the color is an empty color.</returns>
#if NET20
		public static bool IsEmptyColor(Color color)
#else
		public static bool IsEmptyColor(this Color color)
#endif
		{
			return ColorHelper.IsEmptyColor(color);
		}

		/// <summary>
		/// Gets the color from its name.
		/// </summary>
		/// <param name="colorName">The name of the color.</param>
		/// <returns>Returns the color object, or empty if it doesn't exist.</returns>
#if NET20
		public static Color ToColor(string colorName)
#else
		public static Color ToColor(this string colorName)
#endif
		{
			return ColorHelper.ToColor(colorName);
		}
	}
}
