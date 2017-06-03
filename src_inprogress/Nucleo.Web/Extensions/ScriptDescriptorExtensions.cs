using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Nucleo.Web;
using Nucleo.Web.Serialization;


namespace System.Web.UI
{
	public static class ScriptDescriptorExtensions
	{
#if NET20
		public static void AddCollectionProperty(ScriptComponentDescriptor descriptor, Control control, string name, object collection, JavaScriptConverter converter)
#else
		public static void AddCollectionProperty(this ScriptComponentDescriptor descriptor, Control control, string name, object collection, JavaScriptConverter converter)
#endif
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

#if NET20
		public static void AddCollectionProperty<CT, IT>(ScriptComponentDescriptor descriptor, Control control, string name, CT collection)
#else
		public static void AddCollectionProperty<CT, IT>(this ScriptComponentDescriptor descriptor, Control control, string name, CT collection)
#endif
			where CT : class, ICollection<IT>
			where IT : class
		{
			if (collection == null)
			{
				descriptor.AddProperty(name, null);
				return;
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new GenericCollectionJavaScriptConverter<CT, IT>() });

			descriptor.AddProperty(name, serializer.Serialize(collection));
		}

#if NET20
		public static void AddStyleProperty(ScriptComponentDescriptor descriptor, Control control, string name, Style style)
#else
		public static void AddStyleProperty(this ScriptComponentDescriptor descriptor, Control control, string name, Style style)
#endif
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
