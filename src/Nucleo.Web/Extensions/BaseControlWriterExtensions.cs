using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.ObjectModel;


namespace Nucleo.Web
{
	public static class BaseControlWriterExtensions
	{
		#region " Methods "

		public static void WriteBeginTag(this BaseControlWriter writer, string tagName)
		{
			WriteUnclosedBeginTag(writer, tagName);
			writer.Write(">");
		}

		public static void WriteBeginTag(this BaseControlWriter writer, string tagName, string id, string name)
		{
			WriteUnclosedBeginTag(writer, tagName, id, name);
			writer.Write(">");
		}

		public static void WriteBeginTag(this BaseControlWriter writer, string tagName, object attributes)
		{
			WriteUnclosedBeginTag(writer, tagName, attributes);
			writer.Write(">");
		}

		public static void WriteBeginTag(this BaseControlWriter writer, string tagName, object attributes, object styles)
		{
			WriteUnclosedBeginTag(writer, tagName, attributes, styles);
			writer.Write(">");
		}

		public static void WriteEndTag(this BaseControlWriter writer, string tagName)
		{
			writer.Write("</" + tagName + ">");
		}

		public static void WriteUnclosedBeginTag(this BaseControlWriter writer, string tagName)
		{
			writer.Write("<" + tagName);
		}

		public static void WriteUnclosedBeginTag(this BaseControlWriter writer, string tagName, string id, string name)
		{
			writer.Write("<" + tagName);
			if (!string.IsNullOrEmpty(id))
				writer.Write(" id=\"" + id + "\"");
			if (!string.IsNullOrEmpty(name))
				writer.Write(" name=\"" + name + "\"");
		}

		public static void WriteUnclosedBeginTag(this BaseControlWriter writer, string tagName, object attributes)
		{
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);

			writer.Write("<" + tagName);
			if (reader.Attributes.Count > 0)
				writer.Write(" " + reader.Attributes.ToHtmlAttributeString());
		}

		public static void WriteUnclosedBeginTag(this BaseControlWriter writer, string tagName, object attributes, object styles)
		{
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);

			writer.Write("<" + tagName);
			if (reader.Attributes.Count > 0)
				writer.Write(" " + reader.Attributes.ToHtmlAttributeString());

			reader.Attributes.Clear();
			reader.ReadAttributes(styles);
			if (reader.Attributes.Count > 0)
				writer.Write(" style=\"" + reader.Attributes.ToHtmlAttributeString(":", ";", false) + "\"");
		}

		#endregion
	}
}
