using System;


namespace Nucleo.Models.Lookups
{
	/// <summary>
	/// Represents the model injection for lookup-based data using the lookup system.
	/// </summary>
	public interface ILookupInjection : IModelInjection
	{
		/// <summary>
		/// Gets the name of the lookup.
		/// </summary>
		string LookupName { get; }
	}
}
