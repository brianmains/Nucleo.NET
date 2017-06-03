using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Presentation;
using Nucleo.Web.Views;


namespace Nucleo.Tests.SkippingPresenter
{
	public partial class NoPresenter : BaseViewPage
	{
		#region " Methods "

		protected override IPresenter CreatePresenter()
		{
			return null;
		}

		#endregion
	}
}