using System;
using System.Web;

using Nucleo;


namespace Nucleo.Services
{
	public class WebApplicationStateService : IApplicationStateService
	{
		private IHttpContextLocatorService _locator = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get { return _locator.GetContext(); }
		}

		public int Count
		{
			get { return this.Context.Application.Count; }
		}

		public object this[string key]
		{
			get { return this.Context.Application[key]; }
			set { this.Context.Application[key] = value; }
		}

		#endregion



		#region " Constructors "

		public WebApplicationStateService()
			: this(ServicesContainer.HttpContextLocator) { }

		public WebApplicationStateService(IHttpContextLocatorService context)
		{
			_locator = context;
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Context.Application.Add(key, value);
		}

		public void Clear()
		{
			this.Context.Application.Clear();
		}

		public bool Contains(string key)
		{
			return (this.Context.Application[key] != null);
		}

		public object Get(string key)
		{
			return this.Context.Application.Get(key);
		}

		public object Get(int index)
		{
			return this.Context.Application[index];
		}

		public void Remove(string key)
		{
			this.Context.Application.Remove(key);
		}

		public void RemoveAt(int index)
		{
			this.Context.Application.RemoveAt(index);
		}

		#endregion
	}
}
