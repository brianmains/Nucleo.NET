using System;
using System.Web;
using System.Collections.Generic;

using Nucleo.Context;
using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsPostedFilesService : IPostedFilesService
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
		public WebFormsPostedFilesService()
			: this(HttpContext.Current) { }

		public WebFormsPostedFilesService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsPostedFilesService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsPostedFilesService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

#if NET20
		public PostedFile Get(string key)
		{
			return new PostedFile(_context.Request.Files.Get(key));
		}

		public PostedFile Get(int index)
		{
			return new PostedFile(_context.Request.Files.Get(index));
		}
#else
		public PostedFile Get(string key)
		{
			return new PostedFile(this.Context.Request.Files.Get(key));
		}

		public PostedFile Get(int index)
		{
			return new PostedFile(this.Context.Request.Files.Get(index));
		}
#endif

		#endregion
	}
}
