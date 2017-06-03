using System;
using System.Web;
using System.Collections.Specialized;

using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsServerVariablesService : ContextBasedServiceDictionary, IServerVariablesService
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
		public WebFormsServerVariablesService()
			: this(HttpContext.Current) { }

		public WebFormsServerVariablesService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsServerVariablesService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsServerVariablesService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public NameValueCollection GetAll()
		{
			return this.GetUnderlyingCollection();
		}

		protected override NameValueCollection GetUnderlyingCollection()
		{
			return this.Context.Request.ServerVariables;
		}

		#endregion
	}
}
