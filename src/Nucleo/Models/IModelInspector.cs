using System;
using System.Reflection;


namespace Nucleo.Models
{
	/// <summary>
	/// Represents the object that actually inspects the model's properties.  For instance, this object is used to inspect a model's attributes, but could be developed to look at anything, such as the type of the property, to mark the property as injectable.
	/// </summary>
	public interface IModelInspector
	{
		#region " Methods "

		/// <summary>
		/// Finds the <see cref="IModelInjection"/> definition from the current model's property.
		/// </summary>
		/// <param name="metadata">The options used to find the injection definition.</param>
		/// <returns>The injection definition reference or null if not found.</returns>
		IModelInjection FindInjectionDefinition(ModelInspectorOptions options);

		#endregion
	}
}
