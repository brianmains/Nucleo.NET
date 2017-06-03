using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Newsletters;
using Nucleo.Web.DataboundControls;


namespace Nucleo.Web.Newsletters
{
	[
	ValidationProperty("EmailAddress"),
	DefaultProperty("EmailAddress")
	]
	public class SubscriberAdministration : CompositeControl
	{
		private SimpleDataList _dataList;
		private DropDownList _dropDown;



		#region " Methods "

		protected override void CreateChildControls()
		{
			this.Controls.Clear();

			this._dropDown = new DropDownList();
			this.Controls.Add(this._dropDown);
			this._dropDown.AutoPostBack = true;
			this._dropDown.Items.Add("Select One");
			this._dropDown.SelectedIndexChanged += new EventHandler(this._dropDown_SelectedIndexChanged);

			this._dataList = new SimpleDataList();
			this.Controls.Add(this._dataList);
			this._dataList.DataField = "{0}";

			if (!this.DesignMode && (!Page.IsPostBack || !this.EnableViewState))
			{
				NewsletterInformationCollection newsletters = Newsletter.GetAllNewsletters();
				foreach (NewsletterInformation newsletter in newsletters)
					this._dropDown.Items.Add(newsletter.Name);
			}
		}

		private void _dropDown_SelectedIndexChanged(object sender, EventArgs e)
		{
			DropDownList ddList = sender as DropDownList;

			if (ddList.SelectedItem.Text != "Select One")
			{
				string[] subscribers = Newsletter.GetSubscribers(this._dropDown.SelectedItem.Text);
				this._dataList.DataSource = subscribers;
				this._dataList.DataBind();
			}
		}

		#endregion
	}
}
