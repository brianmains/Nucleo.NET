using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Items
{
	/// <summary>
	/// Represents the display item for erroring validation items.
	/// </summary>
	public class ErrorValidationDisplayItem : BaseValidationDisplayItem
	{
		#region " Methods "

		protected override string GetCssClassName()
		{
			return "NucleoValidationItemError";
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
