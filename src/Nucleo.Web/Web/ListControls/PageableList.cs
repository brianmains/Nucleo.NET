using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Nucleo.Web.ClientRegistration;
using Nucleo.Web.Testing;


namespace Nucleo.Web.ListControls
{
	/// <summary>
	/// Represents a control that can display items and page left/right.
	/// </summary>
	[
	WebLegacyRenderer(typeof(PageableListRenderer)),
	WebScriptMetadata(typeof(PageableListScriptMetadata))
	]
	public class PageableList : BaseAjaxControl, IPostBackEventHandler
	{
		private PageableListPagingOptions _pagingOptions = null;



		#region " Constants "

		/// <summary>
		/// Represents the command to page left.
		/// </summary>
		public const string PageLeftCommandName = "PageLeft";

		/// <summary>
		/// Represents teh command to page right.
		/// </summary>
		public const string PageRightCommandName = "PageRight";

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the current index for the pageable list.
		/// </summary>
		[ClientProperty("currentIndex", 0)]
		public int CurrentIndex
		{
			get { return (int)(ViewState["CurrentIndex"] ?? 0); }
			set { ViewState["CurrentIndex"] = value; }
		}

		/// <summary>
		/// Gets the list of items, which are registered as inner child controls.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public ControlListCollection<PageableListItem> Items
		{
			get { return (ControlListCollection<PageableListItem>)this.Controls; }
		}

		/// <summary>
		/// Gets the maximum index that's allowed, property made available for ease of use.
		/// </summary>
		public int MaximumIndex
		{
			get { return this.TotalItemCount - this.VisibleItemCount; }
		}

		/// <summary>
		/// Gets or sets the orientation to render the list in, whether in horizontal or vertical fashion.
		/// </summary>
		[ClientProperty("orientation")]
		public Orientation Orientation
		{
			get { return (Orientation)(ViewState["Orientation"] ?? Orientation.Horizontal); }
			set { ViewState["Orientation"] = value; }
		}

		/// <summary>
		/// Gets or sets the paging options for paging through the list.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		MergableProperty(false)
		]
		public PageableListPagingOptions PagingOptions
		{
			get
			{
				if (_pagingOptions == null)
					_pagingOptions = new PageableListPagingOptions();
				return _pagingOptions;
			}
			set { _pagingOptions = value; }
		}

		/// <summary>
		/// Gets the total number of items in the list.
		/// </summary>
		public int TotalItemCount
		{
			get { return this.Controls.Count; }
		}

		/// <summary>
		/// Gets or sets the visible number of items.
		/// </summary>
		[ClientProperty("visibleItemCount")]
		public int VisibleItemCount
		{
			get { return (int)(ViewState["VisibleItemCount"] ?? 0); }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("value");
				if (this.TotalItemCount > 0 && value > this.TotalItemCount)
					value = this.TotalItemCount;

				ViewState["VisibleItemCount"] = value;
			}
		}

		#endregion



		#region " Methods "

		protected override void AddedControl(Control control, int index)
		{
			base.AddedControl(control, index);
		}

		protected override ControlCollection CreateControlCollection()
		{
			return new ControlListCollection<PageableListItem>(this);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(PageableList), this.ClientID));
			if (this.CurrentIndex > 0)
				descriptor.AddProperty("currentIndex", this.CurrentIndex);
			if (_pagingOptions != null)
				descriptor.AddProperty("leftPagerImageUrl", this.PagingOptions.LeftImageUrl);
			descriptor.AddProperty("orientation", this.Orientation);
			if (_pagingOptions != null)
				descriptor.AddProperty("rightPagerImageUrl", this.PagingOptions.RightImageUrl);

			if (VisibleItemCount > 0)
				descriptor.AddProperty("visibleItemCount", this.VisibleItemCount);
		}

		protected override void GetCssReferences(IContentRegistrar registrar)
		{
			registrar.AddCssReference(new CssReferenceRequestDetails(
				this.Page.ClientScript.GetWebResourceUrl(this.GetType(),
					"Nucleo.Web.ListControls.ListControls.css")));
		}

		protected override void LoadClientState(Nucleo.Web.ClientState.ClientStateData stateData)
		{
			base.LoadClientState(stateData);

			object currentIndex = stateData.Values.Get("currentIndex");
			if (currentIndex != null)
				this.CurrentIndex = int.Parse(currentIndex.ToString());

			object visibleItemCount = stateData.Values.Get("visibleItemCount");
			if (visibleItemCount != null)
				this.VisibleItemCount = int.Parse(visibleItemCount.ToString());
		}

		protected internal override void OnValidateState(EventArguments.ValidateEventArgs e)
		{
			base.OnValidateState(e);

			if (this.CurrentIndex > this.Items.Count || this.CurrentIndex < 0)
				e.IsValid = false;
		}

		/// <summary>
		/// Pages to the left, if not out of bounds.
		/// </summary>
		public void PageLeft()
		{
			if (this.CurrentIndex > 0)
				this.CurrentIndex--;
		}

		/// <summary>
		/// Pages to the right, if not out of bounds.
		/// </summary>
		public void PageRight()
		{
			if (this.CurrentIndex < this.MaximumIndex)
				this.CurrentIndex++;
		}

		/// <summary>
		/// Raises the postback argument, to either page left or right.
		/// </summary>
		/// <param name="eventArgument">The details about the event.</param>
		public void RaisePostBackEvent(string eventArgument)
		{
			if (eventArgument == PageLeftCommandName)
				this.PageLeft();

			if (eventArgument == PageRightCommandName)
				this.PageRight();
		}

		protected override void RemovedControl(Control control)
		{
			base.RemovedControl(control);
		}

		#endregion
	}
}
