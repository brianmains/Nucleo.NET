using System;
using System.Collections.Specialized;

using Nucleo.Context;


namespace Nucleo.Web.Context.Services
{
	/// <summary>
	/// Represents the collection of querystring values stored in the URL of a requested page.
	/// </summary>
	public interface IQuerystringService : IServiceDictionary
	{
		/// <summary>
		/// Gets all of the query string values in name/value form.
		/// </summary>
		/// <returns>The name/value pairings.</returns>
		NameValueCollection GetAll();
	}
}
