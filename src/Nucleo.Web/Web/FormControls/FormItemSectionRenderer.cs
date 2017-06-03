using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Nucleo.Web.Tags;


namespace Nucleo.Web.FormControls
{
	public class FormItemSectionRenderer : WebLegacyRenderer
	{
		public FormItemSection Component
		{
			get { return (FormItemSection)base.Component; }
		}

		public override void Render(BaseControlWriter writer)
		{
			if (this.RenderContent(writer))
				return;

			this.RenderHeader(writer);

			this.RenderItems(writer);
		}

		protected virtual bool RenderContent(BaseControlWriter writer)
		{
			if (this.Component.Content != null)
			{
				if (this.Component.Content.ReturnsContent)
					writer.Write(this.Component.Content.GetTemplate());
				else
					this.Component.Content.InvokeTemplate();

				return true;
			}

			return false;
		}

		protected virtual void RenderHeader(BaseControlWriter writer)
		{
			if (this.Component.Header != null)
			{
				if (this.Component.Header.ReturnsContent)
					writer.Write(this.Component.Header.GetTemplate());
				else
					this.Component.Header.InvokeTemplate();
			}
		}

		protected virtual void RenderItems(BaseControlWriter writer)
		{
			writer.Write("<table>");
			writer.Write("<thead></thead>");
			writer.Write("<tbody>");

			foreach (FormItemDisplay item in this.Component.Items)
			{
				if (!item.Visible)
					continue;

				FormItemDisplayStyle style = item.ItemStyle ?? this.Component.ItemStyle;

				writer.Write("<tr>");

				writer.Write("<td{0}>{1}</td>",
					(style != null) ? " class='" + style.HeaderCssClass + "'" : "",
					item.Header ?? "&nbsp;");

				writer.Write("<td{0}>", (style != null) ? " class='" + style.ContentCssClass + "'" : "");

				((IRenderableControl)item).RenderUI(writer);

				writer.Write("</td>");

				writer.Write("</tr>");
			}

			writer.Write("</tbody>");
			writer.Write("</table>");
		}
	}
}
