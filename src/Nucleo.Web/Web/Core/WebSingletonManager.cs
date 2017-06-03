using System;
using System.Web;

using Nucleo.Exceptions;


namespace Nucleo.Web.Core
{
	/// <summary>
	/// Represents a core manager to register central singleton-based services like the <see cref="NucleoAjaxManager"/> component.
	/// </summary>
	public class WebSingletonManager : IWebSingletonManager
	{
		private IWebContext _context = null;



		#region " Properties "

		private IWebContext Context
		{
			get 
			{
				if (_context == null)
					_context = WebContext.GetCurrent();
				return _context; 
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the singleton manager.
		/// </summary>
		public WebSingletonManager() { }

		/// <summary>
		/// Creates the singleton manager.
		/// </summary>
		/// <param name="context">The context to use.</param>
		public WebSingletonManager(IWebContext context)
		{
			_context = context;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="obj">The object to add.</param>
		public void AddEntry<T>(T obj)
		{
			if (this.Context.LocalStorage.Contains(typeof(T)))
				throw new DuplicateException("A entry already exists of type " + typeof(T).FullName);

			this.Context.LocalStorage.Add(typeof(T), obj);
		}

		/// <summary>
		/// Adds an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <param name="obj">The object to add.</param>
		public void AddEntry<T>(T obj, string name)
		{
			if (this.Context.LocalStorage.Contains(typeof(T)))
				throw new DuplicateException("A entry already exists of type " + typeof(T).FullName);

			this.Context.LocalStorage.Add(GetIdentifier<T>(name), obj);
		}

		/// <summary>
		/// Adds or updates an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="obj">The object to add or update.</param>
		public void AddOrUpdateEntry<T>(T obj)
		{
			if (!this.Context.LocalStorage.Contains(typeof(T)))
				this.Context.LocalStorage.Add(typeof(T), obj);
			else
				this.Context.LocalStorage[typeof(T)] = obj;
		}

		/// <summary>
		/// Adds or updates an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <param name="obj">The object to add or update.</param>
		public void AddOrUpdateEntry<T>(T obj, string name)
		{
			if (!this.Context.LocalStorage.Contains(typeof(T)))
				this.Context.LocalStorage.Add(GetIdentifier<T>(name), obj);
			else
				this.Context.LocalStorage[GetIdentifier<T>(name)] = obj;
		}

		/// <summary>
		/// Gets the current web singleton manager.
		/// </summary>
		/// <returns>The <see cref="IWebSingletonManager"/> instance.</returns>
		public static IWebSingletonManager GetCurrent()
		{
			if (HttpContext.Current == null)
				return null;

			WebSingletonManager mgr = HttpContext.Current.Items[typeof(WebSingletonManager)] as WebSingletonManager;
			if (mgr != null)
				return mgr;

			mgr = new WebSingletonManager(WebContext.GetCurrent());

			HttpContext.Current.Items.Add(typeof(WebSingletonManager), mgr);
			return mgr;
		}

		/// <summary>
		/// Gets an entry from local storage, or null if not found.
		/// </summary>
		/// <typeparam name="T">The type of entry to retrieve.</typeparam>
		/// <returns>The entry or null.</returns>
		public T GetEntry<T>()
		{
			return (T)this.Context.LocalStorage[typeof(T)];
		}

		/// <summary>
		/// Gets an entry from local storage, or null if not found.
		/// </summary>
		/// <typeparam name="T">The type of entry to retrieve.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <returns>The entry or null.</returns>
		public T GetEntry<T>(string name)
		{
			return (T)this.Context.LocalStorage[GetIdentifier<T>(name)];
		}

		private string GetIdentifier<T>(string name)
		{
			return typeof(T).FullName + "-" + name;
		}

		/// <summary>
		/// Determines whether the dictionary has the entry.
		/// </summary>
		/// <typeparam name="T">THe type to check for.</typeparam>
		/// <returns>Whether the entry exists.</returns>
		public bool HasEntry<T>()
		{
			return this.Context.LocalStorage.Contains(typeof(T));
		}

		/// <summary>
		/// Determines whether the dictionary has the entry.
		/// </summary>
		/// <typeparam name="T">THe type to check for.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <returns>Whether the entry exists.</returns>
		public bool HasEntry<T>(string name)
		{
			return this.Context.LocalStorage.Contains(GetIdentifier<T>(name));
		}

		#endregion
	}
}
