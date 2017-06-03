using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo;


namespace System.Web.UI.WebControls
{
	public static class ListControlExtensions
	{
		/// <summary>
		/// Binds data to the control, including a default item if its specified.
		/// </summary>
		/// <param name="control">The control to bind.</param>
		/// <param name="data">The data to bind.</param>
		/// <param name="includeDefaultItem">Whether to include a default item.</param>
		public static void BindData(this ListControl control, object data, bool includeDefaultItem)
		{
			control.DataSource = data;
			control.DataBind();

			if (includeDefaultItem)
				control.Items.Insert(0, new ListItem("Any", ""));
		}

		/// <summary>
		/// Binds data to the control, including a default item if its specified.  Only binds if data isn't null.
		/// </summary>
		/// <param name="control">The control to bind.</param>
		/// <param name="data">The data to bind.</param>
		/// <param name="includeDefaultItem">Whether to include a default item.</param>
		public static void BindDataIfNotNull(this ListControl control, object data, bool includeDefaultItem)
		{
			if (data != null)
			{
				control.DataSource = data;
				control.DataBind();
			}

			if (includeDefaultItem)
				control.Items.Insert(0, new ListItem("Any", ""));
		}

		/// <summary>
		/// Finds items in the list control that match the specified lambda expression.
		/// </summary>
		/// <param name="control">The control to extend.</param>
		/// <param name="result">The lambda expression that determines if there is a match.</param>
		/// <returns>A collection of items that were found.</returns>
		public static ListItemCollection FindItemsWith(this ListControl control, Func<ListItem, bool> result)
		{
			ListItemCollection foundItems = new ListItemCollection();
			foreach (ListItem item in control.Items)
			{
				if (result(item))
					foundItems.Add(item);
			}

			return foundItems;
		}

		/// <summary>
		/// Gets the key value from the list control, only if the key value is an integer.
		/// </summary>
		/// <param name="control">The control value.</param>
		/// <returns>The key value if its a valid key, or default int if not.</returns>
		public static Guid GetSelectedGuidValue(this ListControl control)
		{
			Guid key;

			try
			{
				if (!string.IsNullOrEmpty(control.SelectedValue))
				{
					return new Guid(control.SelectedValue);
				}
			}
			catch { }

			return Guid.Empty;
		}

		/// <summary>
		/// Gets the key value from the list control, only if the key value is an integer.
		/// </summary>
		/// <param name="control">The control value.</param>
		/// <returns>The key value if its a valid key, or default int if not.</returns>
		public static Guid? GetSelectedGuidValueOrNull(this ListControl control)
		{
			Guid key;

			try
			{
				if (!string.IsNullOrEmpty(control.SelectedValue))
				{
					return new Guid(control.SelectedValue);
				}
			}
			catch { }

			return null;
		}

		/// <summary>
		/// Gets the key value from the list control, only if the key value is an integer.
		/// </summary>
		/// <param name="control">The control value.</param>
		/// <returns>The key value if its a valid key, or default int if not.</returns>
		public static int GetSelectedKeyValue(this ListControl control)
		{
			int key;

			if (!string.IsNullOrEmpty(control.SelectedValue) &&
				int.TryParse(control.SelectedValue, out key))
			{
				return key;
			}
			else
				return default(int);
		}

		/// <summary>
		/// Gets the key value from the list control, only if the key value is an integer. Otherwise returns null.
		/// </summary>
		/// <param name="control">The control value.</param>
		/// <returns>The key value if its a valid key, or null if not.</returns>
		public static int? GetSelectedKeyValueOrNull(this ListControl control)
		{
			int key;

			if (!string.IsNullOrEmpty(control.SelectedValue) &&
				int.TryParse(control.SelectedValue, out key))
			{
				return key;
			}
			else
				return default(int?);
		}

		/// <summary>
		/// Selects all of the items in the list.
		/// </summary>
		/// <param name="control">The control to extend.</param>
		public static void SelectAll(this ListControl control)
		{
			foreach (ListItem item in control.Items)
				item.Selected = true;
		}

		/// <summary>
		/// Selects any items in the collection that matches a particular text within the item's text.  If there is a match, the item is selected.
		/// </summary>
		/// <param name="control">The control to extend.</param>
		/// <param name="text">The text to find within the item's text.</param>
		/// <param name="textLocation">Where to match the text in.</param>
		public static void SelectItemsWith(this ListControl control, string text, PartialTextLocation textLocation)
		{
			foreach (ListItem item in control.Items)
			{
				if (textLocation == PartialTextLocation.Beginning)
				{
					if (item.Text.StartsWith(text))
						item.Selected = true;
				}
				else if (textLocation == PartialTextLocation.Ending)
				{
					if (item.Text.EndsWith(text))
						item.Selected = true;
				}
				else if (textLocation == PartialTextLocation.Containing)
				{
					if (item.Text.Contains(text))
						item.Selected = true;
				}
				else
					throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Unselects all of the items in the list.
		/// </summary>
		/// <param name="control">The control to extend.</param>
		public static void UnselectAll(this ListControl control)
		{
			foreach (ListItem item in control.Items)
				item.Selected = false;
		}
	}
}
