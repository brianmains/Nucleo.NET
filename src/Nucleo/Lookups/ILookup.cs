using System;
using System.Collections.Generic;


namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents the interface.
	/// </summary>
	public interface ILookup
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the lookup value.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets a code used to represent the value.
		/// </summary>
		object RepresentationCode { get; set; }

		/// <summary>
		/// Gets or sets the value of the lookup value.
		/// </summary>
		string Value { get; set; }

		#endregion
	}
}
