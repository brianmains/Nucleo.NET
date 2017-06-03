using System;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents request details for CSS files.  This is used in the CSS reference process to generate CSS files that your custom control/extender may use.
	/// </summary>
	/// <example>
	/// protected override void GetCssReferences(IScriptRegistrar registrar)
	/// {
	///		register.AddCssReference(new CssReferenceRequestDetails("Nucleo.Web.styles.css"));
	/// }
	/// </example>
	public class CssReferenceRequestDetails
	{
		private string _path = null;



		#region " Properties "

		/// <summary>
		/// Gets the path to the CSS file.
		/// </summary>
		public string Path
		{
			get { return _path; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates a new CSS file request, using the details provided.
		/// </summary>
		/// <param name="path">The path to the CSS file.</param>
		public CssReferenceRequestDetails(string path)
		{
			_path = path;
		}

		#endregion
	}
}
