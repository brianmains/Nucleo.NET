using System;
using System.Collections.Generic;

using Nucleo.Web.Browsers;


namespace Nucleo.Web.Context.Services
{
	/// <summary>
	/// Represents a fake browser capability that returns nothing.
	/// </summary>
	public class FakeBrowserCapabilitiesService : IBrowserCapabilitiesService
	{
		#region " Methods "

		public object Get(BrowserCapability capability)
		{
			return this.Get<object>(capability);
		}

		public T Get<T>(BrowserCapability capability)
		{
			return default(T);
		}

		public Dictionary<BrowserCapability, object> GetAll()
		{
			return new Dictionary<BrowserCapability, object>();
		}

		#endregion
	}
}
