using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Binding
{
	/// <summary>
	/// Represents the interface for model binding.
	/// </summary>
	public interface IModelBindingSupport
	{
		/// <summary>
		/// Gets the model binder.
		/// </summary>
		ModelBinding ModelBinder { get; }
	}
}
