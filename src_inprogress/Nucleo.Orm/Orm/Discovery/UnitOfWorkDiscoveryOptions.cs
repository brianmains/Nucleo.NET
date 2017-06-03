using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm.Creation;


namespace Nucleo.Orm.Discovery
{
	/// <summary>
	/// Represents the options to use for unit of work discovery.
	/// </summary>
	public class UnitOfWorkDiscoveryOptions
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the object responsible for creating the unit of work.
		/// </summary>
		public IUnitOfWorkCreator Creator
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the unit of work.
		/// </summary>
		public string Name
		{
			get;
			set;
		}
		
		#endregion
	}
}
