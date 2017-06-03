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
	public class PerModelModel : BaseCacheableModel
	{
		public List<string> Items
		{
			get { return (List<string>)this.GetValue("Items", ShareAccessLevel.PerModel); }
			set { this.SetValue("Items", value, ShareAccessLevel.PerModel); }
		}
	}

	public interface IPerModelView : IView<PerModelModel>
	{

	}

	public class PerModelPresenter : BasePresenter<IPerModelView>
	{
		public PerModelPresenter(IPerModelView view)
			: base(view)
		{

		}
	}

	[PresenterBinding(typeof(PerModelPresenter))]
	public partial class PerModel : DemoViewPage<PerModelModel>, IPerModelView
	{
		public override string Description
		{
			get { return "Per model usage of caching"; }
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