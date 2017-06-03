using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;


namespace Nucleo.Services
{
	/// <summary>
	/// Gets the HTTP context using the locator.
	/// </summary>
	public interface IHttpContextLocatorService : IService 
	{
		HttpContextBase GetContext();
	}
}
