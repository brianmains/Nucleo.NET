using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Mappings
{
	public class ListControlManager : ControlManager
	{
		public override object GetValue(Control control)
		{
			return ((ListControl)control).SelectedValue;
		}

		public override bool IsCorrectControl(Control control)
		{
			return (control is ListControl);
		}

		public override void SetValue(Control control, object value)
		{
			((ListControl)control).SelectedValue = (value != null) ? value.ToString() : string.Empty;
		}
	}
}
