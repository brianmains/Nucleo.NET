using System;
using System.Collections.Generic;


namespace Nucleo.Services
{
	public class InMemoryUrlResolutionService : IUrlResolutionService
	{
		#region IUrlResolutionService Members

		public string GetClientBasedUrl(string relativeUrl)
		{
			return relativeUrl.Replace("~/", "");
		}

		public string GetWebServerUrl(string relativeUrl)
		{
			return relativeUrl.Replace("~/", "");
		}

		#endregion
	}
}
