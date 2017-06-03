using System;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
    public abstract class InterfaceRenderer<T>
        where T : UIElement
    {
        public abstract void AddItem(T uiItem);
		public abstract void AddItem(int index, T uiItem);

		protected virtual System.Windows.Forms.Control GetControlReference(object uiInterface)
		{
			return ControlUtility.GetWindowsControlReference(uiInterface);
		}

		public abstract void RemoveItem(T uiItem);
    }
}
