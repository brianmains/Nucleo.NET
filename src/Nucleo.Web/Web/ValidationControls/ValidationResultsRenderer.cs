using System;
using System.Collections.Generic;

using Nucleo.Validation;
using Nucleo.Web.Tags;
using Nucleo.Web.ValidationControls.Items;


namespace Nucleo.Web.ValidationControls
{
	public class ValidationResultsRenderer : WebLegacyRenderer
	{
		#region " Properties "

		new public ValidationResults Component
		{
			get { return (ValidationResults)base.Component; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			TagElement wrapper = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(wrapper, this.Component);
			writer.Write(wrapper.ToHtmlString(TagRenderingMode.BeginTag));

			this.RenderLabel(writer);

			this.RenderList(writer);

			writer.Write("</div>");
		}

		protected virtual void RenderLabel(BaseControlWriter writer)
		{
			writer.Write("<div style='display:" + ((this.Component.Items.Count > 0) ? "block;" : "none;") + "'>");

			writer.Write(this.Component.HeaderMessage);

			writer.Write("</div>");
		}

		protected virtual void RenderList(BaseControlWriter writer)
		{
			writer.Write("<ul class='NucleoValidationList'");

			if (this.Component.Items.Count == 0)
				writer.Write(" style='display:none;'");
			writer.Write(">");

			for (int index = 0, len = this.Component.Items.Count; index < len; index++)
			{
				IRenderableControl validationControl = this.Component.Items[index] as IRenderableControl;
				if (validationControl != null)
					validationControl.RenderUI(writer);
			}

			writer.Write("</ul>");
		}

		#endregion
	}
}
