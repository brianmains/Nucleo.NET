using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Context
{
	public partial class CookieServiceFirstLook : Nucleo.Framework.TestPage
	{
		#region " Event Handlers "

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			ICookieService service = ApplicationContext.GetCurrent().GetService<ICookieService>();
			service.Add(this.txtName.Text, this.txtValue.Text, DateTime.Now.AddMinutes(30), false);

			this.lblOutput.Text += this.txtName.Text + "=" + service.Get(this.txtName.Text).ToString() + "<br>";
		}

		protected void btnGet_Click(object sender, EventArgs e)
		{
			try
			{
				ICookieService service = ApplicationContext.GetCurrent().GetService<ICookieService>();
				this.lblValue.Text = service.Get(this.txtNameGet.Text).ToString();
			}
			catch (Exception ex) { }
		}

		#endregion
	}
}
