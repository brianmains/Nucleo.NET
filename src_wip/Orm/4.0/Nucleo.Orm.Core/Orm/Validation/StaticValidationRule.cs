using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Validation
{
	public class StaticValidationRule : IValidationRule
	{
		private bool _isError = true;
		private string _message = null;



		#region " Properties "

		public StaticValidationRule(bool isError, string message)
		{
			_isError = isError;
			_message = message;
		}

		#endregion



		#region " Methods "

		public void Validate(ValidationResults results)
		{
			results.AddMessage(new ValidationMessage(_message, _isError));
		}

		#endregion
	}
}
