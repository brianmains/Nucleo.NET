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
	public class FirstLook2Model : BaseCacheableModel
	{
		public List<string> Items
		{
			get { return (List<string>)this.GetValue("Items", ShareAccessLevel.Global); }
			set { this.SetValue("Items", value, ShareAccessLevel.Global); }
		}
	}

	public interface IFirstLook2View : IView<FirstLook2Model>
	{

	}

	public class FirstLook2Presenter : BasePresenter<IFirstLook2View>
	{
		public FirstLook2Presenter(IFirstLook2View view)
			: base(view)
		{
			this.View.Model = new FirstLook2Model();
		}
	}

	[PresenterBinding(typeof(FirstLook2Presenter))]
	public partial class FirstLook2 : DemoViewUserControl<FirstLook2Model>, IFirstLook2View
	{


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.ddl.DataSource = this.Model.Items;
			this.ddl.DataBind();
		}
	}
}