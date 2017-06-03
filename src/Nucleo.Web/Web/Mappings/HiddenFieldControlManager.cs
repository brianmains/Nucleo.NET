using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Nucleo.Web.Mappings
{
	public class HiddenFieldControlManager : ControlManager
	{
		#region " Methods "

		public override object GetValue(Control control)
		{
			if (control is HiddenField)
				return ((HiddenField)control).Value;
			else if (control is HtmlInputHidden)
				return ((HtmlInputHidden)control).Value;
			else
				throw new NotImplementedException();
		}

		public override bool IsCorrectControl(Control control)
		{
			return (control is HiddenField || control is HtmlInputHidden);
		}

		public override void SetValue(Control control, object value)
		{
			if (control is HiddenField)
				((HiddenField)control).Value = (value != null) ? value.ToString() : null;
			else if (control is HtmlInputHidden)
				((HtmlInputHidden)control).Value = (value != null) ? value.ToString() : null;
			else
				throw new NotImplementedException();
		}

		#endregion
	}
}
