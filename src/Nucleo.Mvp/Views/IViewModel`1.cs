using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Views
{
	/// <summary>
	/// Represents an interface for an object supporting a model in generic fashion.
	/// </summary>
	public interface IViewModel<TModel>
	{
		/// <summary>
		/// Gets or sets the model in strongly typed form.
		/// </summary>
		TModel Model { get; set; }
	}
}
