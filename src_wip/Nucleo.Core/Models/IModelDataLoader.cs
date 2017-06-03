using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Models
{
	/// <summary>
	/// Represents the data loader for the model.
	/// </summary>
	public interface IModelDataLoader
	{
		#region " Methods "

		/// <summary>
		/// Gets the data for the current model member.
		/// </summary>
		/// <param name="metadata">The metadata.</param>
		/// <returns>The object instanct to pass to the property.</returns>
		object GetModelData(ModelMemberMetadata metadata);

		/// <summary>
		/// Gets whether model injection is supported for the current injection definition.
		/// </summary>
		/// <param name="injection">The injection definition.</param>
		/// <returns>Gets whether the current contract is supported.</returns>
		bool SupportsInjection(IModelInjection injection);

		#endregion
	}
}
