using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpScenarios.TabbedForms
{
	public class AddressRecord : IRecord
	{
		public int Key { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string ZipCode { get; set; }

		public DateTime Effective { get; set; }

		public DateTime? Ends { get; set; }

		public bool IsPrimary { get; set; }

		public bool? IsMailing { get; set; }
	}

	public static class AddressRecordExtensions
	{
		public static string ToDisplay(this AddressRecord record, string lineSeparator)
		{
			return record.Address + lineSeparator + record.City + ", " + record.State + " " + record.ZipCode;
		}
	}

	public class AddressesModel
	{
		public AddressRecord SelectedAddress { get; set; }

		public IEnumerable<AddressRecord> Addresses { get; set; }
	}

	public interface IAddressesView : IView<AddressesModel>
	{
		event EventHandler Cancel;

		event DataEventHandler<AddressRecord> Save;

		event DataEventHandler<int> Selected;
	}

	public class AddressesPresenter : BasePresenter<IAddressesView>
	{
		public AddressesPresenter(IAddressesView view)
			: base(view)
		{
			view.Save += View_Save;
			view.Selected += View_Selected;
		}



		private void LoadData()
		{
			this.View.Model = new AddressesModel
			{
				Addresses = DataFactory.GetAll<AddressRecord>()
			};
		}



		void View_Save(object sender, DataEventArgs<AddressRecord> e)
		{
			DataFactory.Add<AddressRecord>(e.Data);

			this.LoadData();

			this.CurrentContext.EventRegistry.Publish(new PublishedEventDetails(
				ListenerCriterion.EntityType<AddressesPresenter>(),
				new Dictionary<string, object>
				{
					{ "Address", e.Data },
					{ "Addresses", this.View.Model.Addresses }
				}));
		}


		void View_Selected(object sender, DataEventArgs<int> e)
		{
			var address = DataFactory.Get<AddressRecord>(e.Data);
			this.View.Model = new AddressesModel
			{
				SelectedAddress = address
			};
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.LoadData();
		}
	}

	[PresenterBinding(typeof(AddressesPresenter))]
	public partial class Addresses : DemoViewUserControl<AddressesModel>, IAddressesView
	{
		public event EventHandler Cancel;

		public event DataEventHandler<AddressRecord> Save;

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

			if (this.Model.Addresses != null)
			{
				this.gvwAddresses.DataSource = this.Model.Addresses;
				this.gvwAddresses.DataBind();
			}

			if (this.Model.SelectedAddress != null)
			{
				var entity = this.Model.SelectedAddress;
				//TODO:Load
			}
		}

		private void OnCancel(EventArgs e)
		{
			if (Cancel != null)
				Cancel(this, e);
		}

		private void OnSave(DataEventArgs<AddressRecord> e)
		{
			if (Save != null)
				Save(this, e);
		}


		protected virtual void CancelCommand_Click(object sender, EventArgs e)
		{

		}

		protected virtual void SaveCommand_Click(object sender, EventArgs e)
		{
			var record = new AddressRecord
			{
				Key = this.Key ?? 0
			};
			
			OnSave(new DataEventArgs<AddressRecord>(record));
		}

		protected void gvwAddresses_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Select" && e.CommandArgument != null)
			{
				Selected(this, new DataEventArgs<int>(int.Parse(e.CommandArgument.ToString())));
			}
		}
	}
}