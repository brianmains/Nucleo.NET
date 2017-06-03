using System;
using System.Collections.Specialized;

using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the post collection of data that was posted to the server.
	/// </summary>
	public interface IPostDataService : IService
	{
		#region " Methods "

		/// <summary>
		/// Gets the posted value by its key.
		/// </summary>
		/// <param name="key">The key of the entry in the post.</param>
		/// <returns>The value of the posted entry.</returns>
		string Get(string key);

		/// <summary>
		/// Gets the posted value by its index.
		/// </summary>
		/// <param name="index">The index of the entry in the post.</param>
		/// <returns>The value of the posted entry.</returns>
		string Get(int index);

		/// <summary>
		/// Gets all entries from the post in name/value form.
		/// </summary>
		/// <returns>The collection of posted entries.</returns>
		NameValueCollection GetAll();

		#endregion
	}
}
