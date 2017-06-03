using System;
using Nucleo.Web.ClientRegistration;


namespace Nucleo.Web.ControlStorage
{
	/// <summary>
	/// Represents the value of a control's property.
	/// </summary>
	public class ControlPropertyValue
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the key of the property.
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the options to use for the control's property.
		/// </summary>
		public ControlPropertyOptions Options { get; set; }

		/// <summary>
		/// Gets or sets the value of the property.
		/// </summary>
		public object Value { get; set; }

		#endregion
	}
}
