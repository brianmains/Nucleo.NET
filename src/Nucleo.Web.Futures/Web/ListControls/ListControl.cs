using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Web.DataboundControls;
using Nucleo.Web.Serialization;


namespace Nucleo.Web.ListControls
{

	public class ListControl : System.Web.UI.WebControls.ListControl, IScriptControl, IRepeatInfoUser
	{
		private Style _alternatingItemStyle = null;
		private Style _itemSelectedStyle = null;
		private Style _itemStyle = null;
		private Style _itemToggledStyle = null;



		#region " Properties "

		/// <summary>
		/// Gets the style for the alternating item.
		/// </summary>
		public Style AlternatingItemStyle
		{
			get
			{
				if (_alternatingItemStyle == null)
				{
					_alternatingItemStyle = new Style();
					if (((IStateManager)_alternatingItemStyle).IsTrackingViewState)
						((IStateManager)_alternatingItemStyle).TrackViewState();
				}

				return _alternatingItemStyle;
			}
		}

		/// <summary>
		/// Gets or sets the ID of the data source manager control that it will get data from.
		/// </summary>
		public string DataSourceManagerID
		{
			get { return (string)(ViewState["DataSourceManager"] ?? null); }
			set { ViewState["DataSourceManager"] = value; }
		}

		bool IRepeatInfoUser.HasFooter
		{
			get { return false; }
		}

		bool IRepeatInfoUser.HasHeader
		{
			get { return false; }
		}

		bool IRepeatInfoUser.HasSeparators
		{
			get { return false; }
		}

		/// <summary>
		/// Gets or sets the type of list the interface will consist of.
		/// </summary>
		public ListInterfaceType InterfaceType
		{
			get { return (ListInterfaceType)(ViewState["InterfaceType"] ?? ListInterfaceType.CheckboxList); }
			set
			{
				if (value == ListInterfaceType.Custom)
					throw new NotImplementedException("The Custom option will be available in a later release.  This feature is currently not supported.");

				ViewState["InterfaceType"] = value;
			}
		}

		/// <summary>
		/// Gets the style for the item.
		/// </summary>
		public Style ItemStyle
		{
			get
			{
				if (_itemStyle == null)
				{
					_itemStyle = new Style();
					if (((IStateManager)_itemStyle).IsTrackingViewState)
						((IStateManager)_itemStyle).TrackViewState();
				}

				return _itemStyle;
			}
		}

		/// <summary>
		/// Gets the style for the item.
		/// </summary>
		public Style ItemSelectedStyle
		{
			get
			{
				if (_itemSelectedStyle == null)
				{
					_itemSelectedStyle = new Style();
					if (((IStateManager)_itemSelectedStyle).IsTrackingViewState)
						((IStateManager)_itemSelectedStyle).TrackViewState();
				}

				return _itemSelectedStyle;
			}
		}

		/// <summary>
		/// Gets the style for the item.
		/// </summary>
		public Style ItemToggledStyle
		{
			get
			{
				if (_itemToggledStyle == null)
				{
					_itemToggledStyle = new Style();
					if (((IStateManager)_itemToggledStyle).IsTrackingViewState)
						((IStateManager)_itemToggledStyle).TrackViewState();
				}

				return _itemToggledStyle;
			}
		}

