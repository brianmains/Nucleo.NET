using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.Hierarchy
{
	public interface IHierarchy2View : IView { }

	public class Hierarchy2Presenter : BasePresenter<IHierarchy2View>
	{
		public Hierarchy2Presenter(IHierarchy2View view)
			: base(view) { }
	}

	[PresenterBinding(typeof(Hierarchy2Presenter))]
	public partial class Hierarchy2 : DemoViewUserControl, IHierarchy2View
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}
	}
}