using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Inspectors
{
	public class ListControlInspector : IValueControlInspector, IDataBoundInspector
	{
		#region " Methods "

		public void BindValues(Control control, object data)
		{
			((ListControl)control).DataSource = data;
			control.DataBind();
		}

		public void ClearControlValue(Control control)
		{
			((ListControl)control).SelectedValue = null;
		}

		public object GetValueFromControl(Control control)
		{
			return ((ListControl)control).SelectedValue;
		}

		public bool IsForControl(Type controlType)
		{
			return typeof(ListControl).IsAssignableFrom(controlType);
		}

		public void SetValueFromControl(Control control, object value)
		{
			((ListControl)control).SelectedValue = (value != null) ? value.ToString() : default(string);
		}

		#endregion
	}
}
