using System;
using System.Web;
using System.Collections.Specialized;


namespace Nucleo.Services
{
	public class WebServerVariablesService : NameValueCollectionService, IServerVariablesService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public WebServerVariablesService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebServerVariablesService(HttpContextBase context)
		{
			_context = context;
		}

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
