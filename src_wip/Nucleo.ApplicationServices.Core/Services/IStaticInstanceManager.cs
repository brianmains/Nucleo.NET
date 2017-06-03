using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Services
{
	public interface IStaticInstanceManager
	{
		/// <summary>
		/// Adds an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="obj">The object to add.</param>
		void AddEntry<T>(T obj);

		/// <summary>
		/// Adds an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <param name="obj">The object to add.</param>
		void AddEntry<T>(T obj, string name);

		/// <summary>
		/// Adds or updates an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="obj">The object to add or update.</param>
		void AddOrUpdateEntry<T>(T obj);

		/// <summary>
		/// Adds or updates an entry to the singleton collection.
		/// </summary>
		/// <typeparam name="T">The type of service to register.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <param name="obj">The object to add or update.</param>
		void AddOrUpdateEntry<T>(T obj, string name);

		/// <summary>
		/// Gets an entry from local storage, or null if not found.
		/// </summary>
		/// <typeparam name="T">The type of entry to retrieve.</typeparam>
		/// <returns>The entry or null.</returns>
		T GetEntry<T>();

		/// <summary>
		/// Gets an entry from local storage, or null if not found.
		/// </summary>
		/// <typeparam name="T">The type of entry to retrieve.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <returns>The entry or null.</returns>
		T GetEntry<T>(string name);

		/// <summary>
		/// Determines whether the dictionary has the entry.
		/// </summary>
		/// <typeparam name="T">THe type to check for.</typeparam>
		/// <returns>Whether the entry exists.</returns>
		bool HasEntry<T>();

		/// <summary>
		/// Determines whether the dictionary has the entry.
		/// </summary>
		/// <typeparam name="T">THe type to check for.</typeparam>
		/// <param name="name">The name identifier to allow for multiple registrations.</param>
		/// <returns>Whether the entry exists.</returns>
		bool HasEntry<T>(string name);
	}
}
