using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.ContainerControls;


namespace Nucleo.Web.Panel
{
	public partial class TimeSensitivity : Nucleo.Framework.TestPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.pnlTimeSensitivityHidden.TimeSensitivity = new PanelTimeSensitivityOptions
			{
				FilterBeginDate = DateTime.Now.Subtract(new TimeSpan(180, 0, 0, 0)),
				FilterEndDate = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))
			};
			this.pnlTimeSensitivityVisible.TimeSensitivity = new PanelTimeSensitivityOptions
			{
				FilterBeginDate = DateTime.Now.Subtract(new TimeSpan(180, 0, 0, 0)),
				FilterEndDate = DateTime.Now.Add(new TimeSpan(30, 0, 0, 0))
			};
		}
	}
}