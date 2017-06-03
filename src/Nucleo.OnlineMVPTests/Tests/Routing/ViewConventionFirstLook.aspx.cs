using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Routing;
using Nucleo.Web.Routing;


namespace Nucleo.Tests.Routing
{
	public interface IViewConventionFirstLookView : IView
	{
		event EventHandler Redirect;
	}

	public class ViewConventionFirstLookPresenter : BasePresenter
	{
		//Would rather put in the presenter context or somewhere else (statically exposed).  For demo purposes.
		private RoutingEngines _engines = new RoutingEngines();

		public ViewConventionFirstLookPresenter(IViewConventionFirstLookView view)
			: base(view) 
		{
			view.Initializing += new EventHandler(View_Initializing);
			view.Redirect += new EventHandler(View_Redirect);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			_engines.Engines.Add(new ViewConventionRoutingEngine("~/Tests", "Tests"));
		}

		void View_Redirect(object sender, EventArgs e)
		{
			_engines.Navigate(typeof(IViewRoutingTargetView));
		}
	}

	[PresenterBinding(typeof(ViewConventionFirstLookPresenter))]
	public partial class ViewConventionFirstLook : BaseViewPage, IViewConventionFirstLookView
	{
		public event EventHandler Redirect;


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (Redirect != null)
				Redirect(this, e);
		}
	}
}