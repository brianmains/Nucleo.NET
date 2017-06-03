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

namespace Nucleo.Tests.Customizations
{
	public class SampleDiscoveryStrategy : IPresentationDiscoveryStrategy
	{

		public Type FindPresenterType(DiscoveryOptions options)
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
	public partial class PresenterDiscovery : BaseViewPage<PresenterDiscoveryModel>, IPresenterDiscoveryView
	{
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