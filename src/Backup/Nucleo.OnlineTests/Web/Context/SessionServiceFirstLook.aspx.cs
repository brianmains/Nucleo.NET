using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Context
{
	public partial class SessionServiceFirstLook : Nucleo.Framework.TestPage
	{
		#region " Methods "

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			
		}

		#endregion



		#region " Event Handlers "

		protected void btnLoadSession_Click(object sender, EventArgs e)
		{
			this.lblSessionData.Text = string.Empty;

			var context = ApplicationContext.GetCurrent();
			var session = context.GetService<ISessionStateService>();

			session.Add("First", "First Value");
			session.Add("Second", "Second Value");
			session.Add("Third", "Third Value");
		}

		protected void btnQuerySesson_Click(object sender, EventArgs e)
		{
			this.lblSessionData.Text = string.Empty;

			var context = ApplicationContext.GetCurrent();
			var session = context.GetService<ISessionStateService>();

			if (session.Get("First") != null)
				this.lblSessionData.Text += "First: " + session.Get("First").ToString() + "<br/>";
			if (session.Get("Second") != null)
				this.lblSessionData.Text += "Second: " + session.Get("Second").ToString() + "<br/>";
			if (session.Get("Third") != null)
				this.lblSessionData.Text += "Third: " + session.Get("Third").ToString() + "<br/>";

			if (string.IsNullOrEmpty(this.lblSessionData.Text))
				this.lblSessionData.Text = "Empty";
		}

		#endregion
	}
}
