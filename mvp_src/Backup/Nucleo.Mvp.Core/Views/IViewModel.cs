using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Views
{
	/// <summary>
	/// Represents an interface for an object supporting a model.
	/// </summary>
	public interface IViewModel
	{
		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		object Model { get; set; }
	}
}
