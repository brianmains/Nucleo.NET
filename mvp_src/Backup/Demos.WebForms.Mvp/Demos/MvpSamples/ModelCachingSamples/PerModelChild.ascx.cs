using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Models;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Models;
using Nucleo.Web.Models.Cache;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.ModelCachingSamples
{
	public class PerModelChildModel : BaseCacheableModel
	{
		public List<string> Items
		{
			get { return (List<string>)this.GetValue("Items", ShareAccessLevel.PerModel); }
			set { this.SetValue("Items", value, ShareAccessLevel.PerModel); }
		}
	}

	public interface IPerModelChildView : IView<PerModelChildModel>
	{

	}

	public class PerModelChildPresenter : BasePresenter<IPerModelChildView>
	{
		public PerModelChildPresenter(IPerModelChildView view)
			: base(view)
		{
			this.View.Model = new PerModelChildModel();
			this.View.Initializing += new EventHandler(View_Initializing);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			if (this.View.Model.Items == null)
				this.View.Model.Items = new List<string> { "First", "Second", "Third" };
			else
			{
				//To illustrate pulling from cache
				System.Web.HttpContext.Current.Response.Write("Pulled from cache.<br/>");
			}
		}
	}

	[PresenterBinding(typeof(PerModelChildPresenter))]
	public partial class PerModelChild : DemoViewUserControl<PerModelChildModel>, IPerModelChildView
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.ddl.DataSource = this.Model.Items;
			this.ddl.DataBind();
		}
	}
}