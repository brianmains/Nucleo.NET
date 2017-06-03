using System;
using System.Web.UI;
using Nucleo.Collections;


namespace Nucleo.Web.Mappings
{
	public class ControlManagerCollection : SimpleCollection<ControlManager>
	{
		#region " Methods "

		/// <summary>
		/// Finds the manager by the control.
		/// </summary>
		/// <param name="control">The control to lookup.</param>
		/// <returns>The instance of the manager found, or null if not found.</returns>
		public ControlManager FindByControl(Control control)
		{
			if (control == null)
				throw new ArgumentNullException("control");

			foreach (ControlManager manager in this)
			{
				if (manager.IsCorrectControl(control))
					return manager;
			}

			return null;
		}

		#endregion
	}
}
