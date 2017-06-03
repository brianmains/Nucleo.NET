using System;
using System.Web;
using System.Collections.Generic;

using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the service for temporary data.
	/// </summary>
	public class SessionTemporaryDataService : ITemporaryDataService
	{
		private HttpContextBase _context = null;



		#region " Constructors "

		public SessionTemporaryDataService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public SessionTemporaryDataService(HttpContextBase context)
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
