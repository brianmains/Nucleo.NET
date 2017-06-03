using System;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Controls
{
	public class IdentityParameter : Parameter
	{
		#region " Properties "

		/// <summary>
		/// If using windows authentication, this property will remove the windows domain from the value.
		/// </summary>
		public bool RemoveWindowsDomain
		{
			get
			{
				object o = ViewState["RemoveWindowsDomain"];
				return (o == null) ? false : (bool)o;
			}
			set { ViewState["RemoveWindowsDomain"] = value; }
		}

		#endregion


		protected override object Evaluate(System.Web.HttpContext context, System.Web.UI.Control control)
		{
			if (context != null && context.User != null && context.User.Identity.IsAuthenticated)
			{
				//Get the name from the current user account
				string name = context.User.Identity.Name;
				//Get the current authentication type
				string authType = context.User.Identity.AuthenticationType.ToLower();

				//Determine whether the authentication type is windows, and to remove the windows domain
				if (authType == "ntlm" && this.RemoveWindowsDomain)
				{
					//Get the position of the \ and remove it
					int pos = name.LastIndexOf(@"\");
					name = name.Substring(pos + 1);
				}

				return name;
			}

			return null;
		}
	}
}
