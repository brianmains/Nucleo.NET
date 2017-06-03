using System;
using System.Collections.Generic;


namespace Nucleo.Web.DropDownControls
{
	/// <summary>
	/// Represents the input control options for the drop down control.
	/// </summary>
	public class DropDownInputOptions
	{
		private string _controlID = null;
		private bool _enabled = true;



		#region " Properties "

		/// <summary>
		/// Gets the ID for the control (this is not the full ID, but the partial ID).
		/// </summary>
		public string ControlID
		{
			get { return _controlID ?? "Input"; }
			set { _controlID = value; }
		}

		/// <summary>
		/// Gets or sets whether the input control is enabled.
		/// </summary>
		public bool Enabled
		{
			get { return _enabled; }
			set { _enabled = value; }
		}

		#endregion
	}
}
