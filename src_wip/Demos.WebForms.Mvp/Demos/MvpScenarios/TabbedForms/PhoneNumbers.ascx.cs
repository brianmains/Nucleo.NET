using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;

using Nucleo.EventArguments;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.State;


namespace Nucleo.Demos.MvpScenarios.TabbedForms
{
	public class PhoneRecord : IRecord
	{
		public int Key { get; set; }

		public string Phone { get; set; }

		public string Type { get; set; }

		public DateTime Effective { get; set; }

		public DateTime? Ends { get; set; }

		public bool IsPrimary { get; set; }
	}

	public class PhoneNumbersModel
	{
		public PhoneRecord SelectedPhone { get; set; }

		public IEnumerable<PhoneRecord> Phones { get; set; }
	}

	public interface IPhoneNumbersView : IView<PhoneNumbersModel>
	{
		event EventHandler Cancel;

		event DataEventHandler<PhoneRecord> Save;

		event DataEventHandler<int> Selected;
	}

	public class PhoneNumbersPresenter : BasePresenter<IPhoneNumbersView>
	{
		public PhoneNumbersPresenter(IPhoneNumbersView view)
			: base(view)
		{
			view.Save += View_Save;
			view.Selected += View_Selected;
			view.Starting += View_Starting;
		}



		private void LoadModel()
		{
			this.View.Model = new PhoneNumbersModel
			{
				Phones = DataFactory.GetAll<PhoneRecord>()
			};
		}



		void View_Save(object sender, DataEventArgs<PhoneRecord> e)
		{
			try
			{
				DataFactory.Add<PhoneRecord>(e.Data);
				this.CurrentContext.State.Set(new StateValue
				{
					Key = "Phone Number Save",
					Value = "Success"
				});

				this.LoadModel();

				this.CurrentContext.EventRegistry.Publish(new PublishedEventDetails(
					ListenerCriterion.EntityType<PhoneNumbersPresenter>(),
					new Dictionary<string, object>
					{
						{ "Phone", e.Data },
						{ "Phones", this.View.Model.Phones }
					}));
			}
			catch (Exception ex)
			{
				this.CurrentContext.State.Set(new StateValue
				{
					Key = "Phone Number Save",
					Value = "Failed"
				});
			}
		}

		void View_Selected(object sender, DataEventArgs<int> e)
		{
			var phone = DataFactory.Get<PhoneRecord>(e.Data);
			if (phone == null)
				throw new InvalidOperationException("Phone with key of " + e.Data.ToString() + " does not exist.");

			this.View.Model = new PhoneNumbersModel
			{
				SelectedPhone = phone
			};
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.LoadModel();
		}
	}


	[PresenterBinding(typeof(PhoneNumbersPresenter))]
	public partial class PhoneNumbers : DemoViewUserControl<PhoneNumbersModel>, IPhoneNumbersView
	{
		public event EventHandler Cancel;

		public event DataEventHandler<PhoneRecord> Save;

		public event DataEventHandler<int> Selected;



		private int? Key
		{
			get { return (int?)ViewState["Key"]; }
			set { ViewState["Key"] = value; }
		}



		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model == null)
				return;

			if (this.Model.Phones != null)
			{
				this.gvwPhoneNumbers.DataSource = this.Model.Phones;
				this.gvwPhoneNumbers.DataBind();
			}

			if (this.Model.SelectedPhone != null)
			{
				var entity = this.Model.SelectedPhone;
				this.Key = entity.Key;
				this.Phone.Text = entity.Phone;
				this.Type.Text = entity.Type;
				this.IsPrimary.Checked = entity.IsPrimary;
				this.Effective.Text = entity.Effective.ToShortDateString();
				this.Ends.Text = entity.Ends.HasValue ? entity.Ends.Value.ToShortDateString() : "";
			}
		}

		private void OnCancel(EventArgs e)
		{
			if (Cancel != null)
				Cancel(this, e);
		}

		private void OnSave(DataEventArgs<PhoneRecord> e)
		{
			if (Save != null)
				Save(this, e);
		}



		protected virtual void CancelCommand_Click(object sender, EventArgs e)
		{
			OnCancel(e);
		}

		protected virtual void SaveCommand_Click(object sender, EventArgs e)
		{
			var record = new PhoneRecord
			{
				Key = this.Key ?? 0,
				Phone = this.Phone.Text,
				IsPrimary = this.IsPrimary.Checked,
				Type = this.Type.Text,
				Effective = DateTime.Parse(this.Effective.Text),
				Ends = (!string.IsNullOrEmpty(this.Ends.Text)) ? DateTime.Parse(this.Ends.Text) : default(DateTime?)
			};

			OnSave(new DataEventArgs<PhoneRecord>(record));
		}


		protected void gvwPhoneNumbers_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				Selected(this, new DataEventArgs<int>(int.Parse(e.CommandArgument.ToString())));
			}
		}
	}
}