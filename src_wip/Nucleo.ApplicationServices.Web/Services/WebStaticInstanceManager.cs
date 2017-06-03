using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Nucleo.Services
{
	public class WebStaticInstanceManager : IStaticInstanceManager
	{
		private HttpContextBase _context = null;



		#region " Properties "

		private HttpContextBase Context
		{
			get 
			{
				if (_context == null)
					_context = new HttpContextWrapper(HttpContext.Current);

				return _context; 
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the singleton manager.
		/// </summary>
		public WebStaticInstanceManager() { }

		/// <summary>
		/// Creates the singleton manager.
		/// </summary>
		/// <param name="context">The context to use.</param>
		public WebStaticInstanceManager(HttpContextBase context)
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
			if (this.Context.Items.Contains(typeof(T)))
				throw new Exception("A entry already exists of type " + typeof(T).FullName);

			this.Context.Items.Add(typeof(T), obj);
		}

		/// <summary>
		/// Adds an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <param name="obj">The object to add.</param>
		public void AddEntry<T>(T obj, string name)
		{
			if (this.Context.Items.Contains(typeof(T)))
				throw new Exception("A entry already exists of type " + typeof(T).FullName);

			this.Context.Items.Add(GetIdentifier<T>(name), obj);
		}

		/// <summary>
		/// Adds or updates an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="obj">The object to add or update.</param>
		public void AddOrUpdateEntry<T>(T obj)
		{
			if (!this.Context.Items.Contains(typeof(T)))
				this.Context.Items.Add(typeof(T), obj);
			else
				this.Context.Items[typeof(T)] = obj;
		}

		/// <summary>
		/// Adds or updates an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <param name="obj">The object to add or update.</param>
		public void AddOrUpdateEntry<T>(T obj, string name)
		{
			if (!this.Context.Items.Contains(typeof(T)))
				this.Context.Items.Add(GetIdentifier<T>(name), obj);
			else
				this.Context.Items[GetIdentifier<T>(name)] = obj;
		}

		/// <summary>
		/// Gets the current web singleton manager.
		/// </summary>
		/// <returns>The <see cref="ISingletonManager"/> instance.</returns>
		public static IStaticInstanceManager GetCurrent()
		{
			if (HttpContext.Current == null)
				return null;

			var mgr = HttpContext.Current.Items[typeof(WebStaticInstanceManager)] as WebStaticInstanceManager;
			if (mgr != null)
				return mgr;

			mgr = new WebStaticInstanceManager();

			HttpContext.Current.Items.Add(typeof(WebStaticInstanceManager), mgr);
			return mgr;
		}

		/// <summary>
		/// Gets an entry from local storage, or null if not found.
		/// </summary>
		/// <typeparam name="T">The type of entry to retrieve.</typeparam>
		/// <returns>The entry or null.</returns>
		public T GetEntry<T>()
		{
			return (T)this.Context.Items[typeof(T)];
		}

		/// <summary>
		/// Gets an entry from local storage, or null if not found.
		/// </summary>
		/// <typeparam name="T">The type of entry to retrieve.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <returns>The entry or null.</returns>
		public T GetEntry<T>(string name)
		{
			return (T)this.Context.Items[GetIdentifier<T>(name)];
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
			return this.Context.Items.Contains(typeof(T));
		}

		/// <summary>
		/// Determines whether the dictionary has the entry.
		/// </summary>
		/// <typeparam name="T">THe type to check for.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <returns>Whether the entry exists.</returns>
		public bool HasEntry<T>(string name)
		{
			return this.Context.Items.Contains(GetIdentifier<T>(name));
		}

		#endregion
	}
}
