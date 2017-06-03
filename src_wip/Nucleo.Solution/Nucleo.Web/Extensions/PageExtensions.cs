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
		public static T GetProfileValue<T>(this Page page, string propertyName)
		{
			return (T)HttpContext.Current.Profile.GetPropertyValue(propertyName);
		}

		/// <summary>
		/// Saves a value to the profile property.
		/// </summary>
		/// <param name="propertyName">The profile property to save.</param>
		/// <param name="value">The value to save for the property.</param>
		public static void SaveProfileValue(this Page page, string propertyName, object value)
		{
			HttpContext.Current.Profile.SetPropertyValue(propertyName, value);
		}

		/// <summary>
		/// This method sets the default button of the form to a specific control.
		/// </summary>
		/// <param name="control">The control to set as the default button.</param>
		public static void SetDefaultButton(this Page page, Control control)
		{
			page.Form.DefaultButton = control.UniqueID;
		}

		#endregion
	}
}
