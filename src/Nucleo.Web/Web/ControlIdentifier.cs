using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web
{
	public class ControlIdentifier
	{
		private string _id = null;



		#region " Properties "

		/// <summary>
		/// Gets the ID of the server-side control.
		/// </summary>
		public string ID
		{
			get { return _id; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the control identifier with the server-side ID.
		/// </summary>
		/// <param name="id">The ID of the control.</param>
		public ControlIdentifier(string id)
		{
			_id = id;
		}

		#endregion
	}
}
