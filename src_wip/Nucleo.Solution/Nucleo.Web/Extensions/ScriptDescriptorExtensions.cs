using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Nucleo.Web;


namespace System.Web.UI
{
	public static class ScriptDescriptorExtensions
	{
		public static void AddCollectionProperty(this ScriptComponentDescriptor descriptor, Control control, string name, object collection, JavaScriptConverter converter)
		{
			if (collection == null)
			{
				descriptor.AddProperty(name, null);
				return;
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { converter });

			descriptor.AddProperty(name, serializer.Serialize(collection));
		}

		public static void AddStyleProperty(this ScriptComponentDescriptor descriptor, Control control, string name, Style style)
		{
			if (style == null)
			{
				descriptor.AddProperty(name, null);
				return;
			}

			CssStyleCollection cssList = style.GetStyleAttributes(control);
			descriptor.AddProperty(name, cssList.Value);
		}
	}
}
