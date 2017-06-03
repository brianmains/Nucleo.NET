using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ClientPropertyAttribute : Attribute
	{
		private string _clientName = null;
		private ClientPropertyContentType _contentType = ClientPropertyContentType.Data;
		private object _defaultValue = null;
		private string _javascriptConverterType = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the member that exists on the client.
		/// </summary>
		public string ClientName
		{
			get { return _clientName; }
		}

		public ClientPropertyContentType ContentType
		{
			get { return _contentType; }
			set { _contentType = value; }
		}

		public object DefaultValue
		{
			get { return _defaultValue; }
			set { _defaultValue = value; }
		}

		public string JavascriptConverterType
		{
			get { return _javascriptConverterType; }
			set { _javascriptConverterType = value; }
		}

		#endregion



		#region " Constructors "

		public ClientPropertyAttribute() { }

		public ClientPropertyAttribute(string clientName)
		{
			_clientName = clientName;
		}

		public ClientPropertyAttribute(string clientName, object defaultValue)
		 : this(clientName)
		{
			_defaultValue = defaultValue;
		}

		public ClientPropertyAttribute(string clientName, object defaultValue, Type javascriptConverterType)
			: this(clientName, defaultValue)
		{
			_javascriptConverterType = javascriptConverterType.AssemblyQualifiedName;
		}

		public ClientPropertyAttribute(string clientName, object defaultValue, string javascriptConverterType)
			: this(clientName, defaultValue)
		{
			_javascriptConverterType = javascriptConverterType;
		}

		#endregion
	}
}
