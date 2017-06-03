using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web
{
	public static class ControlRenderingUtility
	{
		public static void AppendAttribute(WebControl control, string attributeName, string value)
		{
			string attrib = control.Attributes[attributeName];

			if (!string.IsNullOrEmpty(attrib))
			{
				attrib = JavaScriptUtility.AppendSemiColon(attrib);
				attrib += JavaScriptUtility.AppendSemiColon(value);
			}
			else
				attrib = JavaScriptUtility.AppendSemiColon(value);

			control.Attributes[attributeName] = attrib;
		}

		public static PostBackOptions GetPostbackOptions(IButtonControl control)
		{
			return Nucleo.Web.ControlUtility.GetPostbackOptions(control);
		}

		public static void RenderBackgroundImage(HtmlTextWriter writer, string imageUrl)
		{
			RenderBackgroundImage(writer, imageUrl, false, false);
		}

		public static void RenderBackgroundImage(HtmlTextWriter writer, string imageUrl, bool repeatX, bool repeatY)
		{
			if (string.IsNullOrEmpty(imageUrl))
				return;

			writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundImage, string.Format("url({0});", imageUrl));
			if (repeatX && repeatY)
				writer.AddStyleAttribute("background-repeat", "repeat");
			else if (repeatX)
				writer.AddStyleAttribute("background-repeat", "repeat-x");
			else if (repeatY)
				writer.AddStyleAttribute("background-repeat", "repeat-y");
			else
				writer.AddStyleAttribute("background-repeat", "no-repeat");
		}

		public static void RenderBorder(HtmlTextWriter writer, Style style)
		{
			if (style.BorderColor != System.Drawing.Color.Empty)
				writer.AddStyleAttribute(HtmlTextWriterStyle.BorderColor, System.Drawing.ColorTranslator.ToHtml(style.BorderColor));
			if (style.BorderStyle != BorderStyle.NotSet)
				writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, style.BorderStyle.ToString());
			if (style.BorderWidth != Unit.Empty)
				writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, style.BorderWidth.ToString());
		}

		public static void RenderButton(HtmlTextWriter writer, string text, string imageUrl, string command)
		{
			if (!string.IsNullOrEmpty(imageUrl))
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Type, "image");
				writer.AddAttribute(HtmlTextWriterAttribute.Src, imageUrl);

				if (!string.IsNullOrEmpty(command))
					writer.AddAttribute(HtmlTextWriterAttribute.Onclick, command + ";return false;");
				writer.RenderBeginTag(HtmlTextWriterTag.Input);
				writer.RenderEndTag();
			}
			else
			{
				if (!string.IsNullOrEmpty(command))
					writer.AddAttribute(HtmlTextWriterAttribute.Onclick, command + ";return false;");
				writer.RenderBeginTag(HtmlTextWriterTag.Button);
				writer.Write(text);
				writer.RenderEndTag();
			}
		}

		public static void RenderStyle(HtmlTextWriter writer, Style style)
		{
			if (style == null)
				return;

			if (style.BackColor != System.Drawing.Color.Empty)
				writer.AddAttribute(HtmlTextWriterAttribute.Bgcolor, style.BackColor.Name);
			if (style.BorderColor != System.Drawing.Color.Empty)
				writer.AddAttribute(HtmlTextWriterAttribute.Bordercolor, style.BorderColor.Name);
			if (style.BorderStyle != BorderStyle.NotSet)
				writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, style.BorderStyle.ToString());
			if (!style.BorderWidth.IsEmpty)
				writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, style.BorderWidth.ToString());
			if (style.ForeColor != System.Drawing.Color.Empty)
				writer.AddStyleAttribute(HtmlTextWriterStyle.Color, style.ForeColor.Name);
			if (style.Height != null && !style.Height.IsEmpty)
				writer.AddAttribute(HtmlTextWriterAttribute.Height, style.Height.ToString());
			if (style.Width != null && !style.Width.IsEmpty)
				writer.AddAttribute(HtmlTextWriterAttribute.Width, style.Width.ToString());
			if (style.Font != null && !string.IsNullOrEmpty(style.Font.ToString()))
			{
				writer.AddStyleAttribute(HtmlTextWriterStyle.FontFamily, style.Font.Name);
				writer.AddStyleAttribute(HtmlTextWriterStyle.FontSize, style.Font.Size.ToString());
				writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, (style.Font.Bold ? "bold" : "normal"));
			}
			if (!string.IsNullOrEmpty(style.CssClass))
				writer.AddAttribute(HtmlTextWriterAttribute.Class, style.CssClass);
		}
	}
}