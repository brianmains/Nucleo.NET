using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using Nucleo.Web;


namespace Nucleo.Web.Templates
{
	/// <summary>
	/// Represents the template to display for a control.
	/// </summary>
	public class ControlElementTemplate : IElementTemplate
	{
		private ITemplate _template = null;



		#region " Properties "

		/// <summary>
		/// Gets whether the control returns its content.
		/// </summary>
		public bool ReturnsContent
		{
			get { return true; }
		}

		/// <summary>
		/// Gets or sets the template to display within the control.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerDefaultProperty),
		MergableProperty(false),
		TemplateInstance(TemplateInstance.Single)
		]
		public ITemplate Template
		{
			get { return _template; }
			set { _template = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the template.
		/// </summary>
		public ControlElementTemplate() { }

		/// <summary>
		/// Creates the template.
		/// </summary>
		/// <param name="template">The template.</param>
		public ControlElementTemplate(ITemplate template)
		{
			_template = template;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the template content.
		/// </summary>
		/// <returns>The template content.</returns>
		public string GetTemplate()
		{
			Label label = new Label();
			return ControlRendering.GetTemplateMarkup(label, this.Template);
		}

		/// <summary>
		/// Invokes the template in the underlying response stream.
		/// </summary>
		public void InvokeTemplate() { }

		#endregion
	}
}
