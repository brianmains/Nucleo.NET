using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	/// <summary>
	/// Represents the success result for the data service.
	/// </summary>
	public class SuccessDataServiceResult : IDataServiceResult
	{
		private IDataServiceModule _module = null;
		private string _status = null;



		#region " Properties "

		/// <summary>
		/// Gets the module.
		/// </summary>
		public IDataServiceModule Module
		{
			get { return _module; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the success result.
		/// </summary>
		/// <param name="module"></param>
		/// <param name="status"></param>
		public SuccessDataServiceResult(IDataServiceModule module, string status)
		{
			_module = module;
			_status = status;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the success status for the result.
		/// </summary>
		/// <returns>The status message.</returns>
		public string GetStatus()
		{
			return string.Format("The module '{0}' succeeded, supplying the following additional information: {1}", this.Module.DisplayName, _status);
		}

		#endregion
	}
}
