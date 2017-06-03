using System;
using System.Web;

using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a service for creating or getting cookies from the browser.  Most methods are defined in ICollectionService interface.
	/// </summary>
	public interface ICookieService : ICollectionService
	{
		/// <summary>
		/// Adds a new cookie.
		/// </summary>
		/// <param name="key">The key of the cookie.</param>
		/// <param name="value">The value of the cookie.</param>
		/// <param name="expires">The date/time the cookie expires.</param>
		/// <param name="secure">Whether the cookie is secured.</param>
		void Add(string key, object value, DateTime expires, bool secure);

		/// <summary>
		/// Adds a new cookie.
		/// </summary>
		/// <param name="key">The key of the cookie.</param>
		/// <param name="value">The value of the cookie.</param>
		/// <param name="expires">The date/time the cookie expires.</param>
		/// <param name="secure">Whether the cookie is secured.</param>
		/// <param name="domain">The domain for the cookie, as specified by W3C.</param>
		void Add(string key, object value, DateTime expires, bool secure, string domain);

		/// <summary>
		/// Gets the cookie based on the cookie's key.  May be null if invalid key.
		/// </summary>
		/// <param name="key">The key to find the cookie with.</param>
		/// <returns>The cookie information, or null if not found.</returns>
		HttpCookie GetCookie(string key);
	}
}
