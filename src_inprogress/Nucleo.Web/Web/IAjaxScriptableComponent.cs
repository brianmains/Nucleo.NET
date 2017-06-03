using System;
using System.Web.UI;


namespace Nucleo.Web
{
	public interface IAjaxScriptableComponent
	{
		#region " Methods "

		/// <summary>
		/// Registers the descriptions of the server control using the script registrar, for a specified target control.
		/// </summary>
		/// <param name="registrar">The registrar used to register the component.</param>
		/// <param name="targetControl">The targeted (or related) control.  For extenders, this is the control to extend.  For controls, this is itself.</param>
		void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl);

		/// <summary>
		/// Registers scripts related to the control.  Scripts are normally registered in the assembly as an embedded resource.
		/// </summary>
		/// <param name="registrar">The registrar used to register the component.</param>
		void GetAjaxScriptReferences(IContentRegistrar registrar);

		/// <summary>
		/// Registers CSS files related to the control.  Scripts are normally registered in the assembly as an embedded resource.
		/// </summary>
		/// <param name="registrar"></param>
		void GetCssReferences(IContentRegistrar registrar);

		/// <summary>
		/// Gets an empty list of descriptors.
		/// </summary>
		/// <returns>An empty list.</returns>
		//ScriptDescriptorCollection GetEmptyListOfDescriptors();

		/// <summary>
		/// Gets an empty list of references.
		/// </summary>
		/// <returns>An empty list.</returns>
		//ScriptReferenceCollection GetEmptyListOfReferences();

		#endregion
	}
}
