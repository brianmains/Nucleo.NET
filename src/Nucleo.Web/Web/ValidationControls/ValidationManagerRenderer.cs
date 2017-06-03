using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Tags;


namespace Nucleo.Web.ValidationControls
{
	public class ValidationManagerRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public ValidationManager Component
		{
			get { return (ValidationManager)base.Component; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			//Don't render UI.
			TagElement el = new TagElement("div");
			CommonTagSettings.SetIdentifiers(el, this.Component);

			writer.Write(el.ToHtmlString());
		}

		#endregion
	}
}
