using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public interface IToolbarListItem
	{
		/// <summary>
		/// Gets the item from the string form, and uses it to create the toolbar list item object.
		/// </summary>
		void FromDisplay(string text);
		/// <summary>
		/// Takes the item and converts it to a string.
		/// </summary>
		/// <returns>A string version of the item.</returns>
		string ToDisplay();
	}
}
