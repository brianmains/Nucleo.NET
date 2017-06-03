using System;
using System.Web;
using Nucleo.Context.Services;
using Nucleo.Security;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsUserSecurityService : IUserSecurityService
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
		public WebFormsUserSecurityService()
			: this(HttpContext.Current) { }

		public WebFormsUserSecurityService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsUserSecurityService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsUserSecurityService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public RoleCollection GetRolesForUser()
		{
			return null;
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
