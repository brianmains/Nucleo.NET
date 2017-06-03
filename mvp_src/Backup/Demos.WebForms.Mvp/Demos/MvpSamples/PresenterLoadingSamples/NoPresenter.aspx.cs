using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.PresenterLoadingSamples
{
	public partial class NoPresenter : DemoViewPage
	{
		#region " Methods "

		public override string Description
		{
			get { return "This page illustrates that a page can exist without a presenter.  In the MVP framework, a presenter is not always required.  Use a presenter where you feel necessary."; }
		}

		protected override IPresenter CreatePresenter()
		{
			return null;
		}

		#endregion
	}
}