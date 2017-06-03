using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Presentation.Context
{
	/// <summary>
	/// Represents the interface to create the presenter context.
	/// </summary>
	public interface IPresenterContextCreator
	{
		/// <summary>
		/// Creates the presenter context.
		/// </summary>
		/// <returns>The presenter context instance.</returns>
		PresenterContext Create();
	}
}
