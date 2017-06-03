using System;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	public interface IDataServiceResult
	{
		#region " Properties "

		/// <summary>
		/// Gets the module reference.
		/// </summary>
		IDataServiceModule Module { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the status message that can be used to log the data service result.
		/// </summary>
		/// <returns>The status message.</returns>
		string GetStatus();

		#endregion
	}
}
