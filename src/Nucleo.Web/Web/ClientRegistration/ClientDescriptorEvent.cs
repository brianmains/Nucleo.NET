using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration
{
	public class ClientDescriptorEvent : BaseClientDescriptor
	{
		private string _clientEventHandlerPropertyName = null;



		#region " Properties "

		public string ClientEventHandlerPropertyName
		{
			get { return _clientEventHandlerPropertyName; }
			set { _clientEventHandlerPropertyName = value; }
		}

		#endregion



		#region " Constructors "

		public ClientDescriptorEvent(string clientName, string serverName)
			: base(clientName, serverName) { }

		public ClientDescriptorEvent(string clientName, string serverName, string clientEventHandlerPropertyName)
			: this(clientName, serverName)
		{
			_clientEventHandlerPropertyName = clientEventHandlerPropertyName;
		}

		#endregion
	}
}
