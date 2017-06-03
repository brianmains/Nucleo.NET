using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Web.Description;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the registrar for content.  This registrar manages CSS references, script references, and script descriptors.
	/// </summary>
	public interface IContentRegistrar
	{
		#region " Methods "

		ComponentDescriptor AddComponentDescriptor(ComponentDescriptionRequestDetails details);

		/// <summary>
		/// Adds a CSS reference to the registrar.
		/// </summary>
		/// <param name="details">The details of the CSS to create or get.</param>
		/// <returns>The CSS reference information.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddCssReference(new CssReferenceRequestDetails(
		///		Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile.css")));
		/// </example>
		CssReference AddCssReference(CssReferenceRequestDetails details);

		/// <summary>
		/// Adds the collection of CSS references to the registrar.
		/// </summary>
		/// <param name="details">The collection of details.</param>
		/// <returns>The collection of CSS references.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddCssReferences(new CssReferenceRequestDetailsCollection
		/// {
		///		new CssReferenceRequestDetails(Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile.css")),
		///		new CssReferenceRequestDetails(Page.ClientScript.GetWebResourceUrl(this.GetType(), "MyCssFile2.css"))
		/// });
		/// </example>
		CssReferenceCollection AddCssReferences(CssReferenceRequestDetailsCollection details);

		/// <summary>
		/// Adds or gets the script descriptor, using the details specified.
		/// </summary>
		/// <param name="details">The details of the script description.</param>
		/// <returns>The script descriptor instance.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptor(new ScriptDescriptionRequestDetails(
		///		ctlInstance, typeof(MyControl), ctlInstance.ClientID));
		/// </example>
		ScriptDescriptor AddDescriptor(ScriptDescriptionRequestDetails details);

		/// <summary>
		/// Adds or gets the script descriptor, using the details specified.
		/// </summary>
		/// <param name="details">The details of the script description.</param>
		/// <typeparam name="T">The type of descriptor, either a control or extender descriptor; the nucleo framework uses a custom script descriptor.</typeparam>
		/// <returns>The script descriptor instance.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptor&lt;ScriptControlDescriptor>(new ScriptDescriptionRequestDetails(
		///		ctlInstance, typeof(MyControl), ctlInstance.ClientID));
		/// </example>
		T AddDescriptor<T>(ScriptDescriptionRequestDetails details)
			where T : ScriptDescriptor;

		/// <summary>
		/// Adds the collection of descriptors.
		/// </summary>
		/// <param name="details">The collection of details for script descriptions to register.</param>
		/// <returns>The collection of script descriptors.</returns>
		/// <example>
		/// var registrar = new ContentRegistrar();
		/// registrar.AddDescriptors(new ScriptDescriptionRequestDetailsCollection
		/// {
		///		new ScriptDescriptionRequestDetails(ctlInstance, typeof(MyControl), ctlInstance.ClientID)
		///	});
		/// </example>
		ScriptDescriptorCollection AddDescriptors(ScriptDescriptionRequestDetailsCollection details);

		/// <summary>
		/// Adds a script reference to the registrar, using the script details.
		/// </summary>
		/// <param name="details">The details of the reference.</param>
		/// <returns>The script reference information.</returns>
		ScriptReference AddReference(ScriptReferencingRequestDetails details);

		/// <summary>
		/// Adds a script reference to the registrar, using the list of script details.
		/// </summary>
		/// <param name="details">The list of details to reference.</param>
		/// <returns>The script reference information collection.</returns>
		ScriptReferenceCollection AddReferences(ScriptReferencingRequestDetailsCollection details);

		ComponentDescriptorCollection GetComponentDescriptors();

		CssReferenceCollection GetCssReferences();

		ScriptDescriptorCollection GetDescriptors();

		ScriptReferenceCollection GetScripts();

		#endregion
	}
}
