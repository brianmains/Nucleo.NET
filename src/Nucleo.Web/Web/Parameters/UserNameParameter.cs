using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.Parameters
{
	public class UserNameParameter : Parameter
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets a flag stating whether to strip the domain name from the user ID.
		/// </summary>
		public bool StripDomainName
		{
			get { return (bool)(ViewState["StripDomainName"] ?? false); }
			set { ViewState["StripDomainName"] = value; }
		}

		#endregion



		#region " Methods "

		protected override object Evaluate(System.Web.HttpContext context, Control control)
		{
			string userName = context.User.Identity.Name;
			if (!this.StripDomainName || !userName.Contains(@"\"))
				return userName;

			return userName.Substring(userName.IndexOf(@"\") + 1);
		}

		#endregion
	}
}
