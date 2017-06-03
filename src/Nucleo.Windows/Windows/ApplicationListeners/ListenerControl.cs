using System;
using System.Collections.Generic;

using Nucleo.Windows.Actions;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class ListenerControl
	{
		#region " Methods "

		public abstract void AddItem(int index, UIElement item);
		public abstract void HandleEvent(EventAction action);
		public abstract void RemoveItem(UIElement item);
		public abstract void RemoveItem(int index);

		#endregion
	}
}
