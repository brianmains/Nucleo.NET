using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;


namespace System.Web.UI
{
	/// <summary>
	/// Represents the extensions for control collections.
	/// </summary>
	public static class ControlCollectionExtensions
	{
		#region " Methods "

		/// <summary>
		/// Adds a range of controls to the parent control.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="controls">The controls to add.</param>
		public static void AddRange(this ControlCollection list, params Control[] controls)
		{
			foreach (Control control in controls)
				list.Add(control);
		}

		/// <summary>
		/// Adds a range of controls to the parent control.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="controls">The controls to add.</param>
		public static void AddRange(this ControlCollection list, IEnumerable<Control> controls)
		{
			foreach (Control control in controls)
				list.Add(control);
		}

		/// <summary>
		/// Hide all controls.
		/// </summary>
		/// <param name="controls">The controls to hide.</param>
		public static void HideAll(this ControlCollection controls)
		{
			foreach (Control control in controls)
				control.Visible = false;
		}

		/// <summary>
		/// Set the visibility of all controls to a value.
		/// </summary>
		/// <param name="controls">The controls to set visibility for.</param>
		/// <param name="visible">The visibility of controls.</param>
		public static void SetAllVisibility(this ControlCollection controls, bool visible)
		{
			foreach (Control control in controls)
				control.Visible = visible;
		}

		/// <summary>
		/// Hide all controls.
		/// </summary>
		/// <param name="controls">The controls to hide.</param>
		public static void ShowAll(this ControlCollection controls)
		{
			foreach (Control control in controls)
				control.Visible = true;
		}

		/// <summary>
		/// Toggles controls visibility.
		/// </summary>
		/// <param name="controls">The controls to hide.</param>
		public static void ToggleAllVisibility(this ControlCollection controls)
		{
			foreach (Control control in controls)
				control.Visible = !control.Visible;
		}

		#endregion
	}
}
