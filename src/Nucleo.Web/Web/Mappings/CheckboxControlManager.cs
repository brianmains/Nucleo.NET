using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace Nucleo.Web.Mappings
{
	public class CheckboxControlManager : ControlManager
	{
		#region " Methods "

		public override object GetValue(Control control)
		{
			if (control is ICheckBoxControl)
				return ((ICheckBoxControl)control).Checked;
			else if (control is HtmlInputCheckBox)
				return ((HtmlInputCheckBox)control).Checked;
			else if (control is HtmlInputRadioButton)
				return ((HtmlInputRadioButton)control).Checked;
			else
				throw new NotImplementedException();
		}

		public override bool IsCorrectControl(Control control)
		{
			return (control is ICheckBoxControl || control is HtmlInputCheckBox || control is HtmlInputRadioButton);
		}

		public override void SetValue(Control control, object value)
		{
			bool boolValue = (value != null && value is bool) ? (bool) value : false;

			if (control is ICheckBoxControl)
				((ICheckBoxControl)control).Checked = boolValue;
			else if (control is HtmlInputCheckBox)
				((HtmlInputCheckBox)control).Checked = boolValue;
			else if (control is HtmlInputRadioButton)
				((HtmlInputRadioButton) control).Checked = boolValue;
			else
				throw new NotImplementedException();
		}

		#endregion
	}
}
