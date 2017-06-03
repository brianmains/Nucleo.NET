using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace Nucleo.Web.Mappings
{
	public class TextControlManager : ControlManager
	{
		#region " Methods "

		public override object GetValue(Control control)
		{
			if (control is ITextControl)
				return ((ITextControl)control).Text;
			else if (control is HtmlInputText)
				return ((HtmlInputText)control).Value;
			else if (control is HtmlTextArea)
				return ((HtmlTextArea) control).Value;
			else
				throw new NotImplementedException();
		}

		public override bool IsCorrectControl(Control control)
		{
			return (control is ITextControl || control is HtmlInputText || control is HtmlTextArea);
		}

		public override void SetValue(Control control, object value)
		{
			if (control is ITextControl)
				((ITextControl)control).Text = (value != null) ? value.ToString() : string.Empty;
			else if (control is HtmlInputText)
				((HtmlInputText)control).Value = (value != null) ? value.ToString() : string.Empty;
			else if (control is HtmlTextArea)
				((HtmlTextArea)control).Value = (value != null) ? value.ToString() : string.Empty;
			else
				throw new NotImplementedException();
		}

		#endregion
	}
}
