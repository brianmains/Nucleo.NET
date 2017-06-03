using System;
using System.Collections.Generic;


namespace Nucleo.Web.NavigationControls.ClientSettings
{
	public class NavigationContainerClientEvents : IScriptComponent
	{
		private string _onClientBarSelected = null;



		#region " Properties "

		public string OnClientBarSelected
		{
			get { return _onClientBarSelected; }
			set { _onClientBarSelected = value; }
		}

		#endregion




		#region IScriptComponent Members

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists("barSelected", this.OnClientBarSelected);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
