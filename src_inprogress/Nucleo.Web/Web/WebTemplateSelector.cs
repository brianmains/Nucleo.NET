using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web
{
	[ControlBuilder(typeof(WebTemplateSelectorControlBuilder))]
	public class WebTemplateSelector : WebTemplate
	{
		private WebTemplateFormat _format = WebTemplateFormat.Prototype;



		#region " Properties "

		/// <summary>
		/// Gets the format of the template.
		/// </summary>
		public override WebTemplateFormat Format
		{
			get { return _format; }
		}

		/// <summary>
		/// Gets or sets the format of the template that's targeted.
		/// </summary>
		public WebTemplateFormat TargetFormat
		{
			get { return _format; }
			set { _format = value; }
		}

		#endregion



		#region " Methods "

		public override string Evaluate(Dictionary<string, object> parameters)
		{
			return this.GetTemplate().Evaluate(parameters);
		}

		private WebTemplate GetTemplate()
		{
			if (this.Format == WebTemplateFormat.Prototype)
				return new PrototypeWebTemplate(this.Template);
			else
				throw new NotImplementedException();
		}

		protected override void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			((IScriptComponent)this.GetTemplate()).RegisterAjaxDescriptors(registrar, currentDescriptor);
		}

		protected override void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			((IScriptComponent)this.GetTemplate()).RegisterAjaxReferences(registrar);
		}

		#endregion
	}


	public class WebTemplateSelectorControlBuilder : ControlBuilder
	{
		public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
		{
			return typeof(LiteralControl);
		}
	}
}
