using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Validation
{
	/// <summary>
	/// Represents the message of a validation.
	/// </summary>
	public class ValidationMessage
	{
		/// <summary>
		/// Gets whether the current validation is an error result.
		/// </summary>
		public bool IsErrorResult
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the message.
		/// </summary>
		public string Message 
		{ 
			get; 
			private set; 
		}



		/// <summary>
		/// Creates the message for the validation with the text of it, plus the status of error.
		/// </summary>
		/// <param name="message">The message of the validation.</param>
		/// <param name="isErrorResult">Whether the message is an error result.</param>
		public ValidationMessage(string message, bool isErrorResult)
		{
			if (string.IsNullOrEmpty(message))
				throw new ArgumentNullException("message");

			this.Message = message;
			this.IsErrorResult = isErrorResult;
		}
	}
}
