using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.FormControls
{
	public class FormItemDisplayStyle
	{
		private string _contentCssClass = null;
		private string _headerCssClass = null;



		#region " Properties "

		/// <summary>
		/// Get or set the css class to use for the content of the item display.
		/// </summary>
		public string ContentCssClass
		{
			get { return _contentCssClass; }
			set { _contentCssClass = value; }
		}

		/// <summary>
		/// Get or set the css class to use for the header of the item display.
		/// </summary>
		public string HeaderCssClass
		{
			get { return _headerCssClass; }
			set { _headerCssClass = value; }
		}

		#endregion
	}
}
