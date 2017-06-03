using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;


namespace Nucleo.Web.Templates
{
	/// <summary>
	/// Represents a template that can be used for both client only rendering and client/server rendering.
	/// </summary>
	public class ElementTemplate : IScriptComponent
	{
		private IElementTemplate _clientTemplate = null;
		private ClientTemplateEvaluation _clientTemplateEvaluator = ClientTemplateEvaluation.MSAjaxFormatString;
		private ClientPropertyNamingDetails _nameDetails = null;
		private IElementTemplate _serverTemplate = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the client-side template.  This client-side template is used for client-side only binding.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
		]
		public IElementTemplate ClientTemplate
		{
			get { return _clientTemplate; }
			set { _clientTemplate = value; }
		}

		/// <summary>
		/// Gets or sets the evaluator that processes client-side templates.  Some script libraries have the ability to process templates (like Prototype, or MS AJAX).
		/// </summary>
		public ClientTemplateEvaluation ClientTemplateEvaluator
		{
			get { return _clientTemplateEvaluator; }
			set { _clientTemplateEvaluator = value; }
		}

		/// <summary>
		/// Gets or sets the details regarding the name of the client side template that this template maps to.  This is used in relation to <see cref="IScriptComponent">script component description</see>.
		/// </summary>
		public ClientPropertyNamingDetails NameDetails
		{
			get { return _nameDetails; }
			set { _nameDetails = value; }
		}

		/// <summary>
		/// Gets or sets the server-side template.  This server-side template is used for controls that render in server only mode or client/server mode.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
		]
		public IElementTemplate ServerTemplate
		{
			get { return _serverTemplate; }
			set { _serverTemplate = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates a new element template.
		/// </summary>
		public ElementTemplate() { }

		/// <summary>
		/// Creates a new element template using the naming details for the client-side description process.
		/// </summary>
		/// <param name="nameDetails">The details of the name.</param>
		public ElementTemplate(ClientPropertyNamingDetails nameDetails)
		{
			_nameDetails = nameDetails;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the client template; uses the server template when the client template is null.
		/// </summary>
		/// <returns>The template that's the client template, or server template when the client template is null.</returns>
		public IElementTemplate GetClientTemplate()
		{
			if (this.ClientTemplate != null)
				return this.ClientTemplate;
			else
				return this.ServerTemplate;
		}

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			IElementTemplate clientTemplate = this.GetClientTemplate();
			if (clientTemplate != null)
				currentDescriptor.AddPropertyIfExists(this.NameDetails.ClientPropertyName, clientTemplate.GetTemplate());
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar) { }

		#endregion
	}
}
