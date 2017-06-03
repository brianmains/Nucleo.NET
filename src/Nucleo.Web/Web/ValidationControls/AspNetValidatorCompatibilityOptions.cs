using System;
using System.Collections.Generic;

using Nucleo.Web;


namespace Nucleo.Web.ValidationControls
{
	/// <summary>
	/// Represents the ASP.NET validation compatibility features.
	/// </summary>
	/// <example>
	/// &lt;ValidationResults id="val" runat="server">
	///		&lt;AspNetValidatorCompatibilityOptions AttachToValidators="true" ValidationGroup="Test" />
	/// &lt;/ValidationResults>
	/// </example>
	public class AspNetValidatorCompatibilityOptions : JsonSerializableObject
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether to attach to the ASP.NET validator controls.
		/// </summary>
		public bool AttachToValidators
		{
			get { return this.GetValue<bool>("attachToValidators", true); }
			set { this.AddOrUpdateValue("attachToValidators", value); }
		}

		#endregion
	}
}
