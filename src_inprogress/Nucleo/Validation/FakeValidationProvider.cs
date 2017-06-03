using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Validation
{
	public class FakeValidationProvider : ValidationProvider
	{
		private bool _isCorrectProvider = false;
		private ValidationItemCollection _items = null;



		#region " Properties "

		public bool IsCorrectProvider
		{
			get { return _isCorrectProvider; }
			set { _isCorrectProvider = value; }
		}

		#endregion



		#region " Constructors "

		public FakeValidationProvider() { }

		public FakeValidationProvider(bool isCorrectProvider, ValidationItemCollection items)
		{
			_isCorrectProvider = isCorrectProvider;
			_items = items;
		}

		#endregion



		#region " Methods "

		public override bool IsCorrectValidator(object obj)
		{
			return this.IsCorrectProvider;
		}

		public override ValidationItemCollection Validate(object obj)
		{
			return _items.GetErrors();
		}

		#endregion
	}
}
