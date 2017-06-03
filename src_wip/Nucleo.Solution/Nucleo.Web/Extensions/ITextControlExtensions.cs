using System;
using System.Drawing;
using System.Web.UI;


namespace System.Web.UI
{
	/// <summary>
	/// This class is a set of extensions for any control that implements ITextControl.
	/// </summary>
	public static class ITextControlExtensions
	{
		#region " Methods "

		/// <summary>
		/// Gets the color stored in the textbox that's a given color name.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>The color from the control's text value, or empty if not a valid color.</returns>
		public static Color GetColorName(this ITextControl control)
		{
			try
			{
				return Color.FromName(control.Text);
			}
			catch
			{
				return Color.Empty;
			}
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns the default.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or the default value.</returns>
		public static decimal GetDecimal(this ITextControl control)
		{
			decimal value = 0;
			decimal.TryParse(control.Text, out value);

			return value;
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns null.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or null.</returns>
		public static decimal? GetDecimalOrNull(this ITextControl control)
		{
			decimal value = 0;
			if (decimal.TryParse(control.Text, out value))
				return value;
			else
				return null;
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns the default.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or the default value.</returns>
		public static double GetDouble(this ITextControl control)
		{
			double value = 0;
			double.TryParse(control.Text, out value);

			return value;
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns null.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or null.</returns>
		public static double? GetDoubleOrNull(this ITextControl control)
		{
			double value = 0;
			if (double.TryParse(control.Text, out value))
				return value;
			else
				return null;
		}

		/// <summary>
		/// Gets a float value from the text control, if a valid value.  Otherwise returns the default.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or the default value.</returns>
		public static float GetFloat(this ITextControl control)
		{
			float value = 0;
			float.TryParse(control.Text, out value);

			return value;
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns null.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or null.</returns>
		public static float? GetFloatOrNull(this ITextControl control)
		{
			float value = 0;
			if (float.TryParse(control.Text, out value))
				return value;
			else
				return null;
		}

		/// <summary>
		/// Gets an integer value from the text control, if a valid value.  Otherwise returns the default.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or the default value.</returns>
		public static int GetInteger(this ITextControl control)
		{
			int value = 0;
			int.TryParse(control.Text, out value);

			return value;
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns null.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or null.</returns>
		public static int? GetIntegerOrNull(this ITextControl control)
		{
			int value = 0;
			if (int.TryParse(control.Text, out value))
				return value;
			else
				return null;
		}

		/// <summary>
		/// Gets an integer value from the text control, if a valid value.  Otherwise returns the default.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or the default value.</returns>
		public static int GetShort(this ITextControl control)
		{
			short value = 0;
			short.TryParse(control.Text, out value);

			return value;
		}

		/// <summary>
		/// Gets a decimal value from the text control, if a valid value.  Otherwise returns null.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <returns>A valid converted value, or null.</returns>
		public static int? GetShortOrNull(this ITextControl control)
		{
			short value = 0;
			if (short.TryParse(control.Text, out value))
				return value;
			else
				return null;
		}

		/// <summary>
		/// Gets the value as the specified convertible type.
		/// </summary>
		/// <typeparam name="T">The type that implements IConvertible, most value types and maybe some reference types.</typeparam>
		/// <param name="control">The text control.</param>
		/// <returns>The converted value.</returns>
		public static T GetValueAs<T>(this ITextControl control)
		{
			return (T)Convert.ChangeType(control.Text, typeof(T));
		}

		/// <summary>
		/// Assigns the decimal value to the textbox.
		/// </summary>
		/// <param name="control">The control to assign to.</param>
		/// <param name="value">The value to assign.</param>
		public static void SetDecimal(this ITextControl control, decimal? value)
		{
			if (value.HasValue)
				control.Text = value.Value.ToString();
			else
				control.Text = string.Empty;
		}

		/// <summary>
		/// Assigns the double value to the textbox.
		/// </summary>
		/// <param name="control">The control to assign to.</param>
		/// <param name="value">The value to assign.</param>
		public static void SetDouble(this ITextControl control, double? value)
		{
			if (value.HasValue)
				control.Text = value.Value.ToString();
			else
				control.Text = string.Empty;
		}

		/// <summary>
		/// Assigns the float value to the textbox.
		/// </summary>
		/// <param name="control">The control to assign to.</param>
		/// <param name="value">The value to assign.</param>
		public static void SetFloat(this ITextControl control, float? value)
		{
			if (value.HasValue)
				control.Text = value.Value.ToString();
			else
				control.Text = string.Empty;
		}

		/// <summary>
		/// Assigns the integer value to the textbox.
		/// </summary>
		/// <param name="control">The control to assign to.</param>
		/// <param name="value">The value to assign.</param>
		public static void SetInteger(this ITextControl control, int? value)
		{
			if (value.HasValue)
				control.Text = value.Value.ToString();
			else
				control.Text = string.Empty;
		}

		/// <summary>
		/// Assigns the long value to the textbox.
		/// </summary>
		/// <param name="control">The control to assign to.</param>
		/// <param name="value">The value to assign.</param>
		public static void SetLong(this ITextControl control, long? value)
		{
			if (value.HasValue)
				control.Text = value.Value.ToString();
			else
				control.Text = string.Empty;
		}

		/// <summary>
		/// Assigns the short value to the textbox.
		/// </summary>
		/// <param name="control">The control to assign to.</param>
		/// <param name="value">The value to assign.</param>
		public static void SetShort(this ITextControl control, short? value)
		{
			if (value.HasValue)
				control.Text = value.Value.ToString();
			else
				control.Text = string.Empty;
		}

		/// <summary>
		/// Sets the value as the specified convertible type.
		/// </summary>
		/// <typeparam name="T">The type that implements IConvertible, most value types and maybe some reference types.</typeparam>
		/// <param name="control">The text control.</param>
		/// <param name="value">The value to set.</param>
		public static void SetValueAs<T>(this ITextControl control, T value)
			where T : IConvertible
		{
			if (value != null)
				control.Text = ((IConvertible)value).ToString();
			else
				control.Text = "";
		}

		#endregion
	}
}
