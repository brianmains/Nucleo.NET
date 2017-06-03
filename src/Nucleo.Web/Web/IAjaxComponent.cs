using System;

using Nucleo.Web.ClientSettings;

namespace Nucleo.Web
{
	/// <summary>
	/// Interface that represents an AJAX component.
	/// </summary>
	public interface IAjaxComponent
	{
		/// <summary>
		/// Gets the client-side events that may occur for the AJAX component.
		/// </summary>
		ClientEvents ClientEvents { get; }

		/// <summary>
		/// Gets the client ID for the control.  This client ID has many importances related to script controls.
		/// </summary>
		string ClientID { get; }

		/// <summary>
		/// Gets or sets the server-based ID for controls.
		/// </summary>
		string ID { get; set; }

		/// <summary>
		/// Gets or sets a generic reference name.
		/// </summary>
		string ReferenceName { get; set; }

		/// <summary>
		/// Gets the unique ID for the control.  This client ID has many importances related to script controls.
		/// </summary>
		string UniqueID { get; }
	}
}
