using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Lookups;


namespace Nucleo.Web.Lookups
{
	public partial class FirstLook : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			ILookupRepository repository = LookupManager.Create().GetLookupRepository("Countries");
			this.gvwLookups.DataSource = repository.GetAllValues(null);
			this.gvwLookups.DataBind();
		}
	}
}