using System;
using System.Web;
using System.Web.Security;

using Nucleo;
using Nucleo.Security;


namespace Nucleo.Services
{
	public class WebUserSecurityService : IUserSecurityService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public WebUserSecurityService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebUserSecurityService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public RoleCollection GetRolesForUser()
		{
			if (Roles.Enabled)
				return new RoleCollection(Roles.GetRolesForUser());
			else
				return new RoleCollection();
		}

		public string GetUserName()
		{
			if (this.Context.User.Identity != null)
				return this.Context.User.Identity.Name;
			else
				return null;
		}

		public bool IsInRole(string role)
		{
			return this.Context.User.IsInRole(role);
		}

		public bool IsLoggedIn()
		{
			return (this.Context.User.Identity != null && this.Context.User.Identity.IsAuthenticated);
		}

		#endregion
	}
}
