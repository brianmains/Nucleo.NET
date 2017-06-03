using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Validation.Settings
{
	public class FakeValidationSettings : IValidationSettings
	{
		private ValidationProviderCollection _providers = null;
		private bool _throwOnInvalid = false;
		private bool _useFirstFoundProviderOnly = false;



		#region " Properties "

		public ValidationProviderCollection Providers
		{
			get { return _providers; }
			set { _providers = value; }
		}

		public bool ThrowOnInvalid
		{
			get { return _throwOnInvalid; }
			set { _throwOnInvalid = value; }
		}

		public bool UseFirstFoundProviderOnly
		{
			get { return _useFirstFoundProviderOnly; }
			set { _useFirstFoundProviderOnly = value; }
		}

		#endregion



		#region " Methods "

		public ValidationProviderCollection GetProviders()
		{
			return this.Providers;
		}

		#endregion
	}
}
