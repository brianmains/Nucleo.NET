using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Validation
{
	public class ValidationItem
	{
		private string _description = null;
		private string _name = null;

		private ValidationType _validationResult = null;



		#region " Properties "

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public string Name
		{
			get { return _name; }
		}

		public ValidationType ValidationResult
		{
			get
			{
				if (_validationResult == null)
					return new EmptyValidationType();
				else
					return _validationResult;
			}
			set { _validationResult = value; }
		}

		#endregion



		#region " Constructors "

		public ValidationItem(string name, ValidationType validationResult, string description)
		{
			_name = name;
			_validationResult = validationResult;
			_description = description;
		}

		#endregion
	}
}
