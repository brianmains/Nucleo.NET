using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Dependencies
{
	/// <summary>
	/// Marks a property or parameter as needing a dependency.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class DependencyAttribute : Attribute
	{

	}
}
