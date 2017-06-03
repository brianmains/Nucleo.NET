using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Web.Tags
{
	public static class TagElementExtensions
	{
		public static TagElement AddAttribute(this TagElement element, string key, object value)
		{
			element.Attributes.AppendAttribute(key, value);
			return element;
		}

		public static TagElement AddChild(this TagElement element, TagElement child)
		{
			element.Children.AppendTag(child);
			return element;
		}

		public static TagElement AddChildren(this TagElement element, params TagElement[] children)
		{
			element.Children.AppendTags(children);
			return element;
		}

		public static TagElement AddStyle(this TagElement element, string key, object value)
		{
			element.Styles.AppendAttribute(key, value);
			return element;
		}
	}
}
