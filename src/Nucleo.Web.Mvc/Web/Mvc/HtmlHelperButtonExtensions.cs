using System;
using System.Web.UI.WebControls;
using System.Web.Mvc;

using Nucleo.ObjectModel;
using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc
{
	public static class HtmlHelperButtonExtensions
	{
		#region " Methods "

		public static TagElement ImageButton(this HtmlHelper html, string name, string imageUrl)
		{
			TagElement element = TagElementBuilder.Create("INPUT");
			element.Attributes.AppendAttribute("type", "image")
				.AppendAttribute("src", imageUrl);

			return element;
		}

		public static TagElement ImageButton(this HtmlHelper html, string name, string imageUrl, object attributes)
		{
			TagElement element = TagElementBuilder.Create("INPUT");
			element.Attributes.AppendAttribute("type", "image")
				.AppendAttribute("src", imageUrl)
				.AppendAttribute("name", name);

			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);
			element.Attributes.CopyFrom(reader.Attributes);

			return element;
		}

		public static TagElement InputButton(this HtmlHelper html, string name, string value, bool useSubmit)
		{
			return InputButton(html, name, value, useSubmit, null);
		}

		public static TagElement InputButton(this HtmlHelper html, string name, string value, bool useSubmit, object attributes)
		{
			TagElement element = TagElementBuilder.Create("INPUT");
			element.Attributes.AppendAttribute("type", (useSubmit) ? "submit" : "button")
				.AppendAttribute("value", value)
				.AppendAttribute("name", name);

			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);
			element.Attributes.CopyFrom(reader.Attributes);

			return element;
		}

		public static TagElement LinkButton(this HtmlHelper html, string name, string value)
		{
			return LinkButton(html, name, value, null);
		}

		public static TagElement LinkButton(this HtmlHelper html, string name, string value, object attributes)
		{
			TagElement element = TagElementBuilder.Create("A");
			element.Attributes.AppendAttribute("name", name);

			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);
			element.Attributes.CopyFrom(reader.Attributes);

			return element;
		}

		#endregion
	}
}
