using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents the navigation service used to navigate to a specific route.
	/// </summary>
	/// <example>
	/// var context = ApplicationContext.GetCurrent();
	/// var obj = context.GetService&lt;INavigationService>();
	/// //Use object
	/// </example>
	public interface INavigationService : IService
	{
		void NavigateTo(INavigationRoute route);
	}
}
