using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Discovery
{
	/// <summary>
	/// Represents the results of the discovery of a particular unit of work.
	/// </summary>
    public class UnitOfWorkDiscoveryResults
    {
		/// <summary>
		/// Gets or sets a generic list of attributes.
		/// </summary>
        public IDictionary<object, object> Attributes { get; set; }

		/// <summary>
		/// Gets or sets the type of unit of work found.
		/// </summary>
        public Type UnitOfWorkType { get; set; }
    }
}
