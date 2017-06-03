using System;
using System.Web;


namespace System.Web.UI
{
	public static class PageExtensions
	{
		#region " Methods "

		/// <summary>
		/// Gets a strongly typed value from teh profile.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="propertyName"></param>
		/// <returns></returns>
#if NET20
		public static T GetProfileValue<T>(Page page, string propertyName)
#else
		public static T GetProfileValue<T>(this Page page, string propertyName)
#endif
		{
			return (T)HttpContext.Current.Profile.GetPropertyValue(propertyName);
		}

		/// <summary>
		/// Saves a value to the profile property.
		/// </summary>
		/// <param name="propertyName">The profile property to save.</param>
		/// <param name="value">The value to save for the property.</param>
#if NET20
		public static void SaveProfileValue(Page page, string propertyName, object value)
#else
		public static void SaveProfileValue(this Page page, string propertyName, object value)
#endif
		{
			HttpContext.Current.Profile.SetPropertyValue(propertyName, value);
		}

		/// <summary>
		/// This method sets the default button of the form to a specific control.
		/// </summary>
		/// <param name="control">The control to set as the default button.</param>
#if NET20
		public static void SetDefaultButton(Page page, Control control)
#else
		public static void SetDefaultButton(this Page page, Control control)
#endif
		{
			page.Form.DefaultButton = control.UniqueID;
		}

		#endregion
	}
}
