using System;

using Nucleo.Context;


namespace Nucleo.Web.Context.Services
{
	/// <summary>
	/// Resolves a specific URL.
	/// </summary>
	public interface IUrlResolutionService : IService
	{
		#region " Methods "

		/// <summary>
		/// Gets the client URL, or the URL to the page on the client-side.  For instance, ~/page.aspx would translate possibly to ../page.aspx.
		/// </summary>
		/// <param name="relativeUrl">The relative url to map on the client.</param>
		/// <returns>The resolved url.</returns>
		string GetClientBasedUrl(string relativeUrl);

		/// <summary>
		/// Gets the server URL, or the path to the absolute URL on the server.  For instance, ~/page.aspx could map to c:\projects\webapp\page.aspx.
		/// </summary>
		/// <param name="relativeUrl">The partial URL to convert.</param>
		/// <returns>The resolved url.</returns>
		string GetWebServerUrl(string relativeUrl);

		#endregion
	}
}
