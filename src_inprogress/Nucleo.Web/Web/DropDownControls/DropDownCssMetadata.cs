using System;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Web.DropDownControls
{
	public class DropDownCssMetadata : WebCssMetadata
	{
		#region " Properties "

		new public DropDown Component
		{
			get { return (DropDown)base.Component; }
		}

		#endregion



		#region " Methods "

		public override CssReferenceRequestDetailsCollection GetPrimaryCss()
		{
			return new CssReferenceRequestDetailsCollection(new CssReferenceRequestDetails(
				this.Component.Page.ClientScript.GetWebResourceUrl(typeof(DropDown),
					"Nucleo.Web.DropDownControls.DropDownStyles.css")));
		}

		#endregion
	}
}
