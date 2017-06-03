using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Dependencies
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
	public class DependencyAttribute : Attribute
	{

	}
}
