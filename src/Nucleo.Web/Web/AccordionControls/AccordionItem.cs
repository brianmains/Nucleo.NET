using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.Web.AccordionControls.ClientSettings;


namespace Nucleo.Web.AccordionControls
{
	[
	WebLegacyRenderer(typeof(AccordionItemRenderer)),
	WebScriptMetadata(typeof(AccordionItemScriptMetadata))
	]
	public class AccordionItem : BaseAjaxControl
	{
		private AccordionItemClientEvents _accordionEvents = null;
		private Accordion _accordion = null;
		private ITemplate _content = null;



		#region " Events "

		/// <summary>
		/// Fires when the accordion item is selected.
		/// </summary>
		public event EventHandler Selected;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the events related to the accordion features.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public AccordionItemClientEvents AccordionEvents
		{
			get
			{
				if (_accordionEvents == null)
					_accordionEvents = new AccordionItemClientEvents();

				return _accordionEvents;
			}
			set { _accordionEvents = value; }
		}

		/// <summary>
		/// Gets the accordion that's the parent to the item.
		/// </summary>
		public Accordion Accordion
		{
			get { return _accordion; }
			internal set { _accordion = value; }
		}

		/// <summary>
		/// Gets the content of the accordion item.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ITemplate Content
		{
			get { return _content; }
			set { _content = value; }
		}

		/// <summary>
		/// Gets or sets whether the accordion is currently selected.
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

		public string Title
		{
			get { return (string)ViewState["Title"]; }
			set { ViewState["Title"] = value; }
		}

		#endregion



		#region " Constructors "

		public AccordionItem() { }

		public AccordionItem(string title, ITemplate content)
		{
			this.Title = title;
			this.Content = content;
		}

		#endregion



		#region " Methods "

		protected override void AddScriptComponents()
		{
			this.ScriptComponents.Add(this.AccordionEvents);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(AccordionItem), this.ClientID));

			descriptor.AddComponentProperty("accordion", this.Accordion.ClientID);
			descriptor.AddPropertyIfExists("isSelected", this.IsSelected);
			descriptor.AddPropertyIfExists("title", this.Title);
			descriptor.AddPropertyIfExists("content", this.GetTemplateContent());
		}

		public string GetTemplateContent()
		{
			Label label = new Label();
			return ControlRendering.GetTemplateMarkup(label, this.Content);
		}

		protected override void LoadClientState(ClientState.ClientStateData stateData)
		{
			base.LoadClientState(stateData);

			if (stateData.Values.ContainsKey("isSelected"))
				this.IsSelected = (bool)stateData.Values["isSelected"];
		}

		protected override bool OnBubbleEvent(object source, EventArgs args)
		{
			if (args is CommandEventArgs)
			{
				AccordionItemEventArgs e = new AccordionItemEventArgs(this, ((CommandEventArgs)args).CommandName, ((CommandEventArgs)args).CommandArgument);
				this.RaiseBubbleEvent(source, args);
				return true;
			}

			return false;
		}

		protected virtual void OnSelected(EventArgs e)
		{
			if (Selected != null)
				Selected(this, e);
		}

		protected internal void SelectInternal()
		{
			ViewState["IsSelected"] = true;
		}

		#endregion
	}
}
