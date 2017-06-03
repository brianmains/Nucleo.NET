using System;
using System.Web;
using System.Collections.Generic;

using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	/// <summary>
	/// Represents the service for temporary data.
	/// </summary>
	public class SessionTemporaryDataService : ITemporaryDataService
	{
#if NET20
		private HttpContext _context = null;
#else
		private HttpContextBase _context = null;
#endif



		#region " Constructors "

#if NET20
		public SessionTemporaryDataService()
			: this(HttpContext.Current) { }
#else
		public SessionTemporaryDataService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }
#endif

#if NET20
		public SessionTemporaryDataService(HttpContext context)
#else
		public SessionTemporaryDataService(HttpContextBase context)
#endif
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public void AddItem(string key, object value)
		{
			_context.Session.Add(key, value);
		}

		public object GetItem(string key)
		{
			return _context.Session[key];
		}

		public T GetItem<T>(string key)
		{
			object item = _context.Session[key];
			return (item != null) ? (T)item : default(T);
		}

		public void RemoveItem(string key)
		{
			_context.Session.Remove(key);
		}

		#endregion
	}
}
