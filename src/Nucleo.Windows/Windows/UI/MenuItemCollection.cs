using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public class MenuItemCollection : UIElementCollection<MenuItem>
	{
		#region " Properties "

		/// <summary>
		/// This property returns the child node which is found using the value path object of names, not titles.
		/// </summary>
		/// <param name="path">The path to use to navigate to the child node.</param>
		/// <returns></returns>
		public MenuItem this[ValuePath path]
		{
			get
			{
				if (path == null || string.IsNullOrEmpty(path.ToString()))
					return null;
				MenuItem lastMenu = null;
				bool started = true;

				foreach (string menuName in path.Values)
				{
					if (!started)
						lastMenu = lastMenu.Items[menuName];
					else
					{
						lastMenu = this[menuName];
						started = false;
					}

					if (lastMenu == null)
						return null;
				}

				return lastMenu;
			}
		}

		#endregion



		#region " Methods "

		public bool Contains(ValuePath path)
		{
			return (this[path] != null);
		}

		/// <summary>
		/// This method removes a single menu item based on the value path provided.  The value path must match the names of each menu item and not the title.
		/// </summary>
		/// <param name="path">The path of names to navigate to the child node to remove.</param>
		/// <returns>A boolean value for the status of the removal.</returns>
		public bool Remove(ValuePath path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			if (path.Values.Count == 1)
				this.Remove(this[path.Values[0]]);

			MenuItem parent = null;
			MenuItem current = null;

			for (int i = 0; i < path.Values.Count; i++)
			{
				if (i != 0)
					parent = current;
				current = (parent != null) ? parent.Items[path.Values[i]] : this[path.Values[i]];
			}

			if (parent != null && current != null)
				return parent.Items.Remove(current);
			else
				return false;
		}

		#endregion
	}
}
