using System;

using Nucleo.Windows.Actions;


namespace Nucleo.Windows.UI
{
	public class ToolbarTextBox : ToolbarTextItem
	{
		#region " Events "

		public static EventAction TextChangedEvent = EventAction.Create("TextChanged", typeof(ToolbarTextBox));

		#endregion



		#region " Constructors "

		public ToolbarTextBox(string name, string title, Toolbar parent)
			: base(name, title, parent) { }

		public ToolbarTextBox(string name, string title, string text, Toolbar parent)
			: base(name, title, text, parent)
		{

		}

		#endregion



		#region " Methods "

		public override EventActionCollection GetEvents()
		{
			return new EventActionCollection
			       	{
						TextChangedEvent
			       	};
		}

		#endregion
	}
}
