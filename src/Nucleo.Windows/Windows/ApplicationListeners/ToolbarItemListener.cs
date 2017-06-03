using System;

using Nucleo.Windows.Application;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class ToolbarItemListener : BaseModelListener
	{
		#region " Constructors "

		public ToolbarItemListener(ListenerControl control, ApplicationModel application) 
			: base(control, application) { }

		#endregion



		#region " Methods "

		protected internal override bool IsSupportedUIElement(UIElement element)
		{
			return (element is ToolbarItem);
		}

		#endregion
	}
}
