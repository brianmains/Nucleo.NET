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
	public class FirstLook1Model : BaseCacheableModel
	{
		public List<string> Items
		{
			get { return (List<string>)this.GetValue("Items", ShareAccessLevel.Global); }
			set { this.SetValue("Items", value, ShareAccessLevel.Global); }
		}
	}

	public interface IFirstLook1View : IView<FirstLook1Model>
	{

	}

	public class FirstLook1Presenter : BasePresenter<IFirstLook1View>
	{
		public FirstLook1Presenter(IFirstLook1View view)
			: base(view)
		{
			this.View.Model = new FirstLook1Model();
		}
	}

	[PresenterBinding(typeof(FirstLook1Presenter))]
	public partial class FirstLook1 : DemoViewUserControl<FirstLook1Model>, IFirstLook1View
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.ddl.DataSource = this.Model.Items;
			this.ddl.DataBind();
			this.ddl.DataBind();
		}
	}
}