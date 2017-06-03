using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.OnlineMVPTests.Views;

using Nucleo.Context;
using Nucleo.Web.Routing;


namespace Nucleo.OnlineMVPTests.Presenters
{
	public class CreateCustomerPresenter : BaseWebPresenter<ICreateCustomerView>
	{
		#region " Constructors "

		public CreateCustomerPresenter(ICreateCustomerView view)
			: base(view) 
		{
			view.Cancelled += delegate(object sender, EventArgs e) { this.ClearForm(); };
			view.Loaded += delegate(object sender, EventArgs e) { this.LoadCustomer(); };
			view.Saved += delegate(object sender, EventArgs e) { this.SaveCustomer(); };
			view.ViewAllCustomers += delegate(object sender, EventArgs e) 
			{
				this.CurrentContext.Context.Navigation.NavigateToUrl("~/Views/ViewCustomers.aspx");
			};
		}

		#endregion




		#region " Methods "

		public void ClearForm()
		{
			this.View.FirstName = "";
			this.View.LastName = "";
			this.View.AccountNumber = "";
		}

		public void LoadCustomer()
		{
			this.View.FirstName = "John";
			this.View.LastName = "Doe";
			this.View.AccountNumber = "12345";
		}

		public void SaveCustomer()
		{
			//Pass saved information to the data layer
			this.ClearForm();

			this.View.ShowMessage("The customer has been saved.");
		}

		#endregion
	}
}
