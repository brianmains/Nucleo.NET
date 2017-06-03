using System;
using System.IO;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;

using Nucleo.Browsers;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the service to extract a browser's capabilities.
	/// </summary>
	/// <seealso cref="BrowserCapability"/>
	public interface IBrowserCapabilitiesService : IService
	{
		#region " Methods "

		/// <summary>
		/// Gets the value for the browser capability.
		/// </summary>
		/// <param name="capability">The capability to find.</param>
		/// <returns>The value that the browser returns.</returns>
		object Get(BrowserCapability capability);

		/// <summary>
		/// Gets the value for the browser capability in strongly typed format.  If wrong type specified, may cause casting exception.
		/// </summary>
		/// <typeparam name="T">The type to convert the underlying value to.</typeparam>
		/// <param name="capability">The capability to find.</param>
		/// <returns>The strongly-typed value that the browser returns.</returns>
		T Get<T>(BrowserCapability capability);

		/// <summary>
		/// Gets all of the browser capabilities, with their respective values.
		/// </summary>
		/// <returns>The capability/value combinations.</returns>
		Dictionary<BrowserCapability, object> GetAll();

		#endregion
	}
}
