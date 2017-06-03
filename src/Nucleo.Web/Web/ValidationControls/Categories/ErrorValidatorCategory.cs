using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Categories
{
	public struct ErrorValidatorCategory : IValidatorCategory
	{
		#region " Constants "

		public const string CategoryName = "Error";

		#endregion



		#region " Properties "

		public bool IsFailingCategory
		{
			get { return true; }
		}

		public string Name
		{
			get { return CategoryName; }
		}

		#endregion
	}
}
