using System;
using System.Web;
using System.Collections.Specialized;


namespace Nucleo.Services
{
	public class WebRequestHeaderService : NameValueCollectionService, IRequestHeaderService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public WebRequestHeaderService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebRequestHeaderService(HttpContextBase context)
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
			return this.Context.Request.Headers;
		}

		#endregion
	}
}
