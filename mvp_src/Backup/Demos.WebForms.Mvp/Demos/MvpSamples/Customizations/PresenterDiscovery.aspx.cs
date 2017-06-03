using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Presentation.Discovery;
using Nucleo.Core;
using Nucleo.Core.Options;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Customizations
{
	public class SampleDiscoveryStrategy : IPresentationDiscoveryStrategy
	{

		public Type FindPresenterType(PresenterDiscoveryOptions options)
		{
			//Hard code the type here, but any process can do this.
			return typeof(PresenterDiscoveryPresenter);
		}
	}

	public class PresenterDiscoveryModel
	{
		public object Data { get; set; }
	}

	public class PresenterDiscoveryPresenter : BasePresenter<IPresenterDiscoveryView>
	{
		public PresenterDiscoveryPresenter(IPresenterDiscoveryView view)
			: base(view)
		{
			view.Starting += new EventHandler(View_Starting);
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new PresenterDiscoveryModel
			{
				Data = new[]
				{
					new { Name = "A", Value = 1 },
					new { Name = "B", Value = 2 },
					new { Name = "C", Value = 3 }
				}
			};
		}
	}

	public interface IPresenterDiscoveryView : IView<PresenterDiscoveryModel> { }

	[PresenterBinding(typeof(PresenterDiscoveryPresenter))]
	public partial class PresenterDiscovery : DemoViewPage<PresenterDiscoveryModel>, IPresenterDiscoveryView
	{
		public override string Description
		{
			get { return "<p>This example illustrates how the discovery process works.  Using a discovery strategy, the framework attempts to match a presenter based upon the given view type.  This is the ultimate level of flexibility to the view/presenter relationship possible, because the view could be linked to the presenter through an attribute, by convention, through MEF, or any other process that you could possibly think of.</p>"; }
		}



		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.DiscoveryStrategy = new SampleDiscoveryStrategy();

			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model != null && this.Model.Data != null)
			{
				this.gvw.DataSource = this.Model.Data;
				this.gvw.DataBind();
			}
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);

			FrameworkSettings.DiscoveryStrategy = new DefaultPresentationDiscoveryStrategy();
		}
	}
}