using System;
using System.Collections.Generic;

using Nucleo.Collections;


namespace Nucleo.DataServices.Modules
{
	/// <summary>
	/// Represents a collection of modules.
	/// </summary>
	public class DataServiceModuleCollection : SimpleCollection<IDataServiceModule>
	{
		#region " Methods "

		/// <summary>
		/// Adds a collection of modules to the underlying collection.
		/// </summary>
		/// <param name="modules">The module to add in bulk.</param>
		public void AddRange(IEnumerable<IDataServiceModule> modules)
		{
			foreach (IDataServiceModule module in modules)
				this.Add(module);
		}

		#endregion
	}
}
