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
	public interface IRoutingTargetView : IView { }

	public class RoutingTargetPresenter : BasePresenter
	{
		public RoutingTargetPresenter(IRoutingTargetView view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(RoutingTargetPresenter))]
	public partial class RoutingTarget : DemoViewPage, IRoutingTargetView
	{
		public override string Description
		{
			get { return "If you've gotten here, you know the routing feature works."; }
		}
	}
}