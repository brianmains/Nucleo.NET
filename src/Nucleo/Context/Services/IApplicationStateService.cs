using System;

using Nucleo.EventArguments;


namespace Nucleo.Context.Services
{
	/// <summary>
	/// Represents an application state service, such as the service from ASP.NET web forms application state, or some other application state service.
	/// </summary>
	public interface IApplicationStateService : IServiceDictionary
	{
		/// <summary>
		/// Clears all of the state items from the application state.
		/// </summary>
		void Clear();
	}
}
