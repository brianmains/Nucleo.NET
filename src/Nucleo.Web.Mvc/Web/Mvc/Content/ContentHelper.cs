using System;
using System.Web.UI;
using System.Web.Mvc;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc.Content
{
	public static class ContentHelper
	{
		public static string Css(this HtmlHelper helper, string cssFile)
		{
			TagElement tag = TagElementBuilder.Create("link");
			tag.Attributes.AppendAttribute("rel", "stylesheet")
				.AppendAttribute("type", "text/css")
				.AppendAttribute("src", cssFile);

			return tag.ToHtmlString();
		}

		public static string Image(this HtmlHelper helper, string imageUrl)
		{
			TagElement tag = TagElementBuilder.Create("img");
			tag.Attributes.AppendAttribute("src", imageUrl);

			return tag.ToHtmlString();
		}

		public static string Script(this HtmlHelper helper, string script)
		{
			return Script(helper, script, null);
		}

		public static string Script(this HtmlHelper helper, string debugScript, string releaseScript)
		{
			string script = null;

#if DEBUG
			script = debugScript;
#else
			script = (!string.IsNullOrEmpty(releaseScript)) ? releaseScript : debugScript;
#endif

			TagElement tag = TagElementBuilder.Create("script");
			tag.Attributes.AppendAttribute("type", "text/javascript")
				.AppendAttribute("language", "javascript")
				.AppendAttribute("src", script);

			return tag.ToHtmlString();
		}
	}
}
