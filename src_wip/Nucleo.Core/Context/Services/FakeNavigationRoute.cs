using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Context.Services
{
	public class FakeNavigationRoute : INavigationRoute
	{
		private string _routeText = null;



		#region " Constructors "

		public FakeNavigationRoute(string routeText)
		{
			_routeText = routeText;
		}

		#endregion



		#region " Methods "

		public string GetRouteText()
		{
			return _routeText;
		}

		#endregion
	}
}
