using System;
using System.Collections.Generic;


namespace Nucleo.Web.Styles
{
	/// <summary>
	/// Represents a stylesheet reference.
	/// </summary>
	public class Stylesheet
	{
		private string _path = null;
		public string _referenceName = null;
		private Type _referenceType = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the path to the stylesheet.
		/// </summary>
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		/// <summary>
		/// Gets or sets the reference name to the stylesheet.
		/// </summary>
		public string ReferenceName
		{
			get { return _referenceName; }
			set { _referenceName = value; }
		}

		/// <summary>
		/// Gets or sets the reference type to the stylesheet.
		/// </summary>
		public Type ReferenceType
		{
			get { return _referenceType; }
			set { _referenceType = value; }
		}

		#endregion
	}
}
