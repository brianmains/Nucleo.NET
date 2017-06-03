using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Providers
{
	/// <summary>
	/// Represents a provider.
	/// </summary>
	public interface IProvider
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		string Name { get; set; }
	}
}
