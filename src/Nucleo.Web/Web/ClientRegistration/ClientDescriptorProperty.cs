using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration
{
	/// <summary>
	/// Represents a property that's being loaded from the client descriptor.
	/// </summary>
	public class ClientDescriptorProperty : BaseClientDescriptor
	{
		private ClientPropertyContentType _contentType = ClientPropertyContentType.Data;
		private object _value = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the type of content that the property describes; data supplies a value that gets directly passed to the client.  AjaxComponent refers to passing an ID, and converting it to a reference of an AJAX component on the client.  ClientElement converts an ID to a DOM reference.
		/// </summary>
		public ClientPropertyContentType ContentType
		{
			get { return _contentType; }
			set { _contentType = value; }
		}

		/// <summary>
		/// Gets or sets the value of the property, used to pass to the descriptor.
		/// </summary>
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates a property with a client/server name.
		/// </summary>
		/// <param name="clientName">The name of the property on the client.</param>
		/// <param name="serverName">The name of the property on the server.</param>
		public ClientDescriptorProperty(string clientName, string serverName)
			: base(clientName, serverName) { }

		/// <summary>
		/// Creates a property with a client/server name and value.
		/// </summary>
		/// <param name="clientName">The name of the property on the client.</param>
		/// <param name="serverName">The name of the property on the server.</param>
		/// <param name="value">The value of the property.</param>
		public ClientDescriptorProperty(string clientName, string serverName, object value)
			: this(clientName, serverName)
		{
			_value = value;
		}

		/// <summary>
		/// Creates a property with a client/server name and value.
		/// </summary>
		/// <param name="clientName">The name of the property on the client.</param>
		/// <param name="serverName">The name of the property on the server.</param>
		/// <param name="contentType">The type of content for the property.  See the <see cref="ContentType">ContentType property</see> for more details about this value.</param>
		/// <param name="value">The value of the property.</param>
		public ClientDescriptorProperty(string clientName, string serverName, ClientPropertyContentType contentType, object value)
			: this(clientName, serverName, value)
		{
			_contentType = contentType;
		}

		#endregion
	}
}
