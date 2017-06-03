using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Web.Core;


namespace Nucleo.Web.StandardizationControls
{
	public class StandardizationManager : BaseControl
	{
		#region " Methods "

		protected override void OnInit(EventArgs e)
		{
			var mgr = WebSingletonManager.GetCurrent();
			mgr.AddEntry(this);

			base.OnInit(e);
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			
		}

		#endregion
	}
}
