using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Pages;


namespace Nucleo.Web.Core
{
	public partial class ControlLifecycle : PageBase
	{
		#region " Methods "

		protected override void OnInitializing(EventArgs e)
		{
			base.OnInitializing(e);

			lblEvents.Text += "Initializing Fired<br/>";
		}

		protected override void OnLoading(EventArgs e)
		{
			base.OnLoading(e);

			lblEvents.Text += "Loading Fired<br/>";
		}

		protected override void OnPrepareToRender(EventArgs e)
		{
			base.OnPrepareToRender(e);

			lblEvents.Text += "PrepareToRender Fired<br/>";
		}

		protected override void OnRendered(EventArguments.RenderEventArgs e)
		{
			base.OnRendered(e);

			lblEvents.Text += "Rendered Fired<br/>";
		}

		protected override void OnRendering(EventArguments.RenderEventArgs e)
		{
			base.OnRendering(e);

			lblEvents.Text += "Rendering Fired<br/>";
		}

		protected override void OnStartup(EventArgs e)
		{
			base.OnStartup(e);

			lblEvents.Text += "Startup Fired<br/>";
		}

		protected override void OnUnloading(EventArgs e)
		{
			base.OnUnloading(e);

			lblEvents.Text += "Unloading Fired<br/>";
		}

		protected override void OnValidated(EventArgs e)
		{
			base.OnValidated(e);

			lblEvents.Text += "Validated Fired<br/>";
		}

		protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
		{
			base.OnValidating(e);

			lblEvents.Text += "Validating Fired<br/>";
		}

		protected override void OnValidateState(EventArguments.ValidateEventArgs e)
		{
			base.OnValidateState(e);

			lblEvents.Text += "ValidateState Fired<br/>";
		}

		#endregion
	}
}