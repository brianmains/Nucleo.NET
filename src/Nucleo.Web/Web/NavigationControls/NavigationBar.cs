using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.NavigationControls.ClientSettings;


namespace Nucleo.Web.NavigationControls
{
	[
	WebScriptMetadata(typeof(NavigationBarScriptMetadata)),
	WebLegacyRenderer(typeof(NavigationBarRenderer))
	]
	public class NavigationBar : BaseAjaxControl
	{
		private NavigationBarClientEvents _barClientEvents = null;
		public string _name = null;
		private NavigationBarContainer _owner = null;
		private NavigationBarItem _selectedItem = null;
		


		#region " Properties "

		/// <summary>
		/// Represents the navigation bar client-side events for the bar itself.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public NavigationBarClientEvents BarClientEvents
		{
			get
			{
				if (_barClientEvents == null)
					_barClientEvents = new NavigationBarClientEvents();
				return _barClientEvents;
			}
		}

		/// <summary>
		/// Gets the items that belong to the bar, that makeup the bar interface.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public NavigationBarItemCollection Items
		{
			get { return (NavigationBarItemCollection)this.Controls; }
		}

		/// <summary>
		/// Gets or sets the name of the navigation bar.
		/// </summary>
		public string Name
		{
			get { return (string)ViewState["Name"]; }
			set { ViewState["Name"] = value; }
		}

		/// <summary>
		/// Gets the selected item.  May be null.
		/// </summary>
		public NavigationBarItem SelectedItem
		{
			get { return _selectedItem; }
		}

		#endregion



		#region " Methods "

		protected override void AddedControl(Control control, int index)
		{
			NavigationBarItem item = (NavigationBarItem)control;
			item.SetOwner(this);

			if (item.IsSelected)
			{
				if (_selectedItem != null)
					_selectedItem.IsSelected = false;

				_selectedItem = item;
			}

			item.Selected += new EventHandler(NavigationBarItem_Selected);
			
			base.AddedControl(control, index);
		}

		protected override void AddScriptComponents()
		{
			base.AddScriptComponents();

			if (_barClientEvents != null)
				this.ScriptComponents.Add(_barClientEvents);
		}

		/// <summary>
		/// Clears all of the selections from the bar.  This makes the selected bar item null.
		/// </summary>
		public void ClearSelections()
		{
			for (int index = 0, len = this.Items.Count; index < len; index++)
				this.Items[index].IsSelected = false;
			_selectedItem = null;
		}

		protected override ControlCollection CreateControlCollection()
		{
			return new NavigationBarItemCollection(this);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(NavigationBar), this.ClientID));
			if (_owner != null)
				descriptor.AddComponentProperty("container", _owner.ClientID);
			descriptor.AddPropertyIfExists("name", this.Name);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			registrar.AddCssReference(new CssReferenceRequestDetails(
				this.Page.ClientScript.GetWebResourceUrl(this.GetType(),
					"Nucleo.Web.ContentControls.NavigationBarStyles.css")));
		}

		protected override void RemovedControl(Control control)
		{
			NavigationBarItem item = (NavigationBarItem)control;

			item.SetOwner(null);
			item.Selected -= new EventHandler(NavigationBarItem_Selected);
			base.RemovedControl(control);
		}

		internal void SetOwner(NavigationBarContainer owner)
		{
			_owner = owner;
		}

		#endregion



		#region " Event Handlers "

		void NavigationBarItem_Selected(object sender, EventArgs e)
		{
			if (_selectedItem != null)
				_selectedItem.IsSelected = false;

			_selectedItem = (NavigationBarItem)sender;
		}

		#endregion
	}
}
