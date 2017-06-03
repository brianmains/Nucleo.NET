using System;
using System.Collections.Generic;
using System.Linq;
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
	public class DisplayModel
	{
		public ContactRecord Contact { get; set; }

		public AddressRecord PrimaryAddress { get; set; }

		public IQueryable<AddressRecord> Addresses { get; set; }

		public PhoneRecord PrimaryPhone { get; set; }

		public IQueryable<PhoneRecord> Phones { get; set; }
	}

	public interface IDisplayView : IView<DisplayModel>
	{

	}

	public class DisplayPresenter : BasePresenter<IDisplayView>
	{
		public DisplayPresenter(IDisplayView view)
			: base(view)
		{
			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.EntityType<ContactInfoPresenter>(),
				(p) =>
				{
					if (this.View.Model == null)
						this.View.Model = new DisplayModel();

					this.View.Model.Contact = (ContactRecord)p.Source;
				}));

			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.EntityType<AddressesPresenter>(),
				(p) =>
				{
					if (this.View.Model == null)
						this.View.Model = new DisplayModel();

					var addr = (AddressRecord)p.Attributes["Address"];
					if (addr.IsPrimary && addr.Ends.GetValueOrDefault(DateTime.MaxValue) > DateTime.Now)
					{
						this.View.Model.PrimaryAddress = addr;
					}

					List<AddressRecord> list = p.Attributes["Addresses"] as List<AddressRecord>;
					if (list != null)
						this.View.Model.Addresses = list.AsQueryable();
				}));

			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.EntityType<PhoneNumbersPresenter>(),
				(p) =>
				{
					if (this.View.Model == null)
						this.View.Model = new DisplayModel();

					var phone = (PhoneRecord)p.Attributes["Phone"];
					if (phone.IsPrimary && phone.Ends.GetValueOrDefault(DateTime.MaxValue) > DateTime.Now)
					{
						this.View.Model.PrimaryPhone = phone;
					}

					List<PhoneRecord> list = p.Attributes["Phones"] as List<PhoneRecord>;
					if (list != null)
						this.View.Model.Phones = list.AsQueryable();
				}));
		}
	}

	[PresenterBinding(typeof(DisplayPresenter))]
	public partial class Display : DemoViewUserControl<DisplayModel>, IDisplayView
	{
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model == null)
				return;

			if (this.Model.PrimaryAddress != null)
				this.PrimaryAddress.Text = this.Model.PrimaryAddress.ToDisplay("<br/>");
			if (this.Model.Addresses != null)
			{
				this.Addresses.DataSource = this.Model.Addresses.Select(i => new { Address = i.ToDisplay("<br/>") });
				this.Addresses.DataBind();
			}

			if (this.Model.PrimaryPhone != null)
				this.PrimaryPhone.Text = this.Model.PrimaryPhone.Phone;
			if (this.Model.Phones != null)
			{
				this.Phones.DataSource = this.Model.Phones;
				this.Phones.DataBind();
			}

			if (this.Model.Contact != null)
			{
				this.Name.Text = this.Model.Contact.Name;
				this.UserName.Text = this.Model.Contact.UserName;
				this.Email.Text = this.Model.Contact.Email;
			}
		}
	}
}