using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents an object used to create a navigation route, whether web forms, MVC, or even silverlight.
	/// </summary>
	public interface INavigationRoute
	{
		#region " Methods "

		string GetRouteText();

		#endregion
	}
}
