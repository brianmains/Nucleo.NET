using System;
using System.Collections.Generic;


namespace Nucleo.Web.DropDownControls
{
	/// <summary>
	/// Represents the selector control options for the drop down control.
	/// </summary>
	public class DropDownSelectorOptions
	{
		private string _controlID = null;
		private string _imageUrl = null;



		#region " Properties "

		/// <summary>
		/// Gets the ID for the control (this is not the full ID, but the partial ID).
		/// </summary>
		public string ControlID
		{
			get { return _controlID ?? "Selector"; }
			set { _controlID = value; }
		}

		/// <summary>
		/// Gets or sets the image URL for the selector.  The image must be 16 by 16, otherwise the drop down may not appear correctly.
		/// </summary>
		public string ImageUrl
		{
			get { return _imageUrl; }
			set { _imageUrl = value; }
		}

		#endregion
	}
}
