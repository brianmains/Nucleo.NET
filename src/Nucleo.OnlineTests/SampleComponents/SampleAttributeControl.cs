using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web;
using Nucleo.Web.ClientRegistration;

[assembly: WebResource("Nucleo.SampleComponents.SampleAttributeControl.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.SampleComponents.SampleAttributeControl.js", "text/javascript")]
[assembly: WebResource("Nucleo.SampleComponents.SampleAttributeScripts.debug.js", "text/javascript")]
[assembly: WebResource("Nucleo.SampleComponents.SampleAttributeScripts.js", "text/javascript")]


namespace Nucleo.SampleComponents
{
	[
	ClientDescriptionRegistration,
	ClientScript("Nucleo.SampleComponents.SampleAttributeScripts", "Nucleo.OnlineTests", ScriptModes.Debug),
	ClientScript(typeof(SampleAttributeControl)),
	ClientCss("Nucleo.SampleComponents.SampleAttributeStyles.css"),
	WebRenderer(typeof(SampleAttributeControlRenderer))
	]
	public class SampleAttributeControl : BaseAjaxControl
	{
		#region " Events "

		[ClientEvent("textChanged", ClientEventHandlerPropertyName = "OnClientTextChanged")]
		public event EventHandler TextChanged;

		#endregion



		#region " Properties "

		[ClientProperty("alertMessage")]
		public string AlertMessage
		{
			get { return (string)ViewState["AlertMessage"]; }
			set { ViewState["AlertMessage"] = value; }
		}

		[ClientEvent("alerted")]
		public string OnClientAlerted
		{
			get { return (string)ViewState["OnClientAlerted"]; }
			set { ViewState["OnClientAlerted"] = value; }
		}

		public string OnClientTextChanged
		{
			get { return (string)ViewState["OnClientTextChanged"]; }
			set { ViewState["OnClientTextChanged"] = value; }
		}

		[ClientProperty("text")]
		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		#endregion
	}
}
