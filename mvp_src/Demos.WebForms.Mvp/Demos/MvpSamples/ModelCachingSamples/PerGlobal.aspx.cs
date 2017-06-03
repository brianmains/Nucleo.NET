using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Core;
using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Models;
using Nucleo.Web.Models.Cache;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.ModelCachingSamples
{
	public class PerGlobalModel : BaseCacheableModel
	{
		public List<string> Items
		{
			get { return (List<string>)this.GetValue("Items", ShareAccessLevel.Global); }
			set { this.SetValue("Items", value, ShareAccessLevel.Global); }
		}
	}

	public interface IPerGlobalView : IView<PerGlobalModel>
	{

	}

	public class PerGlobalPresenter : BasePresenter<IPerGlobalView>
	{
		public PerGlobalPresenter(IPerGlobalView view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(PerGlobalPresenter))]
	public partial class PerGlobal : DemoViewPage<PerGlobalModel>, IPerGlobalView
	{
		public override string Description
		{
			get { return "This example uses a global model."; }
		}

		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.ModelCache = new WebRequestModelCache();

			base.OnInit(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			rpt.DataSource = new object[] { new object(), new object(), new object() };
			rpt.DataBind();
		}
	}
}