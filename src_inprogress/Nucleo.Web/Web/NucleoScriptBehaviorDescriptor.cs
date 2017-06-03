using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

using Nucleo.Web.Serialization;


namespace Nucleo.Web
{
	public class NucleoScriptBehaviorDescriptor : ScriptBehaviorDescriptor, IDescriptor, IElementDescriptor
	{
		#region " Constructors "

		public NucleoScriptBehaviorDescriptor(string type, string elementID)
			: base(type, elementID) { }

		#endregion



		#region " Methods "

		public void AddCollectionProperty(string name, object collection, JavaScriptConverter converter)
		{
			if (collection == null)
			{
				this.AddProperty(name, null);
				return;
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { converter });
			this.AddProperty(name, serializer.Serialize(collection));
		}

		public void AddCollectionProperty<CT, IT>(string name, CT collection)
			where CT : class, ICollection<IT>
			where IT : class
		{
			if (collection == null)
			{
				this.AddProperty(name, null);
				return;
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new GenericCollectionJavaScriptConverter<CT, IT>() });

			this.AddProperty(name, serializer.Serialize(collection));
		}

		/// <summary>
		/// Adds the component if values have been supplied.
		/// </summary>
		/// <param name="name">The name of the property to supply the element to.</param>
		/// <param name="componentID">The ID of the component.</param>
		public void AddComponentPropertyIfExists(string name, string componentID)
		{
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(componentID))
				this.AddComponentProperty(name, componentID);
		}

		/// <summary>
		/// Adds the element matching if values have been supplied.
		/// </summary>
		/// <param name="name">The name of the property to supply the element to.</param>
		/// <param name="elementID">The ID of the element.</param>
		public void AddElementPropertyIfExists(string name, string elementID)
		{
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(elementID))
				this.AddElementProperty(name, elementID);
		}

		public void AddEventIfExists(string name, string handler)
		{
			if (!string.IsNullOrEmpty(handler))
				this.AddEvent(name, handler);
		}

		public void AddProperty(string name, object value, JavaScriptConverter converter)
		{
			if (value == null)
			{
				this.AddProperty(name, null);
				return;
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { converter });

			this.AddProperty(name, serializer.Serialize(value));
		}

		public void AddPropertyIfExists(string name, object value)
		{
			if (value == null)
				return;
			if ((value is string) && (value == ""))
				return;

			this.AddProperty(name, value);
		}

		public void AddStyleProperty(Control control, string name, Style style)
		{
			if (style == null)
			{
				this.AddProperty(name, null);
				return;
			}

			CssStyleCollection cssList = style.GetStyleAttributes(control);
			this.AddProperty(name, cssList.Value);
		}

		protected override string GetScript()
		{
			string script = base.GetScript().Substring(7);
			script = "Nucleo.$create" + script;

			return script;
		}

		#endregion
	}
}
