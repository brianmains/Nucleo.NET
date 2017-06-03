using System;


namespace Nucleo.DataMapper.Incrementing
{
	/// <summary>
	/// Represents the interface to generate objects using an incremental mapping.
	/// </summary>
	public interface IMappingGenerator
	{
		/// <summary>
		/// Generates an object using the current collection of mappings.
		/// </summary>
		/// <param name="map">The collection of mappings.</param>
		/// <returns>The generated object.</returns>
		object Generate(IncrementMappings map);
	}
}
