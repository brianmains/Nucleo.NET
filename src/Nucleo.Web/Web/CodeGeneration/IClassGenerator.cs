using System;


namespace Nucleo.Web.CodeGeneration
{
	/// <summary>
	/// Performs the work of generating a class.
	/// </summary>
	public interface IClassGenerator
	{
		#region " Methods "

		/// <summary>
		/// Generates a class definition.
		/// </summary>
		/// <param name="definition">The definition.</param>
		/// <returns>The generated content.</returns>
		string Generate(ClassDefinition definition);

		#endregion
	}
}
