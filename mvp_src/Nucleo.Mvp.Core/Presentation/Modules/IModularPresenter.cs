using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Modules;


namespace Nucleo.Presentation.Modules
{
	/// <summary>
	/// Represents the m
	/// </summary>
	public interface IModularPresenter
	{
		/// <summary>
		/// Gets or sets the module for the presenter.
		/// </summary>
		IModule Module { get; set; }
	}
}
