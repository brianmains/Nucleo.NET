using System;
using System.Web;

using Nucleo;


namespace Nucleo.Services
{
	public class InMemoryCookieService : BaseCollectionService, ICookieService
	{
		#region " Methods "

		public void Add(string key, object value, DateTime expires, bool secure)
		{
			this.Items.Add(key, value);
		}

		public void Add(string key, object value, DateTime expires, bool secure, string domain)
		{
			this.Items.Add(key, value);
		}

		public HttpCookie GetCookie(string key)
		{
			if (this.Items.ContainsKey(key) && this.Items[key] != null)
				return new HttpCookie(key, this.Items[key].ToString());
			else
				return new HttpCookie(key);
		}

		#endregion
	}
}
