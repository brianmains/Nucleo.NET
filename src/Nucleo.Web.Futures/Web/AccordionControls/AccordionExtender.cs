using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.ClientRegistration;


namespace Nucleo.Web.AccordionControls
{
	public class AccordionExtender : BaseAjaxExtender
	{
		#region " Event Handlers "

		public event CommandEventHandler ItemCommand;

		#endregion



		#region " Properties "

		[ClientProperty("loadOnDemand", false)]
		public bool LoadOnDemand
		{
			get { return (bool)(ViewState["LoadOnDemand"] ?? false); }
			set  { ViewState["LoadOnDemand"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			base.GetAjaxScriptDescriptors(registrar, targetControl);
		}

		protected override bool OnBubbleEvent(object source, EventArgs args)
		{
			if (args is CommandEventArgs)
				this.OnItemCommand((CommandEventArgs)args);

			return base.OnBubbleEvent(source, args);
		}

		protected virtual void OnItemCommand(CommandEventArgs e)
		{
			if (ItemCommand != null)
				ItemCommand(this, e);
		}

		#endregion
	}
}
