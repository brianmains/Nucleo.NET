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


namespace Nucleo.Demos.MvpSamples.RoutingSamples
{
	public interface IViewConventionsView : IView
	{
		event EventHandler Redirect;
	}

	public class ViewConventionsPresenter : BasePresenter
	{
		//Would rather put in the presenter context or somewhere else (statically exposed).  For demo purposes.
		private RoutingEngines _engines = new RoutingEngines();

		public ViewConventionsPresenter(IViewConventionsView view)
			: base(view)
		{
			view.Initializing += new EventHandler(View_Initializing);
			view.Redirect += new EventHandler(View_Redirect);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			_engines.Engines.Add(new ViewConventionRoutingEngine("~/Demos/MvpSamples", "Nucleo.Demos.MvpSamples"));
		}

		void View_Redirect(object sender, EventArgs e)
		{
			_engines.Navigate(typeof(IRoutingTargetView));
		}
	}

	[PresenterBinding(typeof(ViewConventionsPresenter))]
	public partial class ViewConventions : DemoViewPage, IViewConventionsView
	{
		public event EventHandler Redirect;



		public override string Description
		{
			get { return "This sample illustrates the use of redirection."; }
		}



		protected void btn_Click(object sender, EventArgs e)
		{
			if (Redirect != null)
				Redirect(this, e);
		}
	}
}