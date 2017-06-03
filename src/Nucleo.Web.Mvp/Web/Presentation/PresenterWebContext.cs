using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Context;
using Nucleo.Presentation;
using Nucleo.Web.Core;


namespace Nucleo.Web.Presentation
{
	/// <summary>
	/// Represents the context for a web request via the presenter.
	/// </summary>
	public class PresenterWebContext : PresenterContext
	{
		private IWebContext _context = null;
		private HttpContextBase _httpContext = null;
		private IWebSingletonManager _singletons = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the reference to the context to use for the current request.
		/// </summary>
		public IWebContext Context
		{
			get { return _context; }
			set { _context = value; }
		}

		public HttpContextBase HttpContext
		{
			get { return _httpContext; }
			set { _httpContext = value; }
		}

		/// <summary>
		/// Gets the service that works with singletons.
		/// </summary>
		public IWebSingletonManager Singletons
		{
			get { return _singletons; }
			set { _singletons = value; }
		}

		#endregion
	}
}
