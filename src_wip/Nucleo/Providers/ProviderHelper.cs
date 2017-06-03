using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using Nucleo.Providers.Configuration;
using Nucleo.Configuration;

namespace Nucleo.Providers
{
	/// <summary>
	/// Represents the provider helper to construct the collection of providers from a set of provider settings.
	/// </summary>
	public class ProviderHelper
	{
		public static ProviderCollection InitializeProviders(ProviderSettingsCollection providerSettings, ProviderCollection providers, Type providerType)
		{
			if (providerSettings == null)
				throw new ArgumentNullException("providerSettings");
			if (providers == null)
				throw new ArgumentNullException("providers");
			if (providerType == null)
				throw new ArgumentNullException("providerType");

			ProvidersHelper.InstantiateProviders(providerSettings, providers, providerType);
			return providers;
		}

		public static C InitializeProviders<C, I>(ProviderConfigurationSectionBase section) 
			where C:ProviderCollection<I>
			where I:ProviderBase
		{
			if (section == null)
				throw new ProviderException("The section does not exist; this could be because the configuration section name is incorrect.");
			if (section.Providers.Count == 0)
				throw new ProviderException("The section has no providers defined in the collection.");
			if (string.IsNullOrEmpty(section.DefaultProvider))
				throw new ProviderException("The section does not have a default provider specified.");
			
			C providers = Activator.CreateInstance<C>();
			ProvidersHelper.InstantiateProviders(section.Providers, providers, typeof(I));
			return providers;
		}

		public static C InitializeProviders<C, I>(ProviderConfigurationElementBase element)
			where C:ProviderCollection<I>
			where I:ProviderBase
		{
			if (element == null)
				throw new ProviderException("The section does not exist; this could be because the configuration section name is incorrect.");
			if (element.Providers.Count == 0)
				throw new ProviderException("The section has no providers defined in the collection.");
			if (string.IsNullOrEmpty(element.DefaultProvider))
				throw new ProviderException("The section does not have a default provider specified.");

			C providers = Activator.CreateInstance<C>();
			ProvidersHelper.InstantiateProviders(element.Providers, providers, typeof(I));
			return providers;
		}

		public static C InitializeProviders<C>(ProviderConfigurationSectionBase element)
			where C: IProviderCollection
		{
			C providerList = Activator.CreateInstance<C>();

			foreach (ProviderSettings setting in element.Providers)
			{
				Type type = Type.GetType(setting.Type);
				if (type == null)
					throw new NullReferenceException("The type could not be constructed: " + type.FullName);

				IProvider provider = Activator.CreateInstance(type) as IProvider;
				if (provider == null)
					throw new NullReferenceException("The type given is not an IProvider instance: " + type.FullName);

				provider.Name = setting.Name;

				providerList.Add(provider);
			}

			return providerList;
		}
	}
}
