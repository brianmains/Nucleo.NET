using System;
using System.Web.UI;


namespace Nucleo.Web.NavigationControls
{
	public class NavigationBarCollection : ControlListCollection<NavigationBar>
	{
		#region " Constructors "

		/// <summary>
		/// Creates the colleciton, passing along the control that owns it.
		/// </summary>
		/// <param name="owner"></param>
		public NavigationBarCollection(Control owner)
			: base(owner) { }

		#endregion
	}
}
