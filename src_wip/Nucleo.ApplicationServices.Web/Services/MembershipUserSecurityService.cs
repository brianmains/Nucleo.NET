using System;
using System.Web;
using System.Web.Security;
using Nucleo;
using Nucleo.Security;
using Nucleo;


namespace Nucleo.Services
{
	public class MembershipUserSecurityService : IUserSecurityService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public MembershipUserSecurityService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public MembershipUserSecurityService(HttpContextBase context)
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
			if (this.Context.User != null && this.Context.User.Identity != null)
				return this.Context.User.Identity.Name;
			else
				return null;
		}

		public bool IsInRole(string role)
		{
			return Roles.IsUserInRole(role);
		}

		public bool IsLoggedIn()
		{
			if (this.Context == null || this.Context.User == null)
				return false;

			return (this.Context.User.Identity != null && this.Context.User.Identity.IsAuthenticated);
		}

		#endregion
	}
}
