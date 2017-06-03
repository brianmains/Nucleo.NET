using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.OnlineMVPTests.Presenters;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.OnlineMVPTests.Views
{
	public interface IViewCustomersView : IView
	{

	}

	public partial class ViewCustomers : BaseViewPage, IViewCustomersView 
	{
		protected override IPresenter CreatePresenter()
		{
			return new ViewCustomersPresenter(this);
		}

	}
}
