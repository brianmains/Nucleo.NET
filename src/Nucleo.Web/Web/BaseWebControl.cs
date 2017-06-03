using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web
{
	public abstract class BaseWebControl : WebControl, IRenderableControl
	{
		#region " Methods "

		protected override void Render(HtmlTextWriter writer)
		{
			this.RenderUI(new HtmlStreamControlWriter(writer));
		}

		public abstract void RenderUI(BaseControlWriter writer);

		#endregion
	}
}
