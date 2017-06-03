using System;
using System.Web.UI;


namespace Nucleo.Web.Inspectors
{
	public interface IValueControlInspector : IControlInspector
	{
		#region " Methods "

		void ClearControlValue(Control control);

		object GetValueFromControl(Control control);

		void SetValueFromControl(Control control, object value);

		#endregion
	}
}
