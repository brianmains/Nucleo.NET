using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Layout
{
	public partial class DemoWindow : System.Web.UI.UserControl
	{
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate Content { get; set; }



		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Content != null)
				this.Content.InstantiateIn(this.Window);
		}
	}
}