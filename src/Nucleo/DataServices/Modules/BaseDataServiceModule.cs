using System;
using System.Collections.Generic;

using Nucleo.DataServices.Results;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents the base class for all data service modules.
	/// </summary>
	public abstract class BaseDataServiceModule : IDataServiceModule
	{
		private IDictionary<string, object> _parameters = null;



		#region " Properties "

		/// <summary>
		/// Gets the display name for the module.
		/// </summary>
		public abstract string DisplayName { get; }

		/// <summary>
		/// Gets the parameters for the module.
		/// </summary>
		public IDictionary<string, object> Parameters
		{
			get { return _parameters; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Executes the module.
		/// </summary>
		/// <returns>The results of the execution.</returns>
		public abstract IDataServiceResult Execute();

		/// <summary>
		/// Initializes the module with the specified parameters.
		/// </summary>
		/// <param name="parms">The parameters to initialize.s</param>
		public void Initialize(IDictionary<string, object> parms)
		{
			_parameters = parms;
		}

		#endregion
	}
}
