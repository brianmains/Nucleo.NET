using System;
using System.Collections.Generic;


namespace Nucleo.Web.ButtonControls.ClientSettings
{
	public class ButtonClientEvents : IScriptComponent
	{
		private string _onClientNeedPostback = null;



		#region " Constants " 
        
        public const string NeedPostbackEventName = "needPostback";
        
        #endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets whether the button control needs to postback; this is a callback to programmably determine whether the button will postback to the server.
		/// </summary>
		public string OnClientNeedPostback
		{
			get { return _onClientNeedPostback; }
			set { _onClientNeedPostback = value; }
		}

		#endregion



		#region " Methods "

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists(NeedPostbackEventName, this.OnClientNeedPostback);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
