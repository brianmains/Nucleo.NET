﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Categories
{
	public struct WarningValidatorCategory : IValidatorCategory
	{
		#region " Constants "

		public const string CategoryName = "Warning";

		#endregion



		#region " Properties "

		public bool IsFailingCategory
		{
			get { return false; }
		}

		public string Name
		{
			get { return CategoryName; }
		}

		#endregion
	}
}
