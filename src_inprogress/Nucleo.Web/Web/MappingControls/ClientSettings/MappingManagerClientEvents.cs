using System;
using System.Collections.Generic;


namespace Nucleo.Web.MappingControls.ClientSettings
{
	public class MappingManagerClientEvents : IScriptComponent
	{
		private string _onClientOperationNeeded = null;



		#region " Properties "

		public string OnClientOperationNeeded
		{
			get { return _onClientOperationNeeded; }
			set { _onClientOperationNeeded = value; }
		}

		#endregion



		#region " Methods "

		public void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists("operationNeeded", this.OnClientOperationNeeded);
		}

		public void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
