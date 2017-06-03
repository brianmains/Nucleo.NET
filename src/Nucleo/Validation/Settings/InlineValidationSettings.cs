using System;
using System.Collections.Generic;

using Nucleo.Validation;


namespace Nucleo.Validation.Settings
{
	public class InlineValidationSettings
	{
		private ValidationProviderCollection _providers = null;
		private bool _throwOnInvalid = false;
		private bool _useFirstFoundProviderOnly = false;



		#region " Properties "

		public ValidationProviderCollection Providers
		{
			get
			{
				if (_providers == null)
					_providers = new ValidationProviderCollection();

				return _providers;
			}
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



		#region " Constructors "

		public InlineValidationSettings(ValidationProviderCollection providers, bool throwOnInvalid, bool useFirstFoundProviderOnly)
		{
			_providers = providers;
			_throwOnInvalid = throwOnInvalid;
			_useFirstFoundProviderOnly = useFirstFoundProviderOnly;
		}

		#endregion
	}
}
