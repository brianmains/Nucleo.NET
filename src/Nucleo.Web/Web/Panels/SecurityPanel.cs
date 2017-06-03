using System;
using System.Web.Security;
using System.Web.UI.WebControls;

using Nucleo.Collections;
using Nucleo.Web.Pages;
using Nucleo.EventArguments;


namespace Nucleo.Web.Panels
{
	public class SecurityPanel : Panel
	{
		public event DataEventHandler<bool> Authenticate;



		#region " Properties "

		public StringCollection RoleNames
		{
			get
			{
				object o = ViewState["RoleNames"];
				if (o != null)
					return StringCollection.FromList(ViewState["RoleNames"].ToString(), ",");
				else
					return null;
			}
			set { ViewState["RoleNames"] = value.ToCommaSeparatedList(); }
		}

		public bool UseRoleProvider
		{
			get
			{
				object o = ViewState["UseRoleProvider"];
				return (o == null) ? true : (bool)o;
			}
			set { ViewState["UseRoleProvider"] = value; }
		}

		public override bool Visible
		{
			get { return base.Visible; }
			set { throw new NotImplementedException(); }
		}

		#endregion



		#region " Methods "

		protected virtual void OnAuthenticate(DataEventArgs<bool> e)
		{
			if (Authenticate != null)
				Authenticate(this, e);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if ((this.EnableViewState && !Page.IsPostBack) || !this.EnableViewState)
			{
				base.Visible = false;

				if (this.Page.User == null || !this.Page.User.Identity.IsAuthenticated)
					return;
				else
				{
					try
					{
						if (this.UseRoleProvider)
						{
							string[] roles = Roles.GetRolesForUser(this.Page.User.Identity.Name);
							foreach (string role in roles)
							{
								if (this.RoleNames.Contains(role))
									base.Visible = true;
							}
						}
						else
						{
							DataEventArgs<bool> args = new DataEventArgs<bool>(false);
							this.OnAuthenticate(args);
							base.Visible = args.Data;
						}
					}
					catch { }
				}
			}
		}

		#endregion
	}
}
