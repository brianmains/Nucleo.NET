using System;
using System.Web;
using System.Collections.Specialized;


namespace Nucleo.Services
{
	public class WebQuerystringService : IQuerystringService
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _context; }
		}

		public int Count
		{
			get { return this.Context.Request.QueryString.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Request.QueryString.Get(key); }
			set { }
		}

		#endregion


		#region " Constructors "

		public WebQuerystringService()
			: this(new HttpContextWrapper(HttpContext.Current)) { }

		public WebQuerystringService(HttpContextBase context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Context.Request.QueryString.Add(key, (value != null) ? value.ToString() : default(string));
		}

		public bool Contains(string key)
		{
			return (this.Context.Request.QueryString.Get(key) != null);
		}

		public object Get(string key)
		{
			return this.Context.Request.QueryString.Get(key);
		}

		public object Get(int index)
		{
			return this.Context.Request.QueryString.Get(index);
		}

		public NameValueCollection GetAll()
		{
			return this.Context.Request.QueryString;
		}

		public void Remove(string key)
		{
			this.Context.Request.QueryString.Remove(key);
		}

		public void RemoveAt(int index)
		{
			string key = this.Context.Request.QueryString.Keys[index];
			this.Context.Request.QueryString.Remove(key);
		}

		#endregion
	}
}
