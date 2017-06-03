using System;
using System.Web;
using System.Collections.Generic;

using Nucleo.IO;


namespace Nucleo.Services
{
	public class WebPostedFilesService : IPostedFilesService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		#endregion



		#region " Constructors "

		public WebPostedFilesService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebPostedFilesService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public PostedFile Get(string key)
		{
			return new PostedFile(this.Context.Request.Files.Get(key));
		}

		public PostedFile Get(int index)
		{
			return new PostedFile(this.Context.Request.Files.Get(index));
		}

		#endregion
	}
}