		/// <summary>
		/// Gets or sets a client method to receive a call to the all items selected event.
		/// </summary>
		public string OnClientAllItemsSelected
		{
			get { return (string)(ViewState["OnClientAllItemsSelected"] ?? null); }
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

		public RenderMode RenderingMode
		{
			get { return (RenderMode)(ViewState["RenderingMode"] ?? RenderMode.ClientAndServer); }
			set { ViewState["RenderingMode"] = value; }
		}

		/// <summary>
		/// Gets or sets the number of columns to repeat by.
		/// </summary>
		public int RepeatColumnCount
		{
			get { return (int)(ViewState["RepeatColumnCount"] ?? 0); }
			set { ViewState["RepeatColumnCount"] = value; }
		}

		int IRepeatInfoUser.RepeatedItemCount
		{
			get { return this.Items.Count; }
		}

		/// <summary>
		/// Gets or sets the direction to repeat, whether horizontally or vertically.
		/// </summary>
		public System.Web.UI.WebControls.RepeatDirection RepeatingDirection
		{
			get { return (System.Web.UI.WebControls.RepeatDirection)(ViewState["RepeatingDirection"] ?? System.Web.UI.WebControls.RepeatDirection.Horizontal); }
			set { ViewState["RepeatingDirection"] = value; }
		}

		/// <summary>
		/// Gets or sets the layout to repeat, whether a tabular form, or flow form.
		/// </summary>
		public RepeatLayout RepeatingLayout
		{
			get { return (RepeatLayout)(ViewState["RepeatingLayout"] ?? RepeatLayout.Flow); }
			set { ViewState["RepeatingLayout"] = value; }
		}

		#endregion



		#region " Methods "

		Style IRepeatInfoUser.GetItemStyle(ListItemType itemType, int repeatIndex)
		{
			if (repeatIndex % 2 == 0)
				return this.ItemStyle;
			else
				return this.AlternatingItemStyle;
		}

		public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			ScriptControlDescriptor descriptor = new ScriptControlDescriptor("Nucleo.Web.ListControls.ListControl", this.ClientID);
			descriptor.AddStyleProperty(this, "alternatingItemStyle", _alternatingItemStyle);
			descriptor.AddProperty("dataTextField", this.DataTextField);
			descriptor.AddProperty("dataValueField", this.DataValueField);
			descriptor.AddProperty("interfaceType", this.InterfaceType);
			descriptor.AddCollectionProperty(this, "items", this.Items, new ListItemCollectionJavaScriptConverter());
			descriptor.AddStyleProperty(this, "itemSelectedStyle", _itemSelectedStyle);
			descriptor.AddStyleProperty(this, "itemStyle", _itemStyle);
			descriptor.AddStyleProperty(this, "itemToggledStyle", _itemToggledStyle);
			descriptor.AddProperty("renderOnLoad", (this.RenderingMode == RenderMode.ClientOnly));
			descriptor.AddProperty("repeatColumnCount", this.RepeatColumnCount);
			descriptor.AddProperty("repeatingDirection", this.RepeatingDirection);
			descriptor.AddProperty("repeatingLayout", this.RepeatingLayout);
			descriptor.AddProperty("selectedIndex", this.SelectedIndex);

			if (!string.IsNullOrEmpty(this.OnClientAllItemsSelected))
				descriptor.AddEvent("allItemsSelected", this.OnClientAllItemsSelected);
			if (!string.IsNullOrEmpty(this.OnClientNoItemsSelected))
				descriptor.AddEvent("noItemsSelected", this.OnClientNoItemsSelected);
			if (!string.IsNullOrEmpty(this.OnClientItemSelected))
				descriptor.AddEvent("itemSelected", this.OnClientItemSelected);
			if (!string.IsNullOrEmpty(this.OnClientItemToggled))
				descriptor.AddEvent("itemToggled", this.OnClientItemToggled);
			return new ScriptDescriptor[] { descriptor };
		}

