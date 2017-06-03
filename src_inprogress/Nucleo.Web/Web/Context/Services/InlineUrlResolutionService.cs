using System;
using System.Collections.Generic;


namespace Nucleo.Web.Context.Services
{
	public class InlineUrlResolutionService : IUrlResolutionService
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
