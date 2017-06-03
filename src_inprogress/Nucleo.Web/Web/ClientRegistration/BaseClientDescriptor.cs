using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration
{
	public abstract class BaseClientDescriptor
	{
		private string _clientName = null;
		private string _serverName = null;



		#region " Properties "

		public string ClientName
		{
			get { return _clientName; }
		}

		public string ServerName
		{
			get { return _serverName; }
		}

		#endregion



		#region " Constructors "

		public BaseClientDescriptor(string clientName, string serverName)
		{
			_clientName = clientName;
			_serverName = serverName;
		}

		#endregion
	}
}
