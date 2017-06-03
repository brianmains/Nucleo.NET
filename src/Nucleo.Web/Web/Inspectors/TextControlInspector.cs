using System;
using System.Web.UI;


namespace Nucleo.Web.Inspectors
{
	public class TextControlInspector : IValueControlInspector
	{

		#region " Methods "

		public void ClearControlValue(Control control)
		{
			((ITextControl)control).Text = string.Empty;
		}

		public object GetValueFromControl(Control control)
		{
			return ((ITextControl)control).Text;
		}

		public bool IsForControl(Type controlType)
		{
			return (controlType.GetInterface("ITextControl") != null);
		}

		public void SetValueFromControl(Control control, object value)
		{
			((ITextControl)control).Text = (value != null) ? value.ToString() : string.Empty;
		}

		#endregion
	}
}
