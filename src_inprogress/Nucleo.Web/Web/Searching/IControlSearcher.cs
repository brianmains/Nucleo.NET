using System;
using System.Web.UI;


namespace Nucleo.Web.Searching
{
	/// <summary>
	/// Represents the interface used to search controls.
	/// </summary>
	public interface IControlSearcher
	{
		#region " Methods "

		Control FindControl(Control baseControl, string id);

		Control FindControl(Control baseControl, string id, ControlSearcherDirection direction);

		T[] FindControls<T>(Control baseControl)
			where T : Control;

		T[] FindControls<T>(Control baseControl, ControlSearcherDirection direction)
			where T: Control;
		
		T FindParent<T>(Control baseControl)
			where T : Control;

		T[] FindParents<T>(Control baseControl)
			where T : Control;
			
		#endregion
	}
}
