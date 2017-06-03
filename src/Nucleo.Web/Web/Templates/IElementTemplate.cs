using System;
using System.Collections.Generic;


namespace Nucleo.Web.Templates
{
	/// <summary>
	/// Represents the element template.
	/// </summary>
	public interface IElementTemplate
	{
		/// <summary>
		/// Gets whether the content is returned, or whether its invoked (like with System.Action).
		/// </summary>
		bool ReturnsContent { get; }

		/// <summary>
		/// Gets the template content as a string.
		/// </summary>
		/// <returns>Gets the content of the template.</returns>
		string GetTemplate();

		/// <summary>
		/// Invokes the template.
		/// </summary>
		void InvokeTemplate();
	}
}
