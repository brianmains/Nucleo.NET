using System;

using Nucleo.Windows.Actions;


namespace Nucleo.Windows.UI
{
	public class PopupWindow : BaseWindow
	{
		#region " Events "

		public static EventAction ClickEvent = EventAction.Create("Click", typeof(PopupWindow));
		public static EventAction HideEvent = EventAction.Create("Hiding", typeof(PopupWindow));
		public static EventAction SelectEvent = EventAction.Create("Select", typeof(PopupWindow));
		public static EventAction ShowEvent = EventAction.Create("Showing", typeof(PopupWindow));

		#endregion



		#region " Constructors "

		public PopupWindow(string name, string title, object userInterface)
			: base(name, title, userInterface) { }

		#endregion



		#region " Methods "

		public override EventActionCollection GetEvents()
		{
			return new EventActionCollection
			       	{
						PopupWindow.ClickEvent,
						PopupWindow.HideEvent,
						PopupWindow.SelectEvent,
						PopupWindow.ShowEvent
			       	};
		}

		#endregion
	}
}
