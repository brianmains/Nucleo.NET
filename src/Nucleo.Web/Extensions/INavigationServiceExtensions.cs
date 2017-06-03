using System;

using Nucleo.Web.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context.Services;


namespace Nucleo.Context
{
	public static class INavigationServiceExtensions
	{
		/// <summary>
		/// Navigates to a specific URL.
		/// </summary>
		/// <param name="service">The URL to redirect to.</param>
		/// <param name="url">The base URL.</param>
		public static void NavigateToUrl(this INavigationService service, string url)
		{
			if (service == null)
				throw new ArgumentNullException("service");
			if (string.IsNullOrEmpty(url))
				throw new ArgumentNullException("url");

			service.NavigateTo(new WebFormsNavigationRoute(url));
		}
	}
}
