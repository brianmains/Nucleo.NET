using System;
using Nucleo.Windows.Actions;


namespace Nucleo.Windows.UI
{
	public class DocumentWindow : BaseWindow
	{

		#region " Events "

		public static EventAction ClickEvent = EventAction.Create("Click", typeof(DocumentWindow), DefaultEventAction.Click);
		public static EventAction HideEvent = EventAction.Create("Hiding", typeof(DocumentWindow), DefaultEventAction.Hide);
		public static EventAction SelectEvent = EventAction.Create("Select", typeof(DocumentWindow), DefaultEventAction.Select);
		public static EventAction ShowEvent = EventAction.Create("Showing", typeof(DocumentWindow), DefaultEventAction.Show);

		#endregion
		
		
		
		#region " Constructors "

		public DocumentWindow(string name, string title, object uiInterface)
			: base(name, title, uiInterface) { }

		#endregion



		#region " Methods "

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is DocumentWindow))
				return false;

			return this.Name.Equals(((DocumentWindow)obj).Name);
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
