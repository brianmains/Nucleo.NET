using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

using Nucleo.EventArguments;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpScenarios.TabbedForms
{
	public class ContactRecord : IRecord
	{
		public int Key { get; set; }

		public string Name { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public bool IsPrimaryContact { get; set; }
	}

	public class ContactInfoModel
	{
		public ContactRecord SelectedContact { get; set; }
	}

	public interface IContactInfoView : IView<ContactInfoModel>
	{
		event EventHandler Cancel;

		event DataEventHandler<ContactRecord> Save;
	}

	public class ContactInfoPresenter : BasePresenter<IContactInfoView>
	{
		public ContactInfoPresenter(IContactInfoView view)
			: base(view)
		{
			view.Starting += View_Starting;
			view.Save += View_Save;
			view.Cancel += View_Cancel;
		}



		private void LoadModel()
		{
			this.View.Model = new ContactInfoModel
			{
				SelectedContact = DataFactory.GetAll<ContactRecord>().FirstOrDefault()
			};
		}


		void View_Cancel(object sender, EventArgs e)
		{
			this.LoadModel();
		}

		void View_Save(object sender, DataEventArgs<ContactRecord> e)
		{
			DataFactory.Add<ContactRecord>(e.Data);

			this.View.Model = new ContactInfoModel
			{
				SelectedContact = e.Data
			};

			this.CurrentContext.EventRegistry.Publish(new PublishedEventDetails(
				e.Data, ListenerCriterion.EntityType<ContactInfoPresenter>()));
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.LoadModel();
		}
	}

	[PresenterBinding(typeof(ContactInfoPresenter))]
	public partial class ContactInfo : BaseViewUserControl<ContactInfoModel>, IContactInfoView
	{
		public event EventHandler Cancel;

		public event DataEventHandler<ContactRecord> Save;



		private int? Key
		{
			get { return (int?)ViewState["Key"]; }
			set { ViewState["Key"] = value; }
		}



		private void LoadContact(ContactRecord contact)
		{
			this.Key = contact.Key;
			this.Name.Text = contact.Name;
			this.Email.Text = contact.Email;
			this.UserName.Text = contact.UserName;
			this.IsPrimaryContact.Checked = contact.IsPrimaryContact;
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model == null)
				return;

			if (this.Model.SelectedContact != null)
				this.LoadContact(this.Model.SelectedContact);
		}

		private void OnCancel(EventArgs e)
		{
			if (Cancel != null)
				Cancel(this, e);
		}

		private void OnSave(DataEventArgs<ContactRecord> e)
		{
			if (Save != null)
				Save(this, e);
		}



		protected void CancelCommand_Click(object sender, EventArgs e)
		{
			OnCancel(e);
		}

		protected void SaveCommand_Click(object sender, EventArgs e)
		{
			var record = new ContactRecord
			{
				Key = this.Key ?? 0,
				Name = this.Name.Text,
				Email = this.Email.Text,
				UserName = this.UserName.Text,
				IsPrimaryContact = this.IsPrimaryContact.Checked
			};

			this.OnSave(new DataEventArgs<ContactRecord>(record));
		}
	}
}