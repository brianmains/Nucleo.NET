using System;
using System.Collections.Generic;

using Nucleo.Browsers;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a fake browser capability that returns nothing.
	/// </summary>
	public class FakeBrowserCapabilitiesService : IBrowserCapabilitiesService
	{
		private Dictionary<BrowserCapability, object> _services = new Dictionary<BrowserCapability,object>();



		#region " Methods "

		public object Get(BrowserCapability capability)
		{
			return this.Get<object>(capability);
		}

		public T Get<T>(BrowserCapability capability)
		{
			if (_services.ContainsKey(capability))
				return (T)_services[capability];
			else
				return default(T);
		}

		public Dictionary<BrowserCapability, object> GetAll()
		{
			return _services;
		}

		public void Set(BrowserCapability capability, object value)
		{
			_services[capability] = value;
		}

		#endregion
	}
}
