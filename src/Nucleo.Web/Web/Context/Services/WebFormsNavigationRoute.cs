using System;

using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsNavigationRoute : INavigationRoute
	{
		private string _pageUrl = null;



		#region " Constructors "

		public WebFormsNavigationRoute(string pageUrl)
		{
			_pageUrl = pageUrl;
		}

		#endregion



		#region " Methods "

		public string GetRouteText()
		{
			return _pageUrl;
		}

		#endregion
	}
}
