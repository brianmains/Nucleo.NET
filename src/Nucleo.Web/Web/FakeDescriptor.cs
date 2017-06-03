using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;


namespace Nucleo.Web
{
	public class FakeDescriptor : ScriptComponentDescriptor, IDescriptor
	{
		private Dictionary<string, object> _references = null;



		#region " Properties "

		public string ID
		{
			get { return base.ClientID; }
		}

		public Dictionary<string, object> References
		{
			get
			{
				if (_references == null)
					_references = new Dictionary<string, object>();
				return _references;
			}
		}

		#endregion



		#region " Constructors "

		public FakeDescriptor()
			: base("FakeType") { }

		public FakeDescriptor(string type) 
			: base(type) { }

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

		new public void AddComponentProperty(string name, string componentID)
		{
			base.AddComponentProperty(name, componentID);
			this.References.Add(name, componentID);
		}

		new public void AddElementProperty(string name, string elementID)
		{
			base.AddElementProperty(name, elementID);
			this.References.Add(name, elementID);
		}

		public void AddEvent(string name, string handler)
		{
			base.AddEvent(name, handler);
			this.References.Add(name, handler);
		}

		public void AddEventIfExists(string name, string handler)
		{
			if (!string.IsNullOrEmpty(handler))
				this.AddEvent(name, handler);
		}

		public void AddProperty(string name, object value)
		{
			base.AddProperty(name, value);
			this.References.Add(name, value);
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

		public void AddScriptProperty(string name, string script)
		{
			base.AddScriptProperty(name, script);
			this.References.Add(name, script);
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

		public string GetDescriptorScript()
		{
			return base.GetScript();
		}

		#endregion
	}
}
