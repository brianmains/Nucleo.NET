using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Core;
using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Views;
using Nucleo.Web.Models;
using Nucleo.Web.Models.Cache;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.ModelCachingSamples
{
	public class FirstLookModel : BaseCacheableModel
	{
		public List<string> Items
		{
			get { return (List<string>)this.GetValue("Items", ShareAccessLevel.Global); }
			set { this.SetValue("Items", value, ShareAccessLevel.Global); }
		}
	}

	public interface IFirstLookView : IView<FirstLookModel>
	{

	}

	public class FirstLookPresenter : BasePresenter<IFirstLookView>
	{
		public FirstLookPresenter(IFirstLookView view)
			: base(view)
		{
			view.Initializing += new EventHandler(View_Initializing);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.View.Model = new FirstLookModel
			{
				Items = new List<string> { "First", "Second", "Third" }
			};
		}

		protected override PresenterContext CreatePresenterContext()
		{


			return base.CreatePresenterContext();
		}
	}

	[PresenterBinding(typeof(FirstLookPresenter))]
	public partial class FirstLook : DemoViewPage<FirstLookModel>, IFirstLookView
	{
		public override string Description
		{
			get { return "A first look at model caching."; }
		}

		protected override void OnInit(EventArgs e)
		{
			FrameworkSettings.ModelCache = new WebRequestModelCache();

			base.OnInit(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.ddl.DataSource = this.Model.Items;
			this.ddl.DataBind();
		}
	}
}