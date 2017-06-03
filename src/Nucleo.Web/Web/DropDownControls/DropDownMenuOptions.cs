using System;
using System.Collections.Generic;


namespace Nucleo.Web.DropDownControls
{
	/// <summary>
	/// Represents the menu control options for the drop down control.
	/// </summary>
	public class DropDownMenuOptions
	{
		private string _closeButtonControlID = null;
		private string _controlID = null;
		private int _width = 300;



		#region " Properties "

		/// <summary>
		/// Gets the ID for the control to close the menu (this is not the full ID, but the partial ID).
		/// </summary>
		public string CloseButtonControlID
		{
			get { return _closeButtonControlID ?? "MenuClose"; }
			set { _closeButtonControlID = value; }
		}

		/// <summary>
		/// Gets the ID for the control (this is not the full ID, but the partial ID).
		/// </summary>
		public string ControlID
		{
			get { return _controlID ?? "Menu"; }
			set { _controlID = value; }
		}

		/// <summary>
		/// Gets or sets the width of the drop down menu.
		/// </summary>
		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

		#endregion
	}
}
