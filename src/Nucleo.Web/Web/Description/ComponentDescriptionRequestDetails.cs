using System;


namespace Nucleo.Web.Description
{
	/// <summary>
	/// Represents the request details for the description of a component.
	/// </summary>
	public class ComponentDescriptionRequestDetails
	{
		private string _clientTypeName = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the client type that's being registered.
		/// </summary>
		public string ClientTypeName
		{
			get { return _clientTypeName; }
		}

		#endregion




		#region " Constructors "

		/// <summary>
		/// Creates the request details, using the specified client type.
		/// </summary>
		/// <param name="clientTypeName">The name of the client type that's being registered.</param>
		public ComponentDescriptionRequestDetails(string clientTypeName)
		{
			if (string.IsNullOrEmpty(clientTypeName))
				throw new ArgumentNullException("clientTypeName");

			_clientTypeName = clientTypeName;
		}

		#endregion
	}
}
