using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Lookups.Identification
{
	/// <summary>
	/// Represents a lookup identifier by the type of entity.
	/// </summary>
	public class EntityTypeLookupIdentifier : ILookupIdentifier
	{
		/// <summary>
		/// Gets or sets the type of entity to use as a markup for a lookup.
		/// </summary>
		public Type EntityType
		{
			get;
			set;
		}
	}
}
