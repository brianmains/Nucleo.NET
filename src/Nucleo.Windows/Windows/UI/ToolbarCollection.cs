using System;
using Nucleo.Collections;
using Nucleo.EventArguments;


namespace Nucleo.Windows.UI
{
	public class ToolbarCollection : UIElementCollection<Toolbar>
	{
		#region " Methods "

		public Toolbar[] FindByLocation(ToolbarLocation location)
		{
			SimpleCollection<Toolbar> list = new SimpleCollection<Toolbar>();

			foreach (Toolbar toolbar in this)
			{
				if (toolbar.Location == location)
					list.Add(toolbar);
			}

			return list.ToArray();
		}

		#endregion
	}
}
