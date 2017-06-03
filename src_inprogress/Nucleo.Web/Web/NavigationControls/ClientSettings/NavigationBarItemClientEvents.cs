using System;
using System.Collections.Generic;


namespace Nucleo.Web.NavigationControls.ClientSettings
{
	public class NavigationBarItemClientEvents : IScriptComponent
	{
		private string _onClientSelected;



		#region " Properties "

		public string OnClientSelected
		{
			get { return _onClientSelected; }
			set { _onClientSelected = value; }
		}

		#endregion



		#region " Methods "

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists("selected", this.OnClientSelected);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
