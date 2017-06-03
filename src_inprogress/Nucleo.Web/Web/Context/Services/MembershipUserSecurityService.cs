using System;
using System.Web;
using System.Web.Security;
using Nucleo.Context;
using Nucleo.Security;
using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	public class MembershipUserSecurityService : IUserSecurityService
	{
		#if NET20
		private HttpContext _context = null;
#else
		private HttpContextBase _context = null;
#endif



		#region " Properties "

#if NET20
		private HttpContext Context
		{
			get { return _context; }
		}
#else
		private HttpContextBase Context
		{
			get { return _context; }
		}
#endif

		#endregion



		#region " Constructors "

#if NET20
		public MembershipUserSecurityService()
			: this(HttpContext.Current) { }

		public MembershipUserSecurityService(HttpContext context)
		{
			_context = context;
		}
#else
		public MembershipUserSecurityService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public MembershipUserSecurityService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public RoleCollection GetRolesForUser()
		{
			return new RoleCollection(Roles.GetRolesForUser());
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
			return Roles.IsUserInRole(role);
		}

		public bool IsLoggedIn()
		{
			return (this.Context.User.Identity != null && this.Context.User.Identity.IsAuthenticated);
		}

		#endregion
	}
}
