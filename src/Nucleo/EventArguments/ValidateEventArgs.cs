using System;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents details about the validation process.
	/// </summary>
	public class ValidateEventArgs
	{
		private bool _isValid = true;



		#region " Properties "

		/// <summary>
		/// Gets or sets whether something is valid or not.
		/// </summary>
		public bool IsValid
		{
			get { return _isValid; }
			set { _isValid = value; }
		}

		#endregion


		
		#region " Constructors "

		/// <summary>
		/// Creates the args.
		/// </summary>
		public ValidateEventArgs() { }

		/// <summary>
		/// Creates the args using the valid setting as the default.
		/// </summary>
		/// <param name="isValid">Whether is valid.</param>
		public ValidateEventArgs(bool isValid)
		{
			_isValid = isValid;
		}

		#endregion
	}

	/// <summary>
	/// Represents the handler for validation events.
	/// </summary>
	/// <param name="sender">The object sender.</param>
	/// <param name="e">The validation details.</param>
	public delegate void ValidateEventHandler(object sender, ValidateEventArgs e);
}
