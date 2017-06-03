using System;
using System.Reflection;
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
using Nucleo.Global;
using Nucleo.Reflection;


namespace Nucleo.Web
{
	public static class ContentRendering
	{
		#region " Methods "

		public static string CreateCssReference(CssReference cssReference)
		{
			if (cssReference == null)
				throw new ArgumentNullException("cssReference");

			TagElement element = TagElementBuilder.Create("LINK");
			element.Attributes.AppendAttribute("rel", "stylesheet")
				.AppendAttribute("type", "text/css");

			element.Attributes.AppendAttribute("href", cssReference.Path);

			return element.ToHtmlString();
		}

		public static string CreateDescriptorScript(ScriptComponentDescriptor descriptor)
		{
			StringBuilder builder = new StringBuilder();
			builder
				//.AppendLine("<script type='text/javascript' language='javascript'>")
				.AppendLine("$nucleo_register(function() {")
				.AppendLine((string)Reflect.NonPublic(descriptor).Method("GetScript").Invoke())
				.AppendLine("});");
				//.AppendLine("</script>");

			return builder.ToString();
		}

		public static string CreateScriptReference(string script)
		{
			if (script == null)
				throw new ArgumentNullException("script");

			TagElement element = TagElementBuilder.Create("SCRIPT");
			element.Attributes.AppendAttribute("language", "javascript")
				.AppendAttribute("type", "text/javascript")
				.AppendAttribute("src", script);

			return element.ToHtmlString();
		}

		#endregion
	}
}
