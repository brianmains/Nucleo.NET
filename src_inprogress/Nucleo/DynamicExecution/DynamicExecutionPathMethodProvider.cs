using System;
using System.Configuration;
using Nucleo.Configuration;
using Nucleo.Providers;


namespace Nucleo.DynamicExecution
{
	public abstract class DynamicExecutionPathMethodProvider : ProviderBase
	{
		public abstract DynamicExecutionPathMethodInfoCollection GetMethods();
	}
}
