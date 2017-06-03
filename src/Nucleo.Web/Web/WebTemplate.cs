using System;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the template to use for the web.
	/// </summary>
	public abstract class WebTemplate : IScriptComponent
	{
		private string _template = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the format to use for the template.
		/// </summary>
		public abstract WebTemplateFormat Format
		{
			get;
		}

		/// <summary>
		/// Gets or sets the template for the web template.
		/// </summary>
		[PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
		public string Template
		{
			get { return _template; }
			set { _template = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates a <see cref="WebTemplate">WebTemplate object</see>.
		/// </summary>
		public WebTemplate() { }

		/// <summary>
		/// Creates a <see cref="WebTemplate">WebTemplate object</see>.
		/// </summary>
		/// <param name="template">The template to create.</param>
		public WebTemplate(string template)
		{
			_template = template;
		}

		#endregion



		#region " Methods "

		public abstract string Evaluate(Dictionary<string, object> parameters);

		protected abstract void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor);

		protected abstract void RegisterAjaxReferences(IContentRegistrar registrar);

		#endregion


		#region IScriptComponent Members

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddProperty("contentTemplate", this);
			this.RegisterAjaxDescriptors(registrar, currentDescriptor);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
#if DEBUG
			registrar.AddReference(new ScriptReferencingRequestDetails(typeof(WebTemplate), ScriptMode.Debug));
#else
			throw new NotSupportedException("No prod script for webtemplate");
#endif

			this.RegisterAjaxReferences(registrar);
		}

		#endregion
	}
}
