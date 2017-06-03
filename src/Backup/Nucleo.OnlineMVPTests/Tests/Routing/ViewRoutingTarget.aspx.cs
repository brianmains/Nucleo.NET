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
	public interface IViewRoutingTargetView : IView { }

	public class ViewRoutingTargetPresenter : BasePresenter
	{
		public ViewRoutingTargetPresenter(IViewRoutingTargetView view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(ViewRoutingTargetPresenter))]
	public partial class ViewRoutingTarget : BaseViewPage, IViewRoutingTargetView
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}