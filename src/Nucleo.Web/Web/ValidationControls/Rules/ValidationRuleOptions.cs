using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ValidationControls.Rules
{
	/// <summary>
	/// Gets the options to use when processing a validation rule success/failure.
	/// </summary>
	public class ValidationRuleOptions
	{
		/// <summary>
		/// Gets or sets the values to use in the rule process.
		/// </summary>
		public object[] Values
		{
			get;
			set;
		}
	}
}
