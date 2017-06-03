using System;

using Nucleo.EventArguments;
using Nucleo.Windows.Actions;


namespace Nucleo.Windows.UI
{
	public class ToolWindow : BaseWindow
	{
		private ToolWindowLocation _location = ToolWindowLocation.Left;



		#region " Events "

		public static EventAction ClickEvent = EventAction.Create("Click", typeof(DocumentWindow));
		public static EventAction HideEvent = EventAction.Create("Hiding", typeof(DocumentWindow));
		public static EventAction SelectEvent = EventAction.Create("Select", typeof(DocumentWindow));
		public static EventAction ShowEvent = EventAction.Create("Showing", typeof(DocumentWindow));

		#endregion



		#region " Properties "

		/// <summary>
		/// The location of the tool window in the application area.
		/// </summary>
		public ToolWindowLocation Location
		{
			get { return _location; }
			set
			{
				if (_location != value)
				{
					ToolWindowLocation oldLocation = _location;
					_location = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Location", oldLocation, value));
				}
			}
		}

		#endregion



		#region " Constructors "

		public ToolWindow(string name, string title, ToolWindowLocation location, object uiInterface)
			: base(name, title, uiInterface)
		{
			_location = location;
		}

		#endregion



		#region " Methods "

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is ToolWindow))
				return false;

			ToolWindow window = (ToolWindow)obj;
			return this.Name.Equals(window.Name);
		}

		/// <summary>
		/// Attaches to the document's events.
		/// </summary>
		public override EventActionCollection GetEvents()
		{
			return new EventActionCollection()
			       	{
			       		DocumentWindow.ClickEvent,
			       		DocumentWindow.HideEvent,
			       		DocumentWindow.SelectEvent,
			       		DocumentWindow.ShowEvent
			       	};
		}

		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		#endregion
	}
}
