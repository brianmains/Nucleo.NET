using System;
using System.Configuration;

using Nucleo.Providers;


namespace Nucleo.Web.Security
{
	public abstract class RuleProvider : ProviderBase
	{
		#region " Methods "

		public abstract string CreateRule(string rule);

		#endregion
	}
}
