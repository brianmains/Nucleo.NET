using System;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the CSS metadata related to a component, or the CSS that will be output to the underlying browser.
	/// </summary>
	/// <example>
	///	public class MyCustomControlCssMetadata : WebCssMetadata
	///	{
	///		public override  CssReferenceRequestDetailsCollection GetPrimaryCss()
	///		{
	///			return new CssReferenceRequestDetailsCollection(new CssReferenceRequestDetails(
	///			((Control)this.Component).Page.ClientScript.GetWebResourceUrl(typeof(DropDown),
	///				"Nucleo.Web.DropDownControls.DropDownStyles.css")));
	///		}
	/// }
	/// </example>
	public abstract class WebCssMetadata
	{
		private object _component = null;


		
		#region " Properties "

		/// <summary>
		/// Gets the component being registered.  Typically, in the Nucleo framework, this property is shadowed with a strongly typed implementation.
		/// </summary>
		public object Component
		{
			get { return _component; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Returns the primary CSS files for the component it references.
		/// </summary>
		/// <returns>The details about the CSS file being requested.</returns>
		public abstract CssReferenceRequestDetailsCollection GetPrimaryCss();

		/// <summary>
		/// Initializes the component by passing along the component that will be using CSS.
		/// </summary>
		/// <param name="component">The registering component.</param>
		public virtual void Initialize(object component)
		{
			_component = component;
		}

		#endregion
	}
}
