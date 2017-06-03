using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Nucleo.Web.Mappings
{
	public class ButtonControlManager : ControlManager
	{
		public override object GetValue(Control control)
		{
			if (control is IButtonControl)
				return ((IButtonControl)control).Text;
			else if (control is HtmlInputButton)
				return ((HtmlInputButton)control).Value;
			else if (control is HtmlButton)
				return ((HtmlButton) control).InnerHtml;
			else
				throw new NotImplementedException();
		}

		public override bool IsCorrectControl(Control control)
		{
			return (control is IButtonControl || control is HtmlButton || control is HtmlInputButton);
		}

		public override void SetValue(Control control, object value)
		{
			if (control is IButtonControl)
				((IButtonControl)control).Text = (value != null) ? value.ToString() : string.Empty;
			else if (control is HtmlInputButton)
				((HtmlInputButton)control).Value = (value != null) ? value.ToString() : string.Empty;
			else if (control is HtmlButton)
				((HtmlButton)control).InnerHtml = (value != null) ? value.ToString() : string.Empty;
			else
				throw new NotImplementedException();
		}
	}
}
