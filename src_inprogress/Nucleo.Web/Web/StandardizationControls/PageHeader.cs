using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.StandardizationControls
{
	public class PageHeader : BaseHeader
	{
		#region " Properties "

		protected override string RootCssClass
		{
			get { return "NucleoPageHeader"; }
		}

		protected override string RootTag
		{
			get { return "H1"; }
		}

		#endregion
	}
}
