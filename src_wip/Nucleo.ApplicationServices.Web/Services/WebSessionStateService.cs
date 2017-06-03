using System;
using System.Web;
using System.Web.SessionState;

using Nucleo;


namespace Nucleo.Services
{
	public class WebSessionStateService : ISessionStateService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		public int Count
		{
			get { return this.Context.Session.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Session[key]; }
			set { this.Context.Session[key] = value; }
		}

		public string UniqueKey
		{
			get { return this.Context.Session.SessionID; }
		}

		#endregion



		#region " Constructors "

		public WebSessionStateService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebSessionStateService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Context.Session.Add(key, value);
		}

		public void Clear()
		{
			this.Context.Session.Clear();
		}

		public bool Contains(string key)
		{
			return (this.Context.Session[key] != null);
		}

		public object Get(string key)
		{
			return this.Context.Session[key];
		}

		public object Get(int index)
		{
			return this.Context.Session[index];
		}

		public void Remove(string key)
		{
			this.Context.Session.Remove(key);
		}

		public void RemoveAt(int index)
		{
			this.Context.Session.RemoveAt(index);
		}

		#endregion
	}
}
