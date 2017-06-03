using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Collections;
using Nucleo.Newsletters;
using Nucleo.Web.DataboundControls;
using Nucleo.EventArguments;


namespace Nucleo.Web.Newsletters
{
	public class NewsletterAdministration : CompositeDataBoundControl, IPostBackEventHandler
	{
		private CollectionBase<DataboundItem> _items = null;
		private TextBox _newsletterName = null;
		private TextBox _newsletterDescription = null;



		#region " Events "

		public event DataEventHandler<DataboundItem> ItemCreated;
		public event DataEventHandler<DataboundItem> ItemDataBound;

		#endregion




		#region " Properties "

		new private object DataSource
		{
			get { return null; }
			set { throw new NotImplementedException(); }
		}

		new private string DataSourceID
		{
			get { return string.Empty; }
			set { throw new NotImplementedException(); }
		}

		[
		DefaultValue("Delete"),
		Localizable(true)
		]
		public string DeleteButtonText
		{
			get
			{
				object o = ViewState["DeleteButtonText"];
				return (o == null) ? "Delete" : (string)o;
			}
			set { ViewState["DeleteButtonText"] = value; }
		}

		[
		DefaultValue("Insert"),
		Localizable(true)
		]
		public string InsertButtonText
		{
			get
			{
				object o = ViewState["InsertButtonText"];
				return (o == null) ? "Insert" : (string)o;
			}
			set { ViewState["InsertButtonText"] = value; }
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

		#endregion



		#region " Methods "

		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
		{
			int itemCount = 0;
			if (dataBinding)
			{
				if (!this.DesignMode)
					dataSource = Newsletter.GetAllNewsletters();
				else
					dataSource = new string[] { "Data Bound 1", "Data Bound 2", "Data Bound 3" };
			}

			Table table = new Table();
			this.Controls.Add(table);
			this.Items.Clear();

			foreach (object o in dataSource)
				this.Items.Add(this.CreateItem(table, o, itemCount++, dataBinding));

			this.CreateFooter(table);
			return itemCount;
		}

		private void CreateFooter(Table table)
		{
			TableRow row = new TableRow();
			table.Rows.Add(row);
			row.Cells.Add(new TableCell());
			row.Cells[0].VerticalAlign = VerticalAlign.Top;
			row.Cells.Add(new TableCell());
			row.Cells[1].VerticalAlign = VerticalAlign.Top;

			_newsletterName = new TextBox();
			_newsletterName.ID = "txtNewsletterName";
			_newsletterName.ValidationGroup = "NewsletterAdministration_Add";
			row.Cells[0].Controls.Add(_newsletterName);
			row.Cells[0].Controls.Add(new LiteralControl("<br />"));

			_newsletterDescription = new TextBox();
			_newsletterDescription.ID = "txtNewsletterDescription";
			_newsletterDescription.ValidationGroup = "NewsletterAdministration_Add";
			_newsletterDescription.TextMode = TextBoxMode.MultiLine;
			_newsletterDescription.Rows = 3;
			_newsletterDescription.Columns = 30;
			row.Cells[0].Controls.Add(_newsletterDescription);

			LinkButton button = new LinkButton();
			button.Text = this.InsertButtonText;
			button.ValidationGroup = "NewsletterAdministration_Add";
			button.CommandName = "insert";
			row.Cells[1].Controls.Add(button);
		}

		protected virtual DataboundItem CreateItem(Table table, object dataItem, int index, bool dataBinding)
		{
			DataboundItem item = new DataboundItem(dataItem, index);
			table.Rows.Add(item);

			TableCell newsletterCell = new TableCell();
			item.Cells.Add(newsletterCell);
			TableCell buttonCell = new TableCell();
			item.Cells.Add(buttonCell);
			this.OnItemCreated(new DataEventArgs<DataboundItem>(item));

			if (dataBinding)
			{
				newsletterCell.Text = (string)dataItem;
				this.OnItemDatabound(new DataEventArgs<DataboundItem>(item));
			}

			LinkButton button = new LinkButton();
			buttonCell.Controls.Add(button);
			button.Text = this.DeleteButtonText;
			button.CommandName = "delete";
			button.CommandArgument = this.Items.Count.ToString();
			return item;
		}

		private bool HandleEvent(CommandEventArgs args)
		{
			if (args.CommandName == "insert")
			{
				Page.Validate("NewsletterAdministration_Add");
				if (Page.IsValid)
				{
					string name = _newsletterName.Text;
					string description = _newsletterDescription.Text;

					Newsletter.AddNewsletter(name, description);
				}
			}
			else if (args.CommandName == "delete")
				Newsletter.RemoveNewsletter(this.Items[int.Parse(args.CommandArgument.ToString())].Cells[0].Text);
			else
				return false;

			base.RequiresDataBinding = true;
			this.DataBind();
			return true;
		}

		protected override bool OnBubbleEvent(object source, EventArgs args)
		{
			CommandEventArgs commandArgs = args as CommandEventArgs;
			if (commandArgs != null)
				return this.HandleEvent(commandArgs);
			return false;
		}

		protected virtual void OnItemCreated(DataEventArgs<DataboundItem> e)
		{
			if (ItemCreated != null)
				ItemCreated(this, e);
		}

		protected virtual void OnItemDatabound(DataEventArgs<DataboundItem> e)
		{
			if (ItemDataBound != null)
				ItemDataBound(this, e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!Page.IsPostBack)
				this.DataBind();
		}

		public void RaisePostBackEvent(string eventArgument)
		{
			if (eventArgument.Contains("$"))
			{
				string[] parts = eventArgument.Split('$');
				CommandEventArgs args = new CommandEventArgs(parts[0], parts[1]);
				this.HandleEvent(args);
			}
		}

		#endregion
	}
}
