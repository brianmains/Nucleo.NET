using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Validation.Settings
{
	public interface IValidationSettings
	{
		#region " Properties "

		bool ThrowOnInvalid { get; set; }

		bool UseFirstFoundProviderOnly { get; set; }

		#endregion



		#region " Methods "

		ValidationProviderCollection GetProviders();

		#endregion
	}
}
