using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Categories
{
	public static class CategoryDefinitions
	{
		#region " Properties "

		public static IValidatorCategory Error
		{
			get { return new ErrorValidatorCategory(); }
		}

		public static IValidatorCategory Information
		{
			get { return new InformationValidatorCategory(); }
		}

		public static IValidatorCategory Warning
		{
			get { return new WarningValidatorCategory(); }
		}

		#endregion
	}
}
