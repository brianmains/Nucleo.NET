using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Web.Browsers;


namespace Nucleo.Web.Context.Services
{
	public class WebFormsBrowserCapabilitiesService : IBrowserCapabilitiesService
	{
#if NET20
		private HttpContext _context = null;
#else
		private HttpContextBase _context = null;
#endif



		#region " Properties "

#if NET20
		private HttpContext Context
		{
			get { return _context; }
		}
#else
		private HttpContextBase Context
		{
			get { return _context; }
		}
#endif

		#endregion



		#region " Constructors "

#if NET20
		public WebFormsBrowserCapabilitiesService()
			: this(HttpContext.Current) { }

		public WebFormsBrowserCapabilitiesService(HttpContext context)
		{
			_context = context;
		}
#else
		public WebFormsBrowserCapabilitiesService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebFormsBrowserCapabilitiesService(HttpContextBase context)
		{
			_context = context;
		}

#endif

		#endregion



		#region " Methods "

		public object Get(BrowserCapability capability)
		{
#if NET20
			HttpBrowserCapabilities capabilities = this.Context.Request.Browser;
			PropertyInfo property = typeof(HttpBrowserCapabilities).GetProperty(capability.Name);
#else
			HttpBrowserCapabilitiesBase capabilities = this.Context.Request.Browser;
			PropertyInfo property = typeof(HttpBrowserCapabilitiesBase).GetProperty(capability.Name);
#endif
			
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
