using System;
using System.Web.UI;


namespace Nucleo.Web
{
	public class ControlReference
	{
		private Control _reference = null;



		#region " Properties "

		/// <summary>
		/// Gets the ID of the server-side control.
		/// </summary>
		public Control Reference
		{
			get { return _reference; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the control identifier with the server-side control.
		/// </summary>
		/// <param name="reference">The reference of the control.</param>
		public ControlReference(Control reference)
		{
			_reference = reference;
		}

		#endregion
	}
}
