using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.FormControls
{
	public class FormItemContainerRenderer : WebLegacyRenderer
	{
		#region " Properties "

		public FormItemContainer Component
		{
			get { return (FormItemContainer)base.Component; }
		}

		#endregion



		public override void Render(BaseControlWriter writer)
		{
			writer.Write("<div>");

			writer.Write("<div>");
			foreach (FormItemSection section in this.Component.Sections)
			{
				if (!section.Visible)
					continue;

				((IRenderableControl)section).RenderUI(writer);
			}
			writer.Write("</div>");

			writer.Write("</div>");
		}
	}
}
