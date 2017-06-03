using System;
using System.Web.Configuration;
using System.Configuration.Provider;

using Nucleo.Providers;
using Nucleo.Providers.Configuration;
using Nucleo.Newsletters.Configuration;


namespace Nucleo.Newsletters
{
	public sealed class NewsletterManager
	{
		private NewsletterProvider _defaultProvider = null;



		#region " Properties "

		private NewsletterProvider DefaultProvider
		{
			get { return _defaultProvider; }
		}

		#endregion



		#region " Constructors "

		private NewsletterManager() { }

		#endregion



		#region " Methods "

		public void AddNewsletter(string newsletterName, string description)
		{
			DefaultProvider.AddNewsletter(newsletterName, description);
		}

		public void AddSubscription(string subscriberEmail, string newsletterName)
		{
			DefaultProvider.AddSubscription(subscriberEmail, newsletterName);
		}

		public static NewsletterManager Create()
		{
			NewsletterSection section = NewsletterSection.Instance;
			if (section == null)
				throw new ArgumentNullException("section");
			if (string.IsNullOrEmpty(section.DefaultProvider))
				throw new ArgumentNullException("section.DefaultProvider");

			NewsletterManager letter = new NewsletterManager();
			letter._defaultProvider = (NewsletterProvider)Activator.CreateInstance(Type.GetType(section.DefaultProvider));

			if (letter._defaultProvider == null)
				throw new ProviderException("The default provider couldn't be instantiated");

			return letter;
		}

		public static NewsletterManager Create(NewsletterProvider provider)
		{
			if (provider == null)
				throw new ArgumentNullException("provider");

			NewsletterManager letter = new NewsletterManager();
			letter._defaultProvider = provider;

			return letter;
		}

		public NewsletterInformationCollection GetAllNewsletters()
		{
			return DefaultProvider.GetAllNewsletters();
		}

		public NewsletterInformationCollection GetNewslettersForSubscriber(string subscriberEmail)
		{
			return DefaultProvider.GetNewslettersForSubscriber(subscriberEmail);
		}

		public string[] GetSubscribers(string newsletterName)
		{
			return DefaultProvider.GetSubscribers(newsletterName);
		}

		public bool NewsletterExists(string newsletterName)
		{
			return DefaultProvider.NewsletterExists(newsletterName);
		}

		public void RemoveAllSubscriptions(string subscriberEmail)
		{
			DefaultProvider.RemoveAllSubscriptions(subscriberEmail);
		}

		public void RemoveNewsletter(string newsletterName)
		{
			DefaultProvider.RemoveNewsletter(newsletterName);
		}

		public void RemoveSubscription(string subscriberEmail, string newsletterName)
		{
			DefaultProvider.RemoveSubscription(subscriberEmail, newsletterName);
		}

		public bool SubscriptionExists(string subscriberEmail, string newsletterName)
		{
			return DefaultProvider.SubscriptionExists(subscriberEmail, newsletterName);
		}

		#endregion
	}
}
