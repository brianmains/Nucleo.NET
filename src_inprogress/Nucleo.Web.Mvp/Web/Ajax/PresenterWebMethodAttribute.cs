using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Ajax
{
	/// <summary>
	/// Signifies that the method on the presenter will be invoked via an AJAX call.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class PresenterWebMethodAttribute : Attribute
	{
	}
}
