using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.EventsManagement;
using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Web.Presentation.Context;
using Nucleo.Views;
using Nucleo.Web.Context;
using Nucleo.Web.Core;


namespace Nucleo.Web.Presentation
{
	/// <summary>
	/// Represents the presenter for a web environment.
	/// </summary>
	public class BaseWebPresenter : BasePresenter
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the current context.
		/// </summary>
		new public PresenterWebContext CurrentContext
		{
			get { return (PresenterWebContext)base.CurrentContext; }
			set { base.CurrentContext = value; }
		}

		#endregion



		#region " Constructors "

		public BaseWebPresenter(IView view)
			: base(view) { }

		#endregion



		#region " Methods "

		protected override PresenterContext CreatePresenterContext()
		{
			return PresenterWebContextCreator.Create();

			//PresenterWebContext context = null;

			//if (WebPresenterContextCache.CanCache)
			//{
			//    context = WebPresenterContextCache.CurrentContext;
			//    if (context != null)
			//        return context;
			//}

			//lock (typeof(WebPresenterContextCache))
			//{
			//    context = new PresenterWebContext();
			//    context.AppContext = ApplicationContext.GetCurrent();
			//    context.Context = WebContext.GetCurrent();
			//    context.EventRegistry = new EventsRegistry();
			//    context.Singletons = new WebSingletonManager(context.Context);
			//    context.HttpContext = new HttpContextWrapper(HttpContext.Current);

			//    if (WebPresenterContextCache.CanCache)
			//        WebPresenterContextCache.CurrentContext = context;
			//}

			//return context;
		}

		#endregion
	}
}
