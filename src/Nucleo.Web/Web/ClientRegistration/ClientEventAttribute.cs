using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration
{
	public class ClientEventAttribute : Attribute
	{
		private string _clientEventHandlerPropertyName = null;
		private string _clientName = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the property that contains the name of an event handler.  For instance, an event textChanged on the client, may assign an event handler via an OnClientTextChanged server property.
		/// </summary>
		public string ClientEventHandlerPropertyName
		{
			get { return _clientEventHandlerPropertyName; }
			set { _clientEventHandlerPropertyName = value; }
		}

		/// <summary>
		/// Gets the name of the member that exists on the client.
		/// </summary>
		public string ClientName
		{
			get { return _clientName; }
		}

		#endregion



		#region " Constructors "

		public ClientEventAttribute() { }

		public ClientEventAttribute(string clientName)
		{
			_clientName = clientName;
		}

		public ClientEventAttribute(string clientName, string clientEventHandlerPropertyName)
			: this(clientName)
		{
			_clientEventHandlerPropertyName = clientEventHandlerPropertyName;
		}

		#endregion
	}
}
