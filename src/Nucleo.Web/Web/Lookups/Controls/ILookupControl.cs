using System;
using System.Collections.Generic;

using Nucleo.Lookups;


namespace Nucleo.Web.Lookups.Controls
{
	/// <summary>
	/// Represents a lookup control.
	/// </summary>
	public interface ILookupControl
	{
		#region " Properties "

		/// <summary>
		/// Gets the name of the lookup.
		/// </summary>
		string LookupName { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Binds the lookup values using the lookup criteria.
		/// </summary>
		/// <param name="criteria">The criteria of a lookup.</param>
		void BindValues(LookupCriteria criteria);

		#endregion
	}
}
