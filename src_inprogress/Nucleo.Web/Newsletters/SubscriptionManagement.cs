using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;
using Nucleo.Newsletters;
using Nucleo.Web.DataboundControls;


namespace Nucleo.Web.Newsletters
{
	[
	ValidationProperty("EmailAddress"),
	DefaultProperty("EmailAddress")
	]
	public class SubscriptionManagement : CompositeDataBoundControl, IPostBackDataHandler, IPostBackEventHandler
	{
		private CollectionBase<DataboundItem> _items = null;



		#region " Events "

		public event EventHandler EmailAddressChanged;
		public event EventHandler SubscriptionsCleared;
		public event EventHandler SubscriptionsLookup;
		public event EventHandler SubscriptionsUpdated;

		#endregion



		#region " Properties "

		[DefaultValue(false)]
		private bool DisplayNewsletters
		{
			get
			{
				object o = ViewState["DisplayNewsletters"];
				return (o == null) ? false : (bool)o;
			}
			set { ViewState["DisplayNewsletters"] = value; }
		}

		public string EmailAddress
		{
			get
			{
				object o = ViewState["EmailAddress"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["EmailAddress"] = value; }
		}

		public CollectionBase<DataboundItem> Items
		{
			get
			{
				if (_items == null)
					_items = new CollectionBase<DataboundItem>();
				return _items;
			}
		}

		[
		DefaultValue("Lookup"),
		Localizable(true)
		]
		public string LookupButtonText
		{
			get
			{
				object o = ViewState["LookupButtonText"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["LookupButtonText"] = value; }
		}

		[
		DefaultValue("Remove All"),
		Localizable(true)
		]
		public string RemoveAllButtonText
		{
			get
			{
				object o = ViewState["RemoveAllButtonText"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["RemoveAllButtonText"] = value; }
		}

		[
		DefaultValue("Update"),
		Localizable(true)
		]
		public string UpdateButtonText
		{
			get
			{
				object o = ViewState["UpdateButtonText"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["UpdateButtonText"] = value; }
		}

		#endregion



		#region " Methods "

		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
		{
			if (dataBinding && !string.IsNullOrEmpty(this.EmailAddress))
			{
				if (!this.DesignMode)
					dataSource = Newsletter.GetNewslettersForSubscriber(this.EmailAddress);
				else
					dataSource = new string[] { "Data Source 1", "Data Source 2", "Data Source 3" };
			}

			Table table = new Table();
			this.Controls.Add(table);
			this.Items.Clear();

			int itemCount = 0;
			this.CreateHeader(table);

			foreach (object dataItem in dataSource)
				this.Items.Add(this.CreateItem(table, dataItem, itemCount++, dataBinding));

			if (itemCount > 0)
				this.CreateFooter(table);
			return itemCount;
		}

		protected virtual void CreateFooter(Table table)
		{
			TableRow footerRow = new TableRow();
			table.Rows.Add(footerRow);
			footerRow.Cells.Add(new TableCell());
			footerRow.Cells[0].ColumnSpan = 2;

			LinkButton update = new LinkButton();
			footerRow.Cells[0].Controls.Add(update);
			update.Text = this.UpdateButtonText;
			update.OnClientClick = Page.ClientScript.GetPostBackClientHyperlink(this, "update");

			LinkButton removeAll = new LinkButton();
			footerRow.Cells[0].Controls.Add(removeAll);
			removeAll.Text = this.RemoveAllButtonText;
			removeAll.OnClientClick = Page.ClientScript.GetPostBackClientHyperlink(this, "remove_all");
		}

		protected virtual void CreateHeader(Table table)
		{
			TableRow headerRow = new TableRow();
			table.Rows.Add(headerRow);
			headerRow.Cells.Add(new TableCell());
			headerRow.Cells[0].ColumnSpan = 2;

			TextBox box = new TextBox();
			headerRow.Cells[0].Controls.Add(box);
			box.ID = this.ID + "_box";
			box.Text = this.EmailAddress;

			LinkButton link = new LinkButton();
			headerRow.Cells[0].Controls.Add(link);
			link.Text = this.LookupButtonText;
			link.OnClientClick = Page.ClientScript.GetPostBackClientHyperlink(this, "lookup", true);
		}

		protected virtual DataboundItem CreateItem(Table table, object dataItem, int index, bool dataBinding)
		{
			DataboundItem item = new DataboundItem(dataItem, index);
			table.Rows.Add(item);

			TableCell newsletterCell = new TableCell();
			item.Cells.Add(newsletterCell);
			TableCell checkboxCell = new TableCell();
			item.Cells.Add(checkboxCell);

			if (dataBinding)
			{
				newsletterCell.Text = (string)dataItem;

				CheckBox box = new CheckBox();
				checkboxCell.Controls.Add(box);
			}

			return item;
		}

		public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			string value = postCollection[this.UniqueID + "_box"];

			if (this.EmailAddress != value)
			{
				this.EmailAddress = postCollection[this.UniqueID + "_box"];
				return true;
			}

			return false;
		}

		protected virtual void OnEmailAddressChanged(EventArgs e)
		{
			if (EmailAddressChanged != null)
				EmailAddressChanged(this, e);
		}

		protected virtual void OnSubscriptionsCleared(EventArgs e)
		{
			if (SubscriptionsCleared != null)
				SubscriptionsCleared(this, e);
		}

		protected virtual void OnSubscriptionsLookup(EventArgs e)
		{
			if (SubscriptionsLookup != null)
				SubscriptionsLookup(this, e);
		}

		protected virtual void OnSubscriptionsUpdated(EventArgs e)
		{
			if (SubscriptionsUpdated != null)
				SubscriptionsUpdated(this, e);
		}

		public void RaisePostBackEvent(string eventArgument)
		{
			if (eventArgument == "removeall" || eventArgument == "update")
				Newsletter.RemoveAllSubscriptions(this.EmailAddress);
			if (eventArgument == "update")
			{
				foreach (DataboundItem item in this.Items)
				{
					if (item.Cells[1].Controls.Count > 0)
					{
						CheckBox box = item.Cells[1].Controls[0] as CheckBox;
						if (box != null && box.Checked)
							Newsletter.AddSubscription(this.EmailAddress, item.Cells[0].Text);
					}
				}
			}
		}

		public void RaisePostDataChangedEvent()
		{
			this.OnEmailAddressChanged(EventArgs.Empty);
			this.RequiresDataBinding = true;
			this.DataBind();
		}

		#endregion
	}
}
