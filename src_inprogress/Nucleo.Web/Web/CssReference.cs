using System;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a CSS file reference.  This file is not used directly within any custom controls/extenders you may develop, though you can use it for your own needs.
	/// </summary>
	public class CssReference
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

		public CssReference(CssReferenceRequestDetails details)
			: this(details.Path) { }

		public CssReference(string path)
		{
			_path = path;
		}

		#endregion
	}
}
