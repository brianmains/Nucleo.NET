using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.ListControls
{
	[TargetControlType(typeof(CheckBoxList))]
	public class ClientCheckboxList : CheckBoxList, IScriptControl
	{
		#region " Properties "

		/// <summary>
		/// Gets the index for the item in the collection, which is active (not necessarily selected).
		/// </summary>
		public int ActiveIndex
		{
			get { return (int)(ViewState["ActiveIndex"] ?? -1); }
			set { ViewState["ActiveIndex"] = value; }
		}

		/// <summary>
		/// Gets the unique ID to use for client state.
		/// </summary>
		private string NewItemClientStateID
		{
			get { return this.ID + "_NewItemsHidden"; }
		}

		/// <summary>
		/// Gets or sets a client method to receive a call to the all items selected event.
		/// </summary>
		public string OnClientAllItemsSelected
		{
			get
			{
				object o = ViewState["OnClientAllItemsSelected"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["OnClientAllItemsSelected"] = value; }
		}

		/// <summary>
		/// Gets or sets a client method to receive a call to the item selected event.
		/// </summary>
		public string OnClientItemSelected
		{
			get { return (string)(ViewState["OnClientItemSelected"] ?? null); }
			set { ViewState["OnClientItemSelected"] = value; }
		}

		/// <summary>
		/// Gets or sets a client method to receive a call to the all item toggled event.
		/// </summary>
		public string OnClientItemToggled
		{
			get { return (string)(ViewState["OnClientItemToggled"] ?? null); }
			set { ViewState["OnClientItemToggled"] = value; }
		}

		/// <summary>
		/// Gets or sets a client method to receive a call to the no items selected event.
		/// </summary>
		public string OnClientNoItemsSelected
		{
			get
			{
				object o = ViewState["OnClientNoItemsSelected"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["OnClientNoItemsSelected"] = value; }
		}

		private string RemovedItemClientStateID
		{
			get { return this.ClientID + "_RemovedItemsHidden"; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a new item to be queued up for insertion; concatenated string 
		/// </summary>
		/// <param name="value">The text value to add.</param>
		private void AddClientItem(string value)
		{
			if (string.IsNullOrEmpty(value))
				return;

			string[] items = value.Split('$');
			ListItem item = new ListItem();
			if (items.Length > 0)
				item.Text = items[0];
			if (items.Length > 1)
				item.Value = items[1];
			if (items.Length > 2)
			{
				bool boolValue;
				item.Selected = bool.TryParse(items[2], out boolValue) ? boolValue : true;
			}
			if (items.Length > 3)
			{
				bool boolValue;
				item.Enabled = bool.TryParse(items[3], out boolValue) ? boolValue : true;
			}

			this.Items.Add(value);
		}

		public System.Collections.Generic.IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor("Nucleo.Web.ListControls.ClientCheckboxList", this.ClientID);
			descriptor.AddProperty("activeIndex", this.ActiveIndex);
			descriptor.AddProperty("selectedIndex", this.SelectedIndex);
			descriptor.AddElementProperty("newItemsClientState", this.NewItemClientStateID);
			descriptor.AddElementProperty("removedItemsClientState", this.RemovedItemClientStateID);

			descriptor.AddEvent("allItemsSelected", this.OnClientAllItemsSelected);
			descriptor.AddEvent("noItemsSelected", this.OnClientNoItemsSelected);
			descriptor.AddEvent("itemSelected", this.OnClientItemSelected);
			descriptor.AddEvent("itemToggled", this.OnClientItemToggled);
			return new ScriptDescriptor[] { descriptor };
		}

		System.Collections.Generic.IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
		{
			return GetScriptDescriptors();
		}

		public System.Collections.Generic.IEnumerable<ScriptReference> GetScriptReferences()
		{
			ScriptReference reference = new ScriptReference();
			if (this.Page != null)
				reference.Path = Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.ListControls.ClientCheckboxList.js");

			return new ScriptReference[] { reference };
		}

		System.Collections.Generic.IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
		{
			return GetScriptReferences();
		}

		protected virtual void LoadNewItems(string newItemsClientState)
		{
			if (string.IsNullOrEmpty(newItemsClientState))
				return;

			string[] newItems = newItemsClientState.Split(';');
			foreach (string newItem in newItems)
				this.AddClientItem(newItem);
		}

		protected override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			this.LoadNewItems(postCollection[this.NewItemClientStateID]);
			this.LoadRemovedItems(postCollection[this.RemovedItemClientStateID]);
			return false;
		}

		protected virtual void LoadRemovedItems(string removedItemsClientState)
		{
			if (string.IsNullOrEmpty(removedItemsClientState))
				return;

			string[] removedItems = removedItemsClientState.Split(';');
			foreach (string removedItem in removedItems)
				this.RemoveClientItem(removedItem);
		}

		protected override void OnPreRender(EventArgs e)
		{
			ScriptManager manager = ScriptManager.GetCurrent(this.Page);
			manager.RegisterScriptControl<ClientCheckboxList>(this);

			base.OnPreRender(e);

			base.EnsureID();
			ScriptManager.RegisterHiddenField(this, this.NewItemClientStateID, string.Empty);
			ScriptManager.RegisterHiddenField(this, this.RemovedItemClientStateID, string.Empty);
		}

		private void RemoveClientItem(string removedItem)
		{
			this.Items.Remove(this.Items.FindByValue(removedItem));
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (!base.DesignMode)
			{
				ScriptManager manager = ScriptManager.GetCurrent(this.Page);
				manager.RegisterScriptDescriptors(this);
			}

			base.Render(writer);
		}

		#endregion
	}
}
