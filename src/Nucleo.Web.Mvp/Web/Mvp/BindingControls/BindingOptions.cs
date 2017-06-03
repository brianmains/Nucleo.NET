using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Mvp.BindingControls
{
	/// <summary>
	/// Represents the options to use when binding the UI to the model.
	/// </summary>
	public class BindingOptions
	{
		/// <summary>
		/// Gets or sets the prefix used to identify properties with reference table data.
		/// </summary>
		public string ReferenceTablePrefix
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the suffix used to identify properties with reference table data.
		/// </summary>
		public string ReferenceTableSuffix
		{
			get;
			set;
		}
	}
}
