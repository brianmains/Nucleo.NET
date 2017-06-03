using System;

using Nucleo.Windows.Actions;
using Nucleo.Windows.Application;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class PopupWindowListener : BaseModelListener
	{
		#region " Constructors "

		public PopupWindowListener(ListenerControl control, ApplicationModel application) 
			: base(control, application) { }

		#endregion



		#region " Methods "

		protected internal override bool IsSupportedUIElement(UIElement element)
		{
			return (element is PopupWindow);
		}

		#endregion
	}
}
