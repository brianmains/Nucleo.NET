using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Tags;


namespace Nucleo.Web.MathControls
{
	public class CalculatorViewWebFormsWebRenderer : WebRenderer
	{
		#region " Properties "

		new public CalculatorView Component
		{
			get { return (CalculatorView)base.Component; }
		}

		#endregion



		#region " Methods "

		public override TagElement Render()
		{
			TagElement tag = null;

			if (this.Component.Appearance == CalculatorViewAppearance.Custom)
			{
				if (this.Component.ViewTemplate == null)
					throw new NullReferenceException("The view template must be provided");

				Panel panel = new Panel();
				panel.ID = this.Component.ClientID + "_template";
				this.Component.ViewTemplate.InstantiateIn(panel);

				using (StringWriter textWriter = new StringWriter())
				{
					HtmlTextWriter htmlWriter = new HtmlTextWriter(textWriter);
					panel.RenderControl(htmlWriter);

					tag.Content = textWriter.ToString();
				}
			}
			else if (this.Component.Appearance == CalculatorViewAppearance.Editable)
			{
				tag = TagElementBuilder.Create("INPUT");
				tag.Attributes.AppendAttribute("type", "text");
			}
			else if (this.Component.Appearance == CalculatorViewAppearance.Readonly)
			{
				tag = TagElementBuilder.Create("SPAN");
			}
			else
				throw new NotImplementedException();

			CommonTagSettings.SetIdentifiers(tag, this.Component);

			return tag;
		}

		#endregion
	}
}
