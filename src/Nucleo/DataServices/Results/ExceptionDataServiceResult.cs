using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	/// <summary>
	/// Represents a data result generated from an exception.
	/// </summary>
	public class ExceptionDataServiceResult : IDataServiceResult
	{
		private Exception _exception = null;
		private IDataServiceModule _module = null;



		#region " Properties "

		/// <summary>
		/// Gets the exception that was raised.
		/// </summary>
		public Exception Exception
		{
			get { return _exception; }
		}

		/// <summary>
		/// Gets the module that generated the exception.
		/// </summary>
		public IDataServiceModule Module
		{
			get { return _module; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the exception data result.
		/// </summary>
		/// <param name="module">The module.</param>
		/// <param name="ex">The exception that was generated.</param>
		public ExceptionDataServiceResult(IDataServiceModule module, Exception ex)
		{
			_module = module;
			_exception = ex;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the status message containing the exception details.
		/// </summary>
		/// <returns>The status message.</returns>
		public string GetStatus()
		{
			return string.Format("The module '{0}' reported the exception: {1}", _module.DisplayName, _exception.ToString());
		}

		#endregion
	}
}
