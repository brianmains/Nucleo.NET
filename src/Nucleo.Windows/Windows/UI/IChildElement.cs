using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public interface IChildElement
	{
		UIElement Parent { get; }
	}
}
