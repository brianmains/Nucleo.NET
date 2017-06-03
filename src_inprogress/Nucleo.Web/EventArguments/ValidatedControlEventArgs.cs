using System;
using System.Web.UI;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments for controls being validated.
	/// </summary>
	public class ValidatedControlEventArgs : EventArgs
	{
		private Control _control = null;
		private object _value = null;



		#region " Properties "

		/// <summary>
		/// Gets the control being validated.
		/// </summary>
		public Control Control
		{
			get { return _control; }
		}

		/// <summary>
		/// Gets or sets the control to be validated.
		/// </summary>
		public object Value
		{
			get { return _value; }
			set { _value = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event args with the control reference.
		/// </summary>
		/// <param name="control">The control instance.</param>
		public ValidatedControlEventArgs(Control control)
		{
			_control = control;
		}

		#endregion
	}

	
	/// <summary>
	/// Represents the handler signature for controls being validated.
	/// </summary>
	/// <param name="sender">The validator.</param>
	/// <param name="e">The validated control details.</param>
	public delegate void ValidatedControlEventHandler(object sender, ValidatedControlEventArgs e);
}
