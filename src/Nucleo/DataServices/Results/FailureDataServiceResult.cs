using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	/// <summary>
	/// Represents the failure result for the data service.
	/// </summary>
	public class FailureDataServiceResult : IDataServiceResult
	{
		private IDataServiceModule _module = null;
		private string _status = null;



		#region " Properties "

		/// <summary>
		/// Gets the module that failed.
		/// </summary>
		public IDataServiceModule Module
		{
			get { return _module; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the failure data result.
		/// </summary>
		/// <param name="module"></param>
		/// <param name="status"></param>
		public FailureDataServiceResult(IDataServiceModule module, string status)
		{
			_module = module;
			_status = status;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the status for the failure.
		/// </summary>
		/// <returns>The failure message.</returns>
		public string GetStatus()
		{
			return string.Format("The module '{0}' failed for the following reason: {1}", this.Module.DisplayName, _status);
		}

		#endregion
	}
}
