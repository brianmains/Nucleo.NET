using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Items
{
	/// <summary>
	/// Represents the interface for a display item in the validation system.
	/// </summary>
	public interface IValidationDisplayItem
	{
		/// <summary>
		/// Gets or sets the message of the validation display item.
		/// </summary>
		string Message { get; set; }
	}
}
