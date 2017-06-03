using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.Views;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Web.Views;
using Nucleo.OnlineMVPTests.Presenters;


namespace Nucleo.OnlineMVPTests.Views
{
	/// <summary>
	/// Interface for view
	/// </summary>
	public interface ICreateCustomerView : IView
	{
		#region " Events "

		event EventHandler Cancelled;
		event EventHandler Loaded;
		event EventHandler Saved;
		event EventHandler ViewAllCustomers;

		#endregion



		#region " Properties "

		string FirstName { get; set; }
		string LastName { get; set; }
		string AccountNumber { get; set; }

		#endregion



		#region " Methods "

		void ShowMessage(string message);

		#endregion
	}

	/// <summary>
	/// Code behind for page class, as well as view implementation
	/// </summary>
	public partial class CreateCustomer : BaseViewPage, ICreateCustomerView
	{
		#region " Events "

		public event EventHandler Cancelled;
		public event EventHandler Loaded;
		public event EventHandler Saved;
		public event EventHandler ViewAllCustomers;

		#endregion



		#region " Properties "

		public string AccountNumber
		{
			get { return this.txtAccountNumber.Text; }
			set { this.txtAccountNumber.Text = value; }
		}

		public string FirstName 
		{
			get { return this.txtFirstName.Text; }
			set { this.txtFirstName.Text = value; }
		}
		public string LastName 
		{
			get { return this.txtLastName.Text; }
			set { this.txtLastName.Text = value; }
		}

		#endregion



		#region " Methods "

		protected override IPresenter CreatePresenter()
		{
			return new CreateCustomerPresenter(this);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			this.btnSave.Click += btnSave_Click;
			this.btnCancel.Click += btnCancel_Click;
			this.btnLoad.Click += btnLoad_Click;
			this.btnViewAll.Click += btnViewAll_Click;
		}

		public void ShowMessage(string message)
		{
			this.lblMessage.Text = message;
		}

		#endregion



		#region " Event Handlers "

		void btnCancel_Click(object sender, EventArgs e)
		{
			if (Cancelled != null)
				Cancelled(this, e);
		}

		void btnLoad_Click(object sender, EventArgs e)
		{
			if (Loaded != null)
				Loaded(this, e);
		}

		void btnSave_Click(object sender, EventArgs e)
		{
			if (Saved != null)
				Saved(this, e);
		}

		void btnViewAll_Click(object sender, EventArgs e)
		{
			if (ViewAllCustomers != null)
				ViewAllCustomers(this, e);
		}

		#endregion
	}
}
