using System;
using System.Web;
using System.Web.UI;

using Nucleo.Context;
using Nucleo.Web.Core;
using Nucleo.Web.Searching;


namespace Nucleo.Web.Pages
{
	/// <summary>
	/// Represents the context of a request.
	/// </summary>
	public class PageRequestContext
	{
		private IApplicationContext _applicationContext = null;
		private IWebContext _context = null;
		private IControlSearcher _controlSearcher = null;
		private IWebSingletonManager _singletons = null;
				


		#region " Properties "

		/// <summary>
		/// Gets or sets the application context reference to use for the current request.
		/// </summary>
		public IApplicationContext AppContext
		{
			get { return _applicationContext; }
			set { _applicationContext = value; }
		}

		/// <summary>
		/// Gets or sets the reference to the context to use for the current request.
		/// </summary>
		public IWebContext Context
		{
			get { return _context; }
			set { _context = value; }
		}

		/// <summary>
		/// Gets or sets the component to search control hierarchies.
		/// </summary>
		public IControlSearcher ControlSearcher
		{
			get { return _controlSearcher; }
			set { _controlSearcher = value; }
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



		#region " Methods "

		public static PageRequestContext Create()
		{
			if (HttpContext.Current == null || HttpContext.Current.CurrentHandler == null)
				return null;

			if (HttpContext.Current.Items.Contains(typeof(PageRequestContext)))
				return (PageRequestContext)HttpContext.Current.Items[typeof(PageRequestContext)];

			PageRequestContext ctx = null;

			lock (typeof(PageRequestContext))
			{
				if (!HttpContext.Current.Items.Contains(typeof(PageRequestContext)))
				{
					ctx = new PageRequestContext
					{
						AppContext = ApplicationContext.GetCurrent(),
						Context = WebContext.GetCurrent(),
						ControlSearcher = new WebControlSearcher(),
						Singletons = WebSingletonManager.GetCurrent()
					};

					HttpContext.Current.Items[typeof(PageRequestContext)] = ctx;
				}
			}

			return ctx;
		}

		public static PageRequestContext GetCurrent(Control control)
		{
			if (control.Page != null && control.Page is IPageDriver)
				return ((IPageDriver)control.Page).CurrentContext;
			if (control is IPageDriver)
				return ((IPageDriver)control).CurrentContext;

			//return (PageRequestContext)HttpContext.Current.Items[typeof(PageRequestContext)];
			return Create();
		}

		#endregion
	}
}
