using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Context.Services
{
	public class FakeNavigationService : INavigationService
	{
		private string _lastRoute;



		#region " Properties "

		public string LastRoute
		{
			get { return _lastRoute; }
		}

		#endregion



		#region INavigationService Members

		public void NavigateTo(INavigationRoute route)
		{
			_lastRoute = route.GetRouteText();
		}

		#endregion
	}
}
