using System;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Web.Description
{
	/// <summary>
	/// Represents a descriptor to describe a component.
	/// </summary>
	public class ComponentDescriptor
	{
		private string _clientType = null;
		private string _componentType = null;
		private ControlDescriptionCollection _controls = null;
		private ElementDescriptionCollection _elements = null;
		private EventDescriptionCollection _events = null;
		private ExtenderDescriptionCollection _extenders = null;
		private PropertyDescriptionCollection _properties = null;

		

		#region " Properties "

		/// <summary>
		/// Gets the type created in client-side JavaScript.
		/// </summary>
		public string ClientType
		{
			get { return _clientType; }
		}

		/// <summary>
		/// Gets or sets the type of component this descriptor is for; this can be useful in distinguising types of objects.  For instance, it can differentate between an AJAX page class or a widget.
		/// </summary>
		public string ComponentType
		{
			get { return _componentType; }
			set { _componentType = value; }
		}

		private ControlDescriptionCollection Controls
		{
			get
			{
				if (_controls == null)
					_controls = new ControlDescriptionCollection();
				return _controls;
			}
		}

		private ElementDescriptionCollection Elements
		{
			get
			{
				if (_elements == null)
					_elements = new ElementDescriptionCollection();
				return _elements;
			}
		}

		private EventDescriptionCollection Events
		{
			get
			{
				if (_events == null)
					_events = new EventDescriptionCollection();
				return _events;
			}
		}

		private ExtenderDescriptionCollection Extenders
		{
			get
			{
				if (_extenders == null)
					_extenders = new ExtenderDescriptionCollection();
				return _extenders;
			}
		}

		/// <summary>
		/// Gets whether there are any controls added.
		/// </summary>
		public bool HasControls
		{
			get { return this.Controls.Count > 0; }
		}

		/// <summary>
		/// Gets whether there are any elements added.
		/// </summary>
		public bool HasElements
		{
			get { return this.Elements.Count > 0; }
		}

		/// <summary>
		/// Gets whether there are any events added.
		/// </summary>
		public bool HasEvents
		{
			get { return this.Events.Count > 0; }
		}

		/// <summary>
		/// Gets whether there are any extenders added.
		/// </summary>
		public bool HasExtenders
		{
			get { return this.Extenders.Count > 0; }
		}

		/// <summary>
		/// Gets whether there are any properties added.
		/// </summary>
		public bool HasProperties
		{
			get { return this.Properties.Count > 0; }
		}

		private PropertyDescriptionCollection Properties
		{
			get 
			{
				if (_properties == null)
					_properties = new PropertyDescriptionCollection();
				return _properties; 
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the descriptor with the client type.
		/// </summary>
		/// <param name="clientType">The type of client-side component.</param>
		public ComponentDescriptor(string clientType)
		{
			_clientType = clientType;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the entire collection of controls.
		/// </summary>
		/// <returns>The collection.</returns>
		public ControlDescriptionCollection GetControls()
		{
			return this.Controls;
		}

		/// <summary>
		/// Gets the entire collection of elements.
		/// </summary>
		/// <returns>The collection.</returns>
		public ElementDescriptionCollection GetElements()
		{
			return this.Elements;
		}

		/// <summary>
		/// Gets the entire collection of events.
		/// </summary>
		/// <returns>The collection.</returns>
		public EventDescriptionCollection GetEvents()
		{
			return this.Events;
		}

		/// <summary>
		/// Gets the entire collection of extenders.
		/// </summary>
		/// <returns>The collection.</returns>
		public ExtenderDescriptionCollection GetExtenders()
		{
			return this.Extenders;
		}

		/// <summary>
		/// Gets the entire collection of properties.
		/// </summary>
		/// <returns>The collection.</returns>
		public PropertyDescriptionCollection GetProperties()
		{
			return this.Properties;
		}

		/// <summary>
		/// Returns the registration script for the component using the Microsoft way of formatting ID requests.
		/// </summary>
		/// <returns>The script to create the component on the client side.</returns>
		public virtual string GetScript()
		{
			return this.GetScript(new MSScriptIDFormatter());
		}

		/// <summary>
		/// Returns the registration script using a specified <see cref="IScriptIDFormatter">ID formatter of type IScriptIDFormatter</see>.
		/// </summary>
		/// <param name="idFormatter">The type of formatting to use when requesting ID's.</param>
		/// <returns>The script to create the component on the client side.</returns>
		public virtual string GetScript(IScriptIDFormatter idFormatter)
		{
			string script = "{ clientType: new " + this.ClientType + "(), ";

			if (this.HasProperties)
				script += "properties:" + this.Properties.GetScript() + ", ";
			if (this.HasEvents)
				script += "events:" + this.Events.GetScript() + ", ";
			if (this.HasElements)
				script += "elements:" + this.Elements.GetScript(idFormatter) + ", ";
			if (this.HasControls)
				script += "controls:" + this.Controls.GetScript(idFormatter) + ", ";
			if (this.HasExtenders)
				script += "extenders:" + this.Extenders.GetScript(idFormatter) + ", ";

			return script.Substring(0, script.Length - 2) + " }";
		}

		/// <summary>
		/// Registers a new control to the underlying collection.
		/// </summary>
		/// <param name="name">The unique name to register with.</param>
		/// <param name="control">The control.</param>
		/// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
		/// <exception cref="Exception">Thrown when the control already exists in the collection with the same name.</exception>
		public void RegisterControl(string name, IScriptControl control)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (this.Controls.ContainsKey(name))
				throw new Exception("The control has an existing control with that name.");

			this.Controls.Add(name, control);
		}

		/// <summary>
		/// Registers a new element to the underlying collection.
		/// </summary>
		/// <param name="name">The unique name to register with.</param>
		/// <param name="elementName">The name of the element.</param>
		/// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
		/// <exception cref="Exception">Thrown when the element already exists in the collection with the same name.</exception>
		public void RegisterElement(string name, string elementName)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (this.Elements.ContainsKey(name))
				throw new Exception("The element has an existing element with that name.");

			this.Elements.Add(name, elementName);
		}

		/// <summary>
		/// Registers a new event/handler to the underlying collection.
		/// </summary>
		/// <param name="name">The unique name to register with.</param>
		/// <param name="handler">The JS client-side handler of the event.</param>
		/// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
		/// <exception cref="Exception">Thrown when the event already exists in the collection with the same name.</exception>
		public void RegisterEvent(string name, string handler)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (this.Events.ContainsKey(name))
				throw new Exception("The event has already attached a handler.");

			this.Events.Add(name, handler);
		}

		/// <summary>
		/// Registers a new extender to the underlying collection.
		/// </summary>
		/// <param name="name">The unique name to register with.</param>
		/// <param name="control">The extender control.</param>
		/// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
		/// <exception cref="Exception">Thrown when the extender already exists in the collection with the same name.</exception>
		public void RegisterExtender(string name, IExtenderControl control)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (this.Extenders.ContainsKey(name))
				throw new Exception("The control has an existing control with that name.");

			this.Extenders.Add(name, control);
		}

		/// <summary>
		/// Registers a new property to the underlying collection.
		/// </summary>
		/// <param name="name">The unique name to register with.</param>
		/// <param name="value">The property value.</param>
		/// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
		/// <exception cref="Exception">Thrown when the property already exists in the collection with the same name.</exception>
		public void RegisterProperty(string name, object value)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (this.Properties.ContainsKey(name))
				throw new Exception("The property already has been registered.");

			this.Properties.Add(name, value);
		}

		#endregion
	}
}
