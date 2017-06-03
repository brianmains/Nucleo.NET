using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarItemCollection : ControlListCollection<NavigationBarItem>
	{
		#region " Properties "

		/// <summary>
		/// Gets a navigation bar item using its specified index.
		/// </summary>
		/// <param name="index">The index of the item to get.</param>
		/// <returns>The item found at the specified index, formatted as a NavigationBarItem.</returns>
		new public NavigationBarItem this[int index]
		{
			get { return (NavigationBarItem)base[index]; }
		}

		#endregion



		#region " Constructors "

		public NavigationBarItemCollection(Control owner)
			: base(owner) { }

		public NavigationBarItemCollection(Control owner, params Control[] controls)
			: this(owner)
		{
			foreach (Control control in controls)
				this.Add(control);
		}

		#endregion
	}
}
