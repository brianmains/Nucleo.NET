using System;
using Nucleo.Providers;


namespace Nucleo.Newsletters
{
	public abstract class NewsletterProvider : ProviderBase
	{
		#region " Methods "

		protected virtual void ValidateNewsletterName(string newsletterName)
		{
			if (string.IsNullOrEmpty(newsletterName))
				throw new ArgumentNullException("newsletterName", "The newsletter name must be provided.");
		}

		protected virtual void ValidateSubscriberEmail(string subscriberEmail)
		{
			if (string.IsNullOrEmpty(subscriberEmail))
				throw new ArgumentNullException("subscriberEmail", "The subscriber email must be provided.");
		}

		#endregion 



		#region " Abstract Methods "

		public abstract void AddNewsletter(string newsletterName, string description);
		public abstract void AddSubscription(string subscriberEmail, string newsletterName);
		public abstract NewsletterInformationCollection GetAllNewsletters();
		public abstract NewsletterInformationCollection GetNewslettersForSubscriber(string subscriberEmail);
		public abstract string[] GetSubscribers(string newsletterName);
		public abstract bool NewsletterExists(string newsletterName);
		public abstract void RemoveNewsletter(string newsletterName);
		public abstract void RemoveAllSubscriptions(string subscriberEmail);
		public abstract void RemoveSubscription(string subscriberEmail, string newsletterName);
		public abstract bool SubscriptionExists(string subscriberEmail, string newsletterName);

		#endregion
	}


	public class NewsletterProviderCollection : ProviderCollection<NewsletterProvider> { }
}
