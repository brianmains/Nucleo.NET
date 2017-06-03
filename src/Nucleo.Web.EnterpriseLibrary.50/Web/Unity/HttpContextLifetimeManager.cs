using System;
using System.Web;
using Microsoft.Practices.Unity;


namespace Nucleo.Web.Unity
{
	/// <summary>
	/// Represents an HTTP context lifetime manager using the current HTTP context.
	/// </summary>
	/// <typeparam name="T">The type of object to store.</typeparam>
	public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
	{
		private HttpContextBase _context = null;



		#region " Constructors "

		public HttpContextLifetimeManager()
		{
			_context = new HttpContextWrapper(HttpContext.Current);
		}

		public HttpContextLifetimeManager(HttpContextBase context)
		{
			if (context == null)
				throw new ArgumentNullException("context");

			_context = context;
		}

		#endregion



		#region " Methods "

		public void Dispose()
		{
			this.RemoveValue();
		}

		public override object GetValue()
		{
			return _context.Items[typeof(T)];
		}

		public override void RemoveValue()
		{
			_context.Items.Remove(typeof(T));
		}

		public override void SetValue(object newValue)
		{
			_context.Items[typeof(T)] = newValue;
		}

		#endregion
	}
}
