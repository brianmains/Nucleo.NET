using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Items
{
	/// <summary>
	/// Represents the display item for informational validation messages.
	/// </summary>
	public class InformationValidationDisplayItem : BaseValidationDisplayItem
	{
		protected override string GetCssClassName()
		{
			return "NucleoValidationItemInformation";
		}

		public override void RenderContent(BaseControlWriter writer)
		{
			writer.Write("<span>");

			writer.Write(this.Message);

			writer.Write("</span>");
		}
	}
}
