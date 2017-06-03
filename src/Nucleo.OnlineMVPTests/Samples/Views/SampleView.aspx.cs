using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Samples.Presenters;

namespace Nucleo.Samples.Views
{
	public interface ISampleView : IView
	{
		event EventHandler Login;

		string UserName { get; set; }
		string Password { get; set; }
	}


	[PresenterBinding(typeof(SamplePresenter))]
	public partial class SampleView : BaseViewPage, ISampleView
	{
		public event EventHandler Login;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			this.btnLogin.Click += new EventHandler(btnLogin_Click);
		}

		void btnLogin_Click(object sender, EventArgs e)
		{
			if (Login != null)
				Login(this, e);
		}

		#region ISampleView Members

		public string UserName
		{
			get
			{
				return this.txtName.Text;
			}
			set
			{
				this.txtName.Text = value;
			}
		}

		public string Password
		{
			get
			{
				return this.txtPwd.Text;
			}
			set
			{
				this.txtPwd.Text = value;
			}
		}

		#endregion
	}
}