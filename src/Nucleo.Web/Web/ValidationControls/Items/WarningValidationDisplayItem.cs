using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Items
{
	/// <summary>
	/// Represents the display item for warning validation messages.
	/// </summary>
	public class WarningValidationDisplayItem : BaseValidationDisplayItem
	{
		#region " Methods "

		protected override string GetCssClassName()
		{
			return "NucleoValidationItemWarning";
		}

		public override void RenderContent(BaseControlWriter writer)
		{
			writer.Write("<span>");

			writer.Write(this.Message);

			writer.Write("</span>");
		}

		#endregion
	}
}
