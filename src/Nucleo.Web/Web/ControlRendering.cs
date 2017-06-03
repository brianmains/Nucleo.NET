using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

using Nucleo.Context;
using Nucleo.Web.Context;
using Nucleo.Web.Controls.Configuration;
using Nucleo.EventArguments;
using Nucleo.Web.Scripts;
using Nucleo.Web.Tags;
using Nucleo.Web.Templates;
using Nucleo.Global;
using Nucleo.Reflection;


namespace Nucleo.Web
{
	public static class ControlRendering
	{
		#region " Methods "

		public static string GetControlMarkup(Control control)
		{
			return ControlUtility.GetControlMarkup(control);
		}

		public static string GetTemplateMarkup(Control containerControl, ITemplate template)
		{
			return ControlUtility.GetTemplateMarkup(containerControl, template);
		}

		public static WebLegacyRenderer[] GetWebLegacyRenderer(object component, Page page)
		{
			WebLegacyRenderer[] renderers = Reflect.Public(component).Type().GetObjectFromTypeAttributes<WebLegacyRenderer, WebLegacyRendererAttribute>(
				(obj) => { obj.Initialize(component, page); }, true);

			return renderers;
		}

		public static WebRenderer[] GetWebRenderer(object component)
		{
			WebRenderer[] renderers = Reflect.Public(component).Type().GetObjectFromTypeAttributes<WebRenderer, WebRendererAttribute>(
				(obj) => { obj.Initialize(component); }, true);

			return renderers;
		}

		public static bool RenderControl(Control control, BaseControlWriter writer)
		{
			WebRenderer[] renderers = GetWebRenderer(control);
			if (renderers.Length > 0)
			{
				for (int index = 0, len = renderers.Length; index < len; index++)
				{
					TagElement tag = renderers[index].Render();
					writer.Write(tag.ToHtmlString());
				}

				return true;
			}

			WebLegacyRenderer[] legacyRenderers = GetWebLegacyRenderer(control, control.Page);
			if (legacyRenderers.Length > 0)
			{
				for (int index = 0, len = legacyRenderers.Length; index < len; index++)
					legacyRenderers[index].Render(writer);

				return true;
			}

			return false;
		}

		public static bool RenderControl(BaseAjaxControl control, BaseControlWriter writer)
		{
			return RenderControl((Control)control, writer);
		}

		public static bool RenderControl(BaseAjaxPanel control, BaseControlWriter writer)
		{
			return RenderControl((Control)control, writer);
		}

		public static bool RenderExtender(BaseAjaxExtender extender, BaseControlWriter writer)
		{
			return RenderControl((Control)extender, writer);
		}

		public static void RenderTemplate(IElementTemplate template, BaseControlWriter writer)
		{
			if (template == null)
				throw new ArgumentNullException("The server template is required for the DropDown content");
			if (writer == null)
				throw new ArgumentNullException("The writer is null");

			if (template.ReturnsContent)
				writer.Write(template.GetTemplate());
			else
				template.InvokeTemplate();
		}

		#endregion
	}
}
