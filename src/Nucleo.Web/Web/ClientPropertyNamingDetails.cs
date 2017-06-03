using System;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the naming details for the client property.  Script components emit references for a script descriptor and potentially any CSS/references.  Client property naming details specify the names for the description process.
	/// </summary>
	public class ClientPropertyNamingDetails
	{
		private string _clientPropertyName = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the client-property, for script description purposes.
		/// </summary>
		public string ClientPropertyName
		{
			get { return _clientPropertyName; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the naming details using the specified client property name.
		/// </summary>
		/// <param name="clientPropertyName">The property name for the client.</param>
		public ClientPropertyNamingDetails(string clientPropertyName)
		{
			_clientPropertyName = clientPropertyName;
		}

		#endregion
	}
}
