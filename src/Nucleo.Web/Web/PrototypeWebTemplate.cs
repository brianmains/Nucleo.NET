using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web
{
	public class PrototypeWebTemplate : WebTemplate
	{
		#region " Properties "

		public override WebTemplateFormat Format
		{
			get { return WebTemplateFormat.Prototype; }
		}

		#endregion



		#region " Constructors "

		public PrototypeWebTemplate()
			: base() { }

		public PrototypeWebTemplate(string template)
			: base(template) { }

		#endregion



		#region " Methods "

		public override string Evaluate(Dictionary<string, object> parameters)
		{
			string output = this.Template;

			if (parameters != null)
			{
				foreach (KeyValuePair<string, object> parameter in parameters)
					output = output.Replace("#{{" + parameter.Key + "}}", (parameter.Value != null) ? parameter.Value.ToString() : "");
			}

			return output;
		}

		protected override void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddPropertyIfExists("contentTemplate", this);
		}

		protected override void RegisterAjaxReferences(IContentRegistrar registrar)
		{
#if DEBUG
			registrar.AddReference(new ScriptReferencingRequestDetails(typeof(PrototypeWebTemplate), ScriptMode.Debug));
#else
			throw new NotSupportedException("No prod script for webtemplate");
#endif
		}

		#endregion
	}
}
