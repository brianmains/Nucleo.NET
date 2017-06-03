using System;
using System.Drawing;

using Nucleo.Windows.Actions;
using Nucleo.EventArguments;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public class ToolbarButton : ToolbarTextImageItem
	{
		#region " Events "

		public static EventAction ClickEvent = EventAction.Create("Click", typeof(ToolbarButton));

		#endregion



		#region " Constructors "

		public ToolbarButton(string name, string title, Toolbar parent)
			: base(name, title, parent) { }

		public ToolbarButton(string name, string title, string text, Image image, Toolbar parent)
			: base(name, title, text, image, parent) { }

		#endregion



		#region " Methods "

		public override EventActionCollection GetEvents()
		{
			return new EventActionCollection
			       	{
						ClickEvent
			       	};
		}

		#endregion
	}
}
