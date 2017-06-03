using System;
using System.Web.UI;
using System.Web.Script.Serialization;


namespace Nucleo.Web
{
	public class ScriptDescriptorWrapper : IDescriptor, IElementDescriptor
	{
		private ScriptComponentDescriptor _descriptor = null;



		#region " Properties "

		public string ClientID
		{
			get { return this.Descriptor.ClientID; }
		}

		public ScriptComponentDescriptor Descriptor
		{
			get { return _descriptor; }
		}

		public string ElementID
		{
			get
			{
				if (this.Descriptor is ScriptBehaviorDescriptor)
					return ((ScriptBehaviorDescriptor)this.Descriptor).ElementID;
				else if (this.Descriptor is ScriptControlDescriptor)
					return ((ScriptControlDescriptor)this.Descriptor).ElementID;
				else
					return null;
			}
		}

		/// <summary>
		/// Gets whether the descriptor is for a control.
		/// </summary>
		public bool IsControlDescriptor
		{
			get { return (this.Descriptor is ScriptControlDescriptor); }
		}

		/// <summary>
		/// Gets whether the descriptor is for a behavior/extender.
		/// </summary>
		public bool IsExtenderDescriptor
		{
			get { return (this.Descriptor is ScriptBehaviorDescriptor); }
		}

		public string Type
		{
			get { return this.Descriptor.Type; }
			set { this.Descriptor.Type = value; }
		}

		public void AddCollectionProperty(string name, object collection, System.Web.Script.Serialization.JavaScriptConverter converter)
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

		public void AddComponentProperty(string name, string componentID)
		{
			this.Descriptor.AddComponentProperty(name, componentID);
		}

		public void AddElementProperty(string name, string elementID)
		{
			this.Descriptor.AddElementProperty(name, elementID);
		}

		public void AddEvent(string name, string handler)
		{
			this.Descriptor.AddEvent(name, handler);
		}

		public void AddEventIfExists(string name, string handler)
		{
			if (!string.IsNullOrEmpty(handler))
				this.AddEvent(name, handler);
		}

		public void AddProperty(string name, object value)
		{
			this.Descriptor.AddProperty(name, value);
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
			this.Descriptor.AddScriptProperty(name, script);
		}

		public void AddStyleProperty(System.Web.UI.Control control, string name, System.Web.UI.WebControls.Style style)
		{
			if (style == null)
			{
				this.AddProperty(name, null);
				return;
			}

			CssStyleCollection cssList = style.GetStyleAttributes(control);
			this.AddProperty(name, cssList.Value);
		}

		#endregion



		#region " Constructors "

		public ScriptDescriptorWrapper(ScriptComponentDescriptor descriptor)
		{
			if (descriptor == null)
				throw new ArgumentNullException("descriptor");

			_descriptor = descriptor;
		}

		#endregion



		#region " Methods "

		public T ToDescriptor<T>()
			where T : ScriptComponentDescriptor
		{
			return (T)_descriptor;
		}

		#endregion
	}
}
