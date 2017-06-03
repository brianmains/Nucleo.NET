using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Browsers;


namespace Nucleo.Services
{
	public class WebBrowserCapabilitiesService : IBrowserCapabilitiesService
	{
		private IHttpContextLocatorService _locator = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _locator.GetContext(); }
		}

		#endregion



		#region " Constructors "

		public WebBrowserCapabilitiesService()
			: this(ServicesContainer.HttpContextLocator) { }

		public WebBrowserCapabilitiesService(IHttpContextLocatorService context)
		{
			_locator = context;
		}

		#endregion



		#region " Methods "

		public object Get(BrowserCapability capability)
		{
			HttpBrowserCapabilitiesBase capabilities = this.Context.Request.Browser;
			PropertyInfo property = typeof(HttpBrowserCapabilitiesBase).GetProperty(capability.Name);
			
			if (property == null)
				throw new NullReferenceException("Could not assign for browser capability: " + capability.Name);
			return property.GetValue(capabilities, null);
		}

		public T Get<T>(BrowserCapability capability)
		{
			return (T)Get(capability);
		}

		public Dictionary<BrowserCapability, object> GetAll()
		{
			Dictionary<BrowserCapability, object> collection = new Dictionary<BrowserCapability, object>();
			Array values = Enum.GetValues(typeof(BrowserCapabilityFeature));

			foreach (BrowserCapabilityFeature value in values)
			{
				BrowserCapability capability = new BrowserCapability(value);
				collection.Add(capability, Get(capability));
			}

			return collection;
		}

		#endregion
	}
}
