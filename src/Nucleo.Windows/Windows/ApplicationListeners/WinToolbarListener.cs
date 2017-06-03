using System;

using Nucleo.Windows.Application;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public class WinToolbarListener : ToolbarListener
	{
		#region " Constructors "

		public WinToolbarListener(ListenerControl control, ApplicationModel application)
			: base(control, application) { }

		#endregion
	}
}
