using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

using Nucleo;


namespace System.Web.UI
{
	public static class ControlExtensions
	{
		/// <summary>
		/// Adds a list of controls to its parent.
		/// </summary>
		/// <param name="parent">The parent control to add controls to.</param>
		/// <param name="builder">The lambda reference that builds the collection.</param>
		public static Control AddControls(this Control parent, Func<IEnumerable<Control>> builder)
		{
			Guard.NotNull(builder);

			var controls = builder();

			foreach (Control control in controls)
			{
				parent.Controls.Add(control);
			}

			return parent;
		}
	}
}