		public IEnumerable<ScriptReference> GetScriptReferences()
		{
			List<ScriptReference> references = new List<ScriptReference>();
			references.Add(new ScriptReference(Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.CommonEventArguments.js")));
			references.Add(new ScriptReference(Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.RepeaterInfo.js")));
			references.Add(new ScriptReference(Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.ListControls.ListScripts.js")));
			references.Add(new ScriptReference(Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.ListControls.ListControlBuilder.js")));
			references.Add(new ScriptReference(Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.ListControls.ListControl.js")));

			return references.ToArray();
		}

		protected override void LoadViewState(object savedState)
		{
			if (savedState == null)
			{
				base.LoadViewState(savedState);
				return;
			}

			object[] state = (object[])savedState;
			base.LoadViewState(state[0]);
			if (state[1] != null)
				((IStateManager)this.AlternatingItemStyle).LoadViewState(state[1]);
			if (state[2] != null)
				((IStateManager)this.ItemSelectedStyle).LoadViewState(state[2]);
			if (state[3] != null)
				((IStateManager)this.ItemStyle).LoadViewState(state[3]);
			if (state[4] != null)
				((IStateManager)this.ItemToggledStyle).LoadViewState(state[4]);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			ScriptManager manager = ScriptManager.GetCurrent(this.Page);
			manager.RegisterScriptControl<ListControl>(this);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			ScriptManager manager = ScriptManager.GetCurrent(this.Page);
			manager.RegisterScriptDescriptors(this);

			if (this.RenderingMode == RenderMode.ClientOnly)
			{
				base.AddAttributesToRender(writer);
				writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
				writer.RenderBeginTag(HtmlTextWriterTag.Span);
				writer.RenderEndTag();
			}
			else
			{
				if (this.InterfaceType != ListInterfaceType.DropDownList)
				{
					RepeatInfo repeat = new RepeatInfo();
					repeat.RepeatColumns = this.RepeatColumnCount;
					repeat.RepeatDirection = this.RepeatingDirection;
					repeat.RepeatLayout = this.RepeatingLayout;
					repeat.UseAccessibleHeader = true;
				}
				else
				{
					writer.RenderBeginTag(HtmlTextWriterTag.Select);

					for (int index = 0; index < this.Items.Count; index++)
						((IRepeatInfoUser)this).RenderItem(ListItemType.Item, index, null, writer);

					writer.RenderEndTag(); //select
				}
			}
		}

		void IRepeatInfoUser.RenderItem(ListItemType itemType, int repeatIndex, RepeatInfo repeatInfo, HtmlTextWriter writer)
		{
			if (!(itemType == ListItemType.Item || itemType == ListItemType.AlternatingItem))
				return;

			ListItem item = this.Items[repeatIndex];

			if (this.InterfaceType == ListInterfaceType.CheckboxList)
			{
				CheckBox checkbox = new CheckBox();
				checkbox.Text = item.Text;
				checkbox.Checked = item.Selected;
				checkbox.Enabled = item.Enabled;
				checkbox.RenderControl(writer);
			}
			else if (this.InterfaceType == ListInterfaceType.RadioButtonList)
			{
				RadioButton button = new RadioButton();
				button.Text = item.Text;
				button.Enabled = item.Enabled;
				button.Checked = item.Selected;
				button.GroupName = this.ClientID;
				button.RenderControl(writer);
			}
			else if (this.InterfaceType == ListInterfaceType.DropDownList)
			{
				if (!item.Enabled)
					writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
				writer.AddAttribute(HtmlTextWriterAttribute.Value, item.Value);
				writer.RenderBeginTag(HtmlTextWriterTag.Option);
				writer.Write(item.Text);
				writer.RenderEndTag(); //option
			}
			else
				throw new NotImplementedException();
		}

		protected override object SaveViewState()
		{
			object[] state = new object[5];
			state[0] = base.SaveViewState();
			state[1] = (_alternatingItemStyle != null) ? ((IStateManager)_alternatingItemStyle).SaveViewState() : null;
			state[2] = (_itemSelectedStyle != null) ? ((IStateManager)_itemSelectedStyle).SaveViewState() : null;
			state[3] = (_itemStyle != null) ? ((IStateManager)_itemStyle).SaveViewState() : null;
			state[4] = (_itemToggledStyle != null) ? ((IStateManager)_itemToggledStyle).SaveViewState() : null;

			return state;
		}

		protected override void TrackViewState()
		{
			base.TrackViewState();

			if (_alternatingItemStyle != null)
				((IStateManager)this.AlternatingItemStyle).TrackViewState();
			if (_itemSelectedStyle != null)
				((IStateManager)this.ItemSelectedStyle).TrackViewState();
			if (_itemStyle != null)
				((IStateManager)this.ItemStyle).TrackViewState();
			if (_itemToggledStyle != null)
				((IStateManager)this.ItemToggledStyle).TrackViewState();
		}

		#endregion
	}
}
