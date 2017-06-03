using System;
using System.Web.UI;

using Nucleo.Web.Tags;
using Nucleo.Web.Templates;


namespace Nucleo.Web.FormControls
{
	public class FormItemDisplayRenderer : WebLegacyRenderer
	{
		private IElementTemplate _template = null;



		#region " Properties "

		new public FormItemDisplay Component
		{
			get { return (FormItemDisplay)base.Component; }
		}

		public IElementTemplate Template
		{
			get { return _template; }
			set { _template = value; }
		}

		#endregion



		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("DIV");
			CommonTagSettings.SetIdentifiers(tag, this.Component);

			writer.WriteLine(tag.ToHtmlString(TagRenderingMode.BeginTag));

			this.RenderContent(writer);

			writer.WriteLine(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		private void RenderContent(BaseControlWriter writer)
		{
			IElementTemplate template = this.Template;
			if (template == null)
				template = this.Component.CurrentTemplate;
			//If still no template, then display the read only template.
			if (template == null)
				template = this.Component.ReadOnlyTemplate;

			if (template != null)
			{
				if (template.ReturnsContent)
					writer.Write(template.GetTemplate());
				else
					template.InvokeTemplate();
			}
		}

		#endregion
	}
}
