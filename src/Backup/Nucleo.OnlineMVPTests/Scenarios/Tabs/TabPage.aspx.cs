using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Scenarios.Tabs
{
	public class TabPagePresenter : BasePresenter<ITabPageView>
	{
		public TabPagePresenter(ITabPageView view)
			: base(view) { }
	}

	public class TabPageModel
	{

	}

	public interface ITabPageView : IView<TabPageModel>
	{

	}

	[PresenterBinding(typeof(TabPagePresenter))]
	public partial class TabPage : BaseViewPage<TabPageModel>, ITabPageView
	{
		
	}
}