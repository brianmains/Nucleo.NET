using System;
using System.Collections.Generic;

using Nucleo.Providers;
using Nucleo.Validation.Configuration;
using Nucleo.Validation.Settings;


namespace Nucleo.Validation
{
	public class ValidationManager
	{
		private ValidationProviderCollection _providers = null;
		private bool _throwOnInvalid = false;
		private bool _useFirstFoundProviderOnly = false;



		#region " Properties "

		private ValidationProviderCollection Providers
		{
			get { return _providers; }
		}

		public bool ThrowOnInvalid
		{
			get { return _throwOnInvalid; }
		}

		public bool UseFirstFoundProviderOnly
		{
			get { return _useFirstFoundProviderOnly; }
		}

		#endregion



		#region " Constructors "

		private ValidationManager() { }

		#endregion



		#region " Methods "

		public static ValidationManager Create(IValidationSettings settings)
		{
			ValidationManager manager = new ValidationManager();

			manager._throwOnInvalid = settings.ThrowOnInvalid;
			manager._useFirstFoundProviderOnly = settings.UseFirstFoundProviderOnly;
			manager._providers = settings.GetProviders();

			return manager;
		}

		public ValidationSession Validate(object obj)
		{
			ValidationItemCollection items = new ValidationItemCollection();

			for (int index = 0, len = this.Providers.Count; index < len; index++)
			{
				ValidationProvider provider = this.Providers[index];
				if (provider.IsCorrectValidator(obj))
				{
					ValidationItemCollection subItems = provider.Validate(obj);

					if (this.ThrowOnInvalid)
					{
						ValidationItem errorItem = subItems.GetFirstError();
						if (errorItem != null)
							throw new Exception(string.Format("The validation for '{0}' signaled an error: {1}", 
								errorItem.Name, errorItem.Description));
					}

					items.AddRange(subItems);

					if (this.UseFirstFoundProviderOnly)
						return new ValidationSession(items);
				}
			}

			return new ValidationSession(items);
		}

		#endregion
	}
}
