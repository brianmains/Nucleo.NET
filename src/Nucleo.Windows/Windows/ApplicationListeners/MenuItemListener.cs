using System;

using Nucleo.Windows.Actions;
using Nucleo.Windows.Application;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class MenuItemListener : BaseModelListener
	{
		#region " Constructors "

		public MenuItemListener(ListenerControl control, ApplicationModel application) 
			: base(control, application) { }

		#endregion



		#region " Methods "

		protected internal override bool IsSupportedUIElement(UIElement element)
		{
			return (element is MenuItem);
		}

		#endregion
	}
}
