using System;
using System.ComponentModel;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represnts a control template for controls that require them.
	/// </summary>
	public class ControlTemplate : IScriptComponent
	{
		private WebTemplateSelector _clientTemplate = null;
		private ITemplate _serverTemplate = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the client-side template that can be used to represent the UI on the client (for binding or refreshing purposes).  This allows a developer to use prototype or other templating means for using client-side template evaluation (Prototype is the only framework supported at the moment).  This is primarily used for controls using the client-side only mode in rendering controls.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
		]
		public WebTemplateSelector ClientTemplate
		{
			get { return _clientTemplate; }
			set { _clientTemplate = value; }
		}

		/// <summary>
		/// Gets or sets the server template that can represent the UI at rendering time.  This is primarily used for controls that render templates in client-and-server or server-side only modes.
		/// </summary>
		[
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
		]
		public ITemplate ServerTemplate
		{
			get { return _serverTemplate; }
			set { _serverTemplate = value; }
		}

		#endregion



		#region " Methods "

		public void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			if (this.ClientTemplate != null)
				((IScriptComponent)this.ClientTemplate).RegisterAjaxDescriptors(registrar, currentDescriptor);
		}

		public void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			if (this.ClientTemplate != null)
				((IScriptComponent)this.ClientTemplate).RegisterAjaxReferences(registrar);
		}

		#endregion
	}
}
