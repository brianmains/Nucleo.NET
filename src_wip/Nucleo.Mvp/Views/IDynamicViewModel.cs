using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Views
{
	/// <summary>
	/// Represents the view's model that's dynamic.
	/// </summary>
	public interface IDynamicViewModel
	{
		/// <summary>
		/// Gets or sets the reference to the dynamic model.
		/// </summary>
		dynamic Model { get; set; }
	}
}
