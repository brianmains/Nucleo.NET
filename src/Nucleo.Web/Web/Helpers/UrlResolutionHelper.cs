using System;
using System.Collections.Generic;

using Nucleo.Web.Context;
using Nucleo.Web.Context.Services;


namespace Nucleo.Web.Helpers
{
	/// <summary>
	/// Represents a utility to resolve urls.
	/// </summary>
	public class UrlResolutionHelper
	{
		private IUrlResolutionService _resolver = null;



		#region " Constructors "

		/// <summary>
		/// Represents a helper for managing urls.
		/// </summary>
		/// <param name="resolver">The resolver to resolve urls.</param>
		public UrlResolutionHelper(IUrlResolutionService resolver)
		{
			if (resolver == null)
				throw new ArgumentNullException("resolver");

			_resolver = resolver;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the full path from a relative path, by resolving it, such as converting ~/file.aspx to c:\virtuals\file.aspx.
		/// </summary>
		/// <param name="relativePath">The relative path to resolve.</param>
		/// <returns></returns>
		public string GetFullPath(string relativePath)
		{
			return _resolver.GetWebServerUrl(relativePath);
		}

		/// <summary>
		/// Gets a relative URL from a base url (say converting a ../web/file.aspx to ~/web/file.aspx.
		/// </summary>
		/// <param name="baseUrl">The base url to convert.</param>
		/// <returns>The relative URL.</returns>
		public string MakeRelativeWebUrl(string baseUrl)
		{
			return _resolver.GetClientBasedUrl(baseUrl);
		}

		#endregion
	}
}
