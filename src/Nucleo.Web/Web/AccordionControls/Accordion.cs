using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Generic;

using Nucleo.EventArguments;
using Nucleo.Web;
using Nucleo.Web.ClientRegistration;
using Nucleo.Web.AccordionControls.ClientSettings;


namespace Nucleo.Web.AccordionControls
{
	[
	WebLegacyRenderer(typeof(AccordionRenderer)),
	WebScriptMetadata(typeof(AccordionScriptMetadata))
	]
	public class Accordion : BaseAjaxControl
	{
		private AccordionClientEvents _accordionEvents = null;
		private AccordionItem _selectedItem = null;



		#region " Events "

		public event AccordionItemEventHandler ItemCommand;

		/// <summary>
		/// Fires when the selected item has changed.
		/// </summary>
		public event DataEventHandler<AccordionItem> SelectedItemChanged;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the client events for the accordion.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public AccordionClientEvents AccordionEvents
		{
			get
			{
				if (_accordionEvents == null)
					_accordionEvents = new AccordionClientEvents();
				return _accordionEvents;
			}
			set { _accordionEvents = value; }
		}

		/// <summary>
		/// Gets the accordion items.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public AccordionItemCollection Items
		{
			get { return (AccordionItemCollection)base.Controls; }
		}

		/// <summary>
		/// Gets the selected item of the accordion.
		/// </summary>
		[ClientProperty("selectedItem", "SelectedItem")]
		public AccordionItem SelectedItem
		{
			get { return _selectedItem; }
			set 
			{
				if (_selectedItem != value)
				{
					this.Items.ClearSelection();
					_selectedItem = value;
				}

				if (_selectedItem != null && !_selectedItem.IsSelected)
					_selectedItem.SelectInternal();
			}
		}

		#endregion



		#region " Methods "

		protected override void AddedControl(Control control, int index)
		{
			AccordionItem item = (AccordionItem)control;
			item.Accordion = this;

			if (item.IsSelected)
			{
				if (this.SelectedItem != null)
					this.SelectedItem.IsSelected = false;

				this.SelectedItem = item;
			}

			item.Selected += new EventHandler(AccordionItem_Selected);

			base.AddedControl(control, index);
		}

		protected override void AddScriptComponents()
		{
			this.ScriptComponents.Add(this.AccordionEvents);
		}

		protected override ControlCollection CreateControlCollection()
		{
			return new AccordionItemCollection(this);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(Accordion), this.ClientID));

			//descriptor.AddPropertyIfExists("items", this.Items);
			//descriptor.AddPropertyIfExists("selectedItem", this.SelectedItem);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			registrar.AddCssReference(new CssReferenceRequestDetails(
				Page.ClientScript.GetWebResourceUrl(this.GetType(), "Nucleo.Web.CommonStyles.css")));
		}

		protected override bool OnBubbleEvent(object source, EventArgs args)
		{
			if (args is AccordionItemEventArgs)
			{
				this.OnItemCommand((AccordionItemEventArgs)args);
				return true;
			}

			return false;
		}

		protected virtual void OnItemCommand(AccordionItemEventArgs e)
		{
			if (ItemCommand != null)
				ItemCommand(this, e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.SelectedItem == null && this.Items.Count > 0)
				this.SelectedItem = this.Items[0];
		}

		/// <summary>
		/// Fires the <see cref="SelectedItemChanged"/> event.
		/// </summary>
		/// <param name="e">The details of the event.</param>
		protected virtual void OnSelectedItemChanged(DataEventArgs<AccordionItem> e)
		{
			if (SelectedItemChanged != null)
				SelectedItemChanged(this, e);
		}

		protected override void RemovedControl(Control control)
		{
			AccordionItem item = (AccordionItem)control;
			item.Accordion = this;

			if (item.IsSelected)
			{
				if (this.Items.Count > 0)
					this.SelectedItem = this.Items[0];
			}

			item.Selected -= new EventHandler(AccordionItem_Selected);

			base.RemovedControl(control);
		}

		#endregion



		#region " Event Handlers "

		/// <summary>
		/// Handles the change of the selection.
		/// </summary>
		/// <param name="sender">The accordion item.</param>
		/// <param name="e">Empty.</param>
		void AccordionItem_Selected(object sender, EventArgs e)
		{
			this.Items.ClearSelection();
			_selectedItem = (AccordionItem)sender;
			_selectedItem.SelectInternal();
		}

		#endregion
	}
}