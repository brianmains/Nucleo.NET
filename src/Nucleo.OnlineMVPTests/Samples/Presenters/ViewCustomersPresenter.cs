using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.OnlineMVPTests.Views;


namespace Nucleo.OnlineMVPTests.Presenters
{
	public class ViewCustomersPresenter : BaseWebPresenter<IViewCustomersView>
	{
		#region " Constructors "

		public ViewCustomersPresenter(IViewCustomersView view)
			: base(view) { }

		#endregion
	}
}
