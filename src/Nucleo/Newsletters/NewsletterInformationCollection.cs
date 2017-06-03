using System;
using Nucleo.Collections;


namespace Nucleo.Newsletters
{
	public class NewsletterInformationCollection : CollectionBase<NewsletterInformation>
	{
		public bool Contains(string newsletterName)
		{
			foreach (NewsletterInformation info in this)
			{
				if (string.Compare(newsletterName, info.Name, StringComparison.CurrentCulture) == 0)
					return true;
			}

			return false;
		}
	}
}
