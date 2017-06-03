using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.Newsletters
{
	public class FakeNewsletterProvider : NewsletterProvider
	{
		private TripletDictionary<string, NewsletterInformation, List<string>> _newsletters = null;



		#region " Properties "

		public TripletDictionary<string, NewsletterInformation, List<string>> Newsletters
		{
			get
			{
				if (_newsletters == null)
					_newsletters = new TripletDictionary<string, NewsletterInformation, List<string>>();

				return _newsletters;
			}
		}

		#endregion



		#region " Methods "

		public override void AddNewsletter(string newsletterName, string description)
		{
			this.Newsletters.Add(newsletterName, new NewsletterInformation(newsletterName, description), new List<string>());
		}

		public override void AddSubscription(string subscriberEmail, string newsletterName)
		{
			this.Newsletters[newsletterName].Value2.Add(subscriberEmail);
		}

		public override NewsletterInformationCollection GetAllNewsletters()
		{
			NewsletterInformationCollection keys = new NewsletterInformationCollection();

			foreach (TripletItem<string, NewsletterInformation, List<string>> item in this.Newsletters)
				keys.Add(item.Value1);

			return keys;
		}

		public override NewsletterInformationCollection GetNewslettersForSubscriber(string subscriberEmail)
		{
			NewsletterInformationCollection keys = new NewsletterInformationCollection();

			foreach (TripletItem<string, NewsletterInformation, List<string>> item in this.Newsletters)
			{
				if (item.Value2.Contains(subscriberEmail))
					keys.Add(item.Value1);
			}

			return keys;
		}

		public override string[] GetSubscribers(string newsletterName)
		{
			return this.Newsletters[newsletterName].Value2.ToArray();
		}

		public override bool NewsletterExists(string newsletterName)
		{
			return this.Newsletters.ContainsKey(newsletterName);
		}

		public override void RemoveNewsletter(string newsletterName)
		{
			this.Newsletters.Remove(newsletterName);
		}

		public override void RemoveAllSubscriptions(string subscriberEmail)
		{
			foreach (TripletItem<string, NewsletterInformation, List<string>> item in this.Newsletters)
			{
				if (item.Value2.Contains(subscriberEmail))
					item.Value2.Remove(subscriberEmail);
			}
		}

		public override void RemoveSubscription(string subscriberEmail, string newsletterName)
		{
			this.Newsletters[newsletterName].Value2.Remove(subscriberEmail);
		}

		public override bool SubscriptionExists(string subscriberEmail, string newsletterName)
		{
			return this.Newsletters[newsletterName].Value2.Contains(subscriberEmail);
		}

		#endregion
	}
}
