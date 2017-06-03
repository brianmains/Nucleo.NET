using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;


namespace Nucleo.State
{
	/// <summary>
	/// Represents the collection of state values.
	/// </summary>
	public class StateValueCollection : SimpleCollection<StateValue>
	{
		/// <summary>
		/// Creates an empty collection.
		/// </summary>
		public StateValueCollection() { }

		/// <summary>
		/// Creates with a collection of items.
		/// </summary>
		/// <param name="values">The items to add.</param>
		/// <exception cref="ArgumentNullException">Thrown when values are null.</exception>
		public StateValueCollection(IEnumerable<StateValue> values)
		{
			if (values == null)
				throw new ArgumentNullException("values");

			foreach (var value in values)
				this.Add(value);
		}
	}
}
