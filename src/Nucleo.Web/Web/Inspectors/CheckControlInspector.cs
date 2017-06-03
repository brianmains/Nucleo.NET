using System;
using System.Web.UI;


namespace Nucleo.Web.Inspectors
{
	public class CheckControlInspector : IValueControlInspector
	{
		#region " Methods "

		public void ClearControlValue(Control control)
		{
			((ICheckBoxControl)control).Checked = false;
		}

		public object GetValueFromControl(Control control)
		{
			return ((ICheckBoxControl)control).Checked;
		}

		public bool IsForControl(Type controlType)
		{
			return (controlType.GetInterface("ICheckBoxControl") != null);
		}

		public void SetValueFromControl(Control control, object value)
		{
			((ICheckBoxControl)control).Checked = (value != null && value is bool) ? (bool)value : false;
		}

		#endregion
	}
}
