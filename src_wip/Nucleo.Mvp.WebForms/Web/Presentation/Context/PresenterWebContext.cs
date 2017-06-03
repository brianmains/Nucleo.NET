using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Context;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Services;


namespace Nucleo.Web.Presentation.Context
{
	/// <summary>
	/// Represents the context for a web request via the presenter.
	/// </summary>
	public class PresenterWebContext : PresenterContext
	{
		private HttpContextBase _httpContext = null;
		private IStaticInstanceManager _singletons = null;



		#region " Properties "

		public HttpContextBase HttpContext
		{
			get { return _httpContext; }
			set { _httpContext = value; }
		}

		/// <summary>
		/// Gets the service that works with singletons.
		/// </summary>
		public IStaticInstanceManager Singletons
		{
			get { return _singletons; }
			set { _singletons = value; }
		}

		#endregion
	}
}
