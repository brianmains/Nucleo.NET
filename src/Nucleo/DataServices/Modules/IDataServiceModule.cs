using System;
using System.Collections.Generic;

using Nucleo.DataServices.Results;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents a module in the data service.
	/// </summary>
	public interface IDataServiceModule
	{
		#region " Properties "

		/// <summary>
		/// Gets the display name for the module.
		/// </summary>
		string DisplayName { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Executes the module and returns the results.
		/// </summary>
		/// <returns>The results of the execution.</returns>
		IDataServiceResult Execute();

		/// <summary>
		/// Initializes the module with the underlying parameters.
		/// </summary>
		/// <param name="parms">The parameters to initialize with.</param>
		void Initialize(IDictionary<string, object> parms);

		#endregion
	}
}
