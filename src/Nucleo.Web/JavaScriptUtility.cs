using System;
using System.Web;
using System.Web.UI;


namespace Nucleo.Web
{
	public static class JavaScriptUtility
	{
		public static string AppendSemiColon(string value)
		{
			//If not null or empty
			if (!string.IsNullOrEmpty(value))
			{
				//If there isn't a semicolon, add it
				if (!value.EndsWith(";"))
					return (value + ";");
			}

			return value;
		}

		public static string AppendStatement(string statement, string value)
		{
			string attribs = statement;

			if (!string.IsNullOrEmpty(attribs))
				attribs = AppendSemiColon(attribs);
			else
				attribs = string.Empty;

			attribs += AppendSemiColon(value);
			return attribs;
		}

		public static string FormatStatement(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (!value.StartsWith("javascript:"))
				{
					string stmt = "javascript:" + value;
					return AppendSemiColon(stmt);
				}
			}

			return value;
		}

		internal static void RenderScripts(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			if (!page.ClientScript.IsClientScriptIncludeRegistered("controlscript_js"))
				page.ClientScript.RegisterClientScriptInclude("controlscript_js", page.ClientScript.GetWebResourceUrl(typeof(Page), "controlscript.js"));
		}
	}
}
