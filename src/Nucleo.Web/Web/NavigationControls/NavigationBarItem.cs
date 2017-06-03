using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.NavigationControls.ClientSettings;
using Nucleo.Web.Templates;


namespace Nucleo.Web.NavigationControls
{
	[
	WebScriptMetadata(typeof(NavigationBarItemScriptMetadata)),
	WebLegacyRenderer(typeof(NavigationBarItemRenderer))
	]
	public class NavigationBarItem : BaseAjaxControl, IPostBackEventHandler
	{
		private ControlElementTemplate _content = null;
		private bool _isSelected = false;
		private NavigationBarItemClientEvents _itemClientEvents = null;
		private NavigationBar _owner = null;
		private string _text = null;



		#region " Events "

		public event EventHandler Selected;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the content for the template.s  This content template uses the element template implementation approach.  This object provides both a client-side template (for client-only rendering) and a server side template (for server-side and client/server rendering).
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		MergableProperty(false)
		]
		public ControlElementTemplate Content
		{
			get { return _content; }
			set { _content = value; }
		}

		/// <summary>
		/// Gets the events that occur for a navigation bar item.  These events are client-side only.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		MergableProperty(false)
		]
		public NavigationBarItemClientEvents ItemClientEvents
		{
			get
			{
				if (_itemClientEvents == null)
					_itemClientEvents = new NavigationBarItemClientEvents();
				return _itemClientEvents;
			}
		}

		/// <summary>
		/// Gets or sets whether the navigation bar is selected.  Propogates up to the <see cref="NavigationBar">NavigationBar control</see>.
		/// </summary>
		public bool IsSelected
		{
			get { return (bool)(ViewState["IsSelected"] ?? false); }
			set
			{
				ViewState["IsSelected"] = value;

				if (value)
					this.OnSelected(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets or sets the text for the navigation bar item.  Items can use either a template or text.
		/// </summary>
		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void AddScriptComponents()
		{
			base.AddScriptComponents();

			if (_itemClientEvents != null)
				this.ScriptComponents.Add(_itemClientEvents);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(NavigationBarItem), this.ClientID));
			descriptor.AddComponentProperty("bar", this.Parent.ClientID);
			descriptor.AddPropertyIfExists("text", this.Text);

			if (this.IsSelected)
				descriptor.AddProperty("isSelected", this.IsSelected);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			registrar.AddCssReference(new CssReferenceRequestDetails(
				this.Page.ClientScript.GetWebResourceUrl(this.GetType(),
				"Nucleo.Web.NavigationControls.NavigationBarStyles.css")));
		}

		/// <summary>
		/// Fires the Selected event.
		/// </summary>
		/// <param name="e">The details about the event.</param>
		protected virtual void OnSelected(EventArgs e)
		{
			if (Selected != null)
				Selected(this, e);
		}

		/// <summary>
		/// If the item was clicked, selects the item.
		/// </summary>
		/// <param name="eventArgument">The event argument information.</param>
		public void RaisePostBackEvent(string eventArgument)
		{
			//If user clicked on the client, select it
			if (eventArgument == "Click")
				this.IsSelected = true;
		}

		internal void SetOwner(NavigationBar owner)
		{
			_owner = owner;
		}

		#endregion
	}
}
