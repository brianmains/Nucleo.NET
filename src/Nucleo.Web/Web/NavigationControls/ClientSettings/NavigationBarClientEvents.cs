using System;
using System.Collections.Generic;


namespace Nucleo.Web.NavigationControls.ClientSettings
{
	public class NavigationBarClientEvents : IScriptComponent
	{
		private string _onClientItemSelected = null;



		#region " Properties "

		public string OnClientItemSelected
		{
			get { return _onClientItemSelected; }
			set { _onClientItemSelected = value; }
		}

		#endregion



		#region " Methods "

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists("itemSelected", this.OnClientItemSelected);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
