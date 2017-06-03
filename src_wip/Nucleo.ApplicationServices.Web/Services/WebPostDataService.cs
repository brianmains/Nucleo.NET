using System;
using System.Web;
using System.Collections.Specialized;


namespace Nucleo.Services
{
	public class WebPostDataService : IPostDataService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public WebPostDataService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebPostDataService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public string Get(string key)
		{
			return this.Context.Request.Form.Get(key);
		}

		public string Get(int index)
		{
			return this.Context.Request.Form.Get(index);
		}

		public NameValueCollection GetAll()
		{
			return this.Context.Request.Form;
		}

		#endregion
	}
}
