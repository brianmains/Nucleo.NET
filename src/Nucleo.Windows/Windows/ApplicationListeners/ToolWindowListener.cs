using System;

using Nucleo.Windows.Application;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class ToolWindowListener : BaseModelListener
	{
		#region " Constructors "

		public ToolWindowListener(ListenerControl control, ApplicationModel application) 
			: base(control, application) { }

		#endregion



		protected internal override bool IsSupportedUIElement(UIElement element)
		{
			return (element is ToolWindow);
		}
	}
}
