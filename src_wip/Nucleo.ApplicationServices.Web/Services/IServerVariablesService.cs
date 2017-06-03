using System;
using System.Collections.Specialized;

using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the server variables that contains the information about the server itself.
	/// </summary>
	public interface IServerVariablesService : ICollectionService
	{
		/// <summary>
		/// Gets all of the server variables within the application.
		/// </summary>
		/// <returns>Gets the variables in name/value form.</returns>
		NameValueCollection GetAll();
	}
}
